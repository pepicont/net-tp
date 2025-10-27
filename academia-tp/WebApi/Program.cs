

using Domain.model;
using Domain.services;
using DTOs;
using QuestPDF.Infrastructure;
using WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

QuestPDF.Settings.License = LicenseType.Community;


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
app.MapAuthEndpoints();


app.Run();
