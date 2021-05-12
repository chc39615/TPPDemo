using CMSAPI.Models.Response;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMSAPI.Middleware
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate pNext)
        {
            next = pNext;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch
            {

                var resp = new ResponseTemplate(resultCode: "9999", resultMessage: "internal error");

                await context.Response.WriteAsync(JsonSerializer.Serialize(resp));

            }
        }

    }
}
