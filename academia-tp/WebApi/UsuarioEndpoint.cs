using Domain.model;
using Domain.services;
using DTOs;

namespace WebApi
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {   

            app.MapGet("/usuarios", () =>
            {
                UsuarioServices usuarioService = new UsuarioServices();

                IEnumerable<Usuario> usuarios = usuarioService.GetAll();

                return Results.Ok(usuarios);

            });

            app.MapGet("usuarios/{id}", (int id) =>
            {
                UsuarioServices usuarioService = new UsuarioServices();
                Usuario? usuario = usuarioService.GetOne(id);

                if (usuario is null) { return Results.NotFound(); }

                return Results.Ok(usuario);
            });


            app.MapPost("/usuarios", (Usuario usuario) =>
            {
                UsuarioServices usuarioService = new UsuarioServices();
                Usuario createdUsuario = usuarioService.Create(usuario);
                return Results.Created($"/usuarios/{createdUsuario.Id}", createdUsuario);
            });

            app.MapPut("/usuarios/{id}", (int id, Usuario updatedUsuario) =>
            {
                UsuarioServices usuarioService = new UsuarioServices();
                var existingUsuario = usuarioService.GetOne(id);
                if (existingUsuario is null)
                {
                    return Results.NotFound();
                }
                usuarioService.Update(id, updatedUsuario);
                return Results.Ok(updatedUsuario);
            });

            app.MapDelete("/usuarios/{id}", (int id) =>
            {
                UsuarioServices usuarioService = new UsuarioServices();
                var existingPlan = usuarioService.GetOne(id);
                if (existingPlan is null)
                {
                    return Results.NotFound();
                }
                usuarioService.Delete(id);
                return Results.NoContent();
            });
        }
    }
}