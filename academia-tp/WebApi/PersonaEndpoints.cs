using Domain.services;
using DTOs;
using DataDomain;
using Domain.model;


namespace WebApi
{
    public static class PersonaEndpoints
    {
        public static void MapPersonaEndpoints(this WebApplication app)
        {
            app.MapGet("/personas", () =>
            {
                PersonaServices personaService = new PersonaServices();

                IEnumerable<Persona> personas = personaService.GetAll();

                return Results.Ok(personas);
            });

            app.MapGet("personas/{id}", (int id) =>
            {
                PersonaServices personaService = new PersonaServices();
                Persona? persona = personaService.GetOne(id);

                if (persona is null) { return Results.NotFound(); }

                return Results.Ok(persona);
            });

            app.MapPost("/personas", (Persona persona) =>
            {
                PersonaServices personaService = new PersonaServices();
                Persona createdpersona = personaService.Create(persona);
                return Results.Created($"/personas/{createdpersona.Id}", createdpersona);
            });

            app.MapPut("/personas/{id}", (int id, Persona updatedpersona) =>
            {
                PersonaServices personaService = new PersonaServices();
                var existingpersona = personaService.GetOne(id);
                if (existingpersona is null)
                {
                    return Results.NotFound();
                }
                personaService.Update(id, updatedpersona);
                return Results.Ok(updatedpersona);
            });

            app.MapDelete("/personas/{id}", (int id) =>
            {
                PersonaServices personaService = new PersonaServices();
                var existingpersona = personaService.GetOne(id);
                if (existingpersona is null)
                {
                    return Results.NotFound();
                }
                personaService.Delete(id);
                return Results.NoContent();
            });
        }
    }
}
