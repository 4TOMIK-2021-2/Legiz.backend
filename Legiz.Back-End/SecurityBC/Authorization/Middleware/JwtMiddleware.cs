using System.Linq;
using System.Threading.Tasks;
using Legiz.Back_End.SecurityBC.Authorization.Handlers.Interfaces;
using Legiz.Back_End.SecurityBC.Authorization.Settings;
using Legiz.Back_End.SecurityBC.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Legiz.Back_End.SecurityBC.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings.Value;
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = handler.ValidateToken(token);
            if (userId != null)
            {
                context.Items["User"] = await userService.GetByIdAsync(userId.Value);
            }

            await _next(context);
        }
    }
}