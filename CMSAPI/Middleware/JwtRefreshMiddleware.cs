using CMSAPI.JWT.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CMSAPI.Middleware
{
    public class JwtRefreshMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IJwtAuthManager jwtAuthManager;

        public JwtRefreshMiddleware(RequestDelegate pNext, IJwtAuthManager pJwtAuthManager)
        {
            next = pNext;
            jwtAuthManager = pJwtAuthManager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 如果是 Login 就不 Refresh token
            if (!context.Request.Path.Value.Contains("Login"))
            {
                var accessToken = await context.GetTokenAsync("Bearer", "access_token");

                if (!string.IsNullOrEmpty(accessToken))
                {
                    var jwtResult = jwtAuthManager.Refresh(accessToken, DateTime.Now);
                    context.Response.Headers.Remove("accessToken");
                    context.Response.Headers.Add("accessToken", jwtResult.AccessToken);
                }
            }

            await next(context);
        }
    }
}
