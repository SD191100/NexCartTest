using Microsoft.AspNetCore.Http;
using NexCart.Helpers;
using NexCart.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace NexCart.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _jwtKey;

        public JwtMiddleware(RequestDelegate next, string jwtKey)
        {
            _next = next;
            _jwtKey = jwtKey;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepository)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                try
                {
                    var claimsPrincipal = JwtHelper.ValidateToken(token, _jwtKey);
                    var userId = int.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                    // Attach user to the context
                    context.Items["User"] = userRepository.GetUserById(userId);
                }
                catch
                {
                    // Token validation failed
                }
            }

            await _next(context);
        }
    }
}

