using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AuthenticationService authenticationService)
    {

        var allowRoutes = new List<string>() { "/", "/SignIn" };

        var route = context.Request.Path;

        foreach (string allowRoute in allowRoutes)
        {
            if (allowRoute == route)
            {
                await _next(context);
                return;
            }
        }

        var AccessToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (AccessToken != null)
        {
            var data = authenticationService.Auth(AccessToken);
            if (data is string)
            {
                context.Response.StatusCode = 401; //UnAuthorized
                await context.Response.WriteAsync((string)data);
                return;
            }
            JwtSecurityToken jwtData = data;
            context.Items["id"] = int.Parse(jwtData.Claims.First(x => x.Type == "id").Value);
            await _next(context);
            return;
        }


        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Esse token de acesso não é válido");
        return;

    }
}