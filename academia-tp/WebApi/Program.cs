

using Domain.model;
using Domain.services;
using DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Hello World!");


app.MapGet("/planes", () =>
{
    PlanServices planService = new PlanServices();

    IEnumerable<Plan> planes = planService.GetAll();

    return Results.Ok(planes);

});


app.MapGet("planes/{id}", (int id) =>
{
    PlanServices planService = new PlanServices();
    Plan plan = planService.GetOne(id);

    if( plan is null) {return Results.NotFound(); }

    return Results.Ok(plan);
});


app.MapPost("/planes", (CreatePlanDTO plan) =>
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

app.MapPost("/especialidades", (EspecialidadDTO especialidad) =>
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



app.Run();
