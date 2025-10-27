using Domain.services;
namespace WebApi.Endpoints
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            // POST /auth/login?username=admin&password=123
            app.MapPost("/auth/login", (string username, string password) =>
            {
                try
                {
                    var usuario = AuthService.Login(username, password);

                    if (usuario == null)
                    {
                        return Results.Unauthorized();
                    }

                    return Results.Ok(usuario);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error al iniciar sesión: {ex.Message}");
                }
            });
        }
    }
}
