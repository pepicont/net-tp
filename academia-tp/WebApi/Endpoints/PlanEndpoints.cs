using Domain.model;
using Domain.services;
using DTOs;

namespace WebApi.Endpoints
{
    public static class PlanEndpoints
    {
        public static void MapPlanEndpoints(this WebApplication app)
        {

            app.MapGet("/planes", () =>
            {
                PlanServices planService = new PlanServices();

                IEnumerable<Plan> planes = planService.GetAll();

                return Results.Ok(planes);
            });

            app.MapGet("/planes/{id}", (int id) =>
            {
                PlanServices planService = new PlanServices();
                Plan? plan = planService.GetOne(id);

                if (plan is null) { return Results.NotFound(); }

                return Results.Ok(plan);
            });

            app.MapPost("/planes", (Plan plan) =>
            {
                PlanServices planService = new PlanServices();
                Plan createdPlan = planService.Create(plan);
                return Results.Created($"/planes/{createdPlan.Id}", createdPlan);
            });

            app.MapPut("/planes/{id}", (int id, UpdatePlanDTO updatedPlan) =>
            {
                PlanServices planService = new PlanServices();
                var existingPlan = planService.GetOne(id);
                if (existingPlan is null)
                {
                    return Results.NotFound();
                }
                planService.Update(id, updatedPlan);
                return Results.Ok(updatedPlan);
            });

            app.MapDelete("/planes/{id}", (int id) =>
            {
                PlanServices planService = new PlanServices();
                var existingPlan = planService.GetOne(id);
                if (existingPlan is null)
                {
                    return Results.NotFound();
                }
                planService.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
