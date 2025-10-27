using Domain.model;
using Domain.services;
using DTOs;

namespace WebApi.Endpoints
{
    public static class EspecialidadEndpoints
    {
        public static void MapEspecialidadEndpoints(this WebApplication app) {
            app.MapGet("/especialidades", () =>
            {
                EspecialidadServices especialidadService = new EspecialidadServices();
                var especialidades = especialidadService.GetAll();
                return Results.Ok(especialidades);
            });

            app.MapGet("/especialidades/{id}", (int id) =>
            {
                EspecialidadServices especialidadService = new EspecialidadServices();
                var especialidad = especialidadService.GetOne(id);
                if (especialidad is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(especialidad);
            });
            

            app.MapPost("/especialidades", (Especialidad especialidad) =>
            {
                EspecialidadServices especialidadService = new EspecialidadServices();
                var createdEspecialidad = especialidadService.Create(especialidad);
                return Results.Created($"/especialidades/{createdEspecialidad.Id}", createdEspecialidad);
            });

            app.MapPut("/especialidades/{id}", (int id, EspecialidadDTO updatedEspecialidad) =>
            {
                EspecialidadServices especialidadService = new EspecialidadServices();
                var existingEspecialidad = especialidadService.GetOne(id);
                if (existingEspecialidad is null)
                {
                    return Results.NotFound();
                }
                especialidadService.Update(id, updatedEspecialidad);
                return Results.Ok(updatedEspecialidad);
            });

            app.MapDelete("/especialidades/{id}", (int id) =>
            {
                EspecialidadServices especialidadService = new EspecialidadServices();
                var existingEspecialidad = especialidadService.GetOne(id);
                if (existingEspecialidad is null)
                {
                    return Results.NotFound();
                }
                especialidadService.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
