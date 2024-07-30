using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyFirstASP.net
{
    public class CustomHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Equals("/handler.ashx"))
            {
                // 用POST
                if (context.Request.Method == "POST")
                {
                    var uname = context.Request.Form["uname"];
                    var upwd = context.Request.Form["upwd"];

                    // 驗證測試
                    if (uname == "admin" && upwd == "password")
                    {
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("susses");
                    }
                    else
                    {
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("wrong");
                    }
                }
                else
                {
                    // 如果不是 POST RETUEN 405
                    context.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}
