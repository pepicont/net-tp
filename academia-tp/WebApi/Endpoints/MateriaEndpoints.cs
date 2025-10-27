using Domain.model;
using Domain.services;
using DTOs;

namespace WebApi.Endpoints
{
    public static class MateriaEndpoints
    {
        public static void MapMateriaEndpoints(this WebApplication app)
        {

            app.MapGet("/materias", () =>
            {
                MateriaServices service = new MateriaServices();

                IEnumerable<Materia> materias = service.GetAll();

                return Results.Ok(materias);
            });

            app.MapGet("/materias/{id}", (int id) =>
            {
                MateriaServices service = new MateriaServices();
                Materia? plan = service.GetOne(id);

                if (plan is null) { return Results.NotFound(); }

                return Results.Ok(plan);
            });

            app.MapPost("/materias", (Materia plan) =>
            {
                MateriaServices service = new MateriaServices();
                Materia createdMateria = service.Create(plan);
                return Results.Created($"/materias/{createdMateria.Id}", createdMateria);
            });

            app.MapPut("/materias/{id}", (int id, Materia updatedMateria) =>
            {
                MateriaServices service = new MateriaServices();
                var existingMateria = service.GetOne(id);
                if (existingMateria is null)
                {
                    return Results.NotFound();
                }
                service.Update(id, updatedMateria);
                return Results.Ok(updatedMateria);
            });

            app.MapDelete("/materias/{id}", (int id) =>
            {
                MateriaServices service = new MateriaServices();
                var existingMateria = service.GetOne(id);
                if (existingMateria is null)
                {
                    return Results.NotFound();
                }
                service.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
