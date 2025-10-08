using Domain.model;
using Domain.services;
using DTOs;

namespace WebApi
{
    public static class CursoEndpoints
    {
        public static void MapCursoEndpoints(this WebApplication app)
        {

            app.MapGet("/cursos", () =>
            {
                CursoServices service = new CursoServices();

                IEnumerable<Curso> cursos= service.GetAll();

                return Results.Ok(cursos);
            });

            app.MapGet("/cursos/{id}", (int id) =>
            {
                CursoServices service = new CursoServices();
                Curso? comision = service.GetOne(id);

                if (comision is null) { return Results.NotFound(); }

                return Results.Ok(comision);
            });

            app.MapPost("/cursos", (Curso comision) =>
            {
                CursoServices service = new CursoServices();
                Curso createdCurso = service.Create(comision);
                return Results.Created($"/cursos/{createdCurso.Id}", createdCurso);
            });

            app.MapPut("/cursos/{id}", (int id, Curso updatedCurso) =>
            {
                CursoServices service = new CursoServices();
                var existingCurso = service.GetOne(id);
                if (existingCurso is null)
                {
                    return Results.NotFound();
                }
                service.Update(id, updatedCurso);
                return Results.Ok(updatedCurso);
            });

            app.MapGet("/cursos/materia/{materiaId}", (int materiaId) =>
            {
                CursoServices service = new CursoServices();
                var cursos = service.GetAll().Where(c => c.Id_materia == materiaId);
                return Results.Ok(cursos);
            });

            app.MapDelete("/cursos/{id}", (int id) =>
            {
                CursoServices service = new CursoServices();
                var existingCurso = service.GetOne(id);
                if (existingCurso is null)
                {
                    return Results.NotFound();
                }
                service.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
