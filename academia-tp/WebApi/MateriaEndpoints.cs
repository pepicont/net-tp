using Domain.model;
using Domain.services;
using DTOs;

namespace WebApi
{
    public static class MateriaEndpoints
    {
        public static void MapMateriaEndpoints(this WebApplication app)
        {

            app.MapGet("/materias", () =>
            {
                MateriaServices planService = new MateriaServices();

                IEnumerable<Materia> materias = planService.GetAll();

                return Results.Ok(materias);
            });

            app.MapGet("/materias/{id}", (int id) =>
            {
                MateriaServices planService = new MateriaServices();
                Materia? plan = planService.GetOne(id);

                if (plan is null) { return Results.NotFound(); }

                return Results.Ok(plan);
            });

            app.MapPost("/materias", (Materia plan) =>
            {
                MateriaServices planService = new MateriaServices();
                Materia createdMateria = planService.Create(plan);
                return Results.Created($"/materias/{createdMateria.Id}", createdMateria);
            });

            app.MapPut("/materias/{id}", (int id, Materia updatedMateria) =>
            {
                MateriaServices planService = new MateriaServices();
                var existingMateria = planService.GetOne(id);
                if (existingMateria is null)
                {
                    return Results.NotFound();
                }
                planService.Update(id, updatedMateria);
                return Results.Ok(updatedMateria);
            });

            app.MapDelete("/materias/{id}", (int id) =>
            {
                MateriaServices planService = new MateriaServices();
                var existingMateria = planService.GetOne(id);
                if (existingMateria is null)
                {
                    return Results.NotFound();
                }
                planService.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
