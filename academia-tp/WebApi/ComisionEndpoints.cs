using Domain.model;
using Domain.services;
using DTOs;

namespace WebApi
{
    public static class ComisionEndpoints
    {
        public static void MapComisionEndpoints(this WebApplication app)
        {

            app.MapGet("/comisiones", () =>
            {
                ComisionServices service = new ComisionServices();

                IEnumerable<Comision> comisiones= service.GetAll();

                return Results.Ok(comisiones);
            });

            app.MapGet("/comisiones/{id}", (int id) =>
            {
                ComisionServices service = new ComisionServices();
                Comision? comision = service.GetOne(id);

                if (comision is null) { return Results.NotFound(); }

                return Results.Ok(comision);
            });

            app.MapPost("/comisiones", (Comision comision) =>
            {
                ComisionServices service = new ComisionServices();
                Comision createdComision = service.Create(comision);
                return Results.Created($"/comisiones/{createdComision.Id}", createdComision);
            });

            app.MapPut("/comisiones/{id}", (int id, Comision updatedComision) =>
            {
                ComisionServices service = new ComisionServices();
                var existingComision = service.GetOne(id);
                if (existingComision is null)
                {
                    return Results.NotFound();
                }
                service.Update(id, updatedComision);
                return Results.Ok(updatedComision);
            });

            app.MapDelete("/comisiones/{id}", (int id) =>
            {
                ComisionServices service = new ComisionServices();
                var existingComision = service.GetOne(id);
                if (existingComision is null)
                {
                    return Results.NotFound();
                }
                service.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
