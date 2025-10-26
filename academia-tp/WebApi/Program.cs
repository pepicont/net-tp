

using Domain.model;
using Domain.services;
using DTOs;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Hola Mundo!");

app.MapEspecialidadEndpoints();
app.MapPlanEndpoints();
app.MapPersonaEndpoints();
app.MapUsuarioEndpoints();
app.MapMateriaEndpoints();
app.MapCursoEndpoints();
app.MapInscripcionEndpoints();
app.MapDocenteEndpoints();
app.MapReporteEndpoints();


app.Run();
