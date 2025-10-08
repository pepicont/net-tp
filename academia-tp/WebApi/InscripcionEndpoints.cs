using Domain.model;
using Domain.services;
using DTOs;

namespace WebApi
{
    public static class InscripcionEndpoints
    {
        public static void MapInscripcionEndpoints(this WebApplication app)
        {
            app.MapGet("/inscripciones/search", (string? searchTerm) =>
            {
                InscripcionServices inscripcionService = new InscripcionServices();
                var inscripciones = inscripcionService.SearchDTO(searchTerm ?? string.Empty);
                return Results.Ok(inscripciones);
            });

            app.MapGet("/inscripciones/alumno/{idAlumno}", (int idAlumno) =>
            {
                InscripcionServices inscripcionService = new InscripcionServices();
                var inscripciones = inscripcionService.GetInscripcionesByAlumno(idAlumno);
                return Results.Ok(inscripciones);
            });

            app.MapGet("/inscripciones/{id}", (int id) =>
            {
                InscripcionServices inscripcionService = new InscripcionServices();
                var inscripcion = inscripcionService.GetOne(id);
                if (inscripcion is null)
                    return Results.NotFound();
                return Results.Ok(inscripcion);
            });

            app.MapPost("/inscripciones", (Inscripcion inscripcion) =>
            {
                try
                {
                    InscripcionServices inscripcionService = new InscripcionServices();
                    var createdInscripcion = inscripcionService.Create(inscripcion);
                    return Results.Created($"/inscripciones/{createdInscripcion.Id}", createdInscripcion);
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { message = ex.Message });
                }
            });
            app.MapPut("/inscripciones/{id}", (int id, Inscripcion updatedInscripcion) =>
            {
                InscripcionServices inscripcionService = new InscripcionServices();
                var existingInscripcion = inscripcionService.GetOne(id);
                if (existingInscripcion is null)
                {
                    return Results.NotFound();
                }
                inscripcionService.Update(id, updatedInscripcion);
                return Results.Ok(updatedInscripcion);
            });
            app.MapDelete("/inscripciones/{id}", (int id) =>
            {
                InscripcionServices inscripcionService = new InscripcionServices();
                var existingInscripcion = inscripcionService.GetOne(id);
                if (existingInscripcion is null)
                {
                    return Results.NotFound();
                }
                inscripcionService.Delete(id);
                return Results.NoContent();
            });
        }
    }
}