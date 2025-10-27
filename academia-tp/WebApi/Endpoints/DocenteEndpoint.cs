using Domain.model;
using Domain.services;

namespace WebApi.Endpoints
{
    public static class DocenteEndpoint
    {
        public static void MapDocenteEndpoints(this WebApplication app)
        {

            app.MapGet("/docentes", () =>
            {
                DocenteSevices service = new DocenteSevices();

                IEnumerable<Docente> docentes = service.GetAll();

                return Results.Ok(docentes);
            });

            app.MapGet("/docentes/{id}", (int id) =>
            {
                DocenteSevices service = new DocenteSevices();
                Docente? docente = service.GetOne(id);

                if (docente is null) { return Results.NotFound(); }

                return Results.Ok(docente);
            });

            app.MapPost("/docentes", (Docente docente) =>
            {
                DocenteSevices service = new DocenteSevices();
                Docente createdDocente = service.Create(docente);
                return Results.Created($"/docentes/{createdDocente.Id}", createdDocente);
            });

            app.MapPut("/docentes/{id}", (int id, Docente updatedDocente) =>
            {
                DocenteSevices service = new DocenteSevices();
                var existingDocente = service.GetOne(id);
                if (existingDocente is null)
                {
                    return Results.NotFound();
                }
                service.Update(id, updatedDocente);
                return Results.Ok(updatedDocente);
            });

            app.MapDelete("/docentes/{id}", (int id) =>
            {
                DocenteSevices service = new DocenteSevices();
                var existingDocente = service.GetOne(id);
                if (existingDocente is null)
                {
                    return Results.NotFound();
                }
                service.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
