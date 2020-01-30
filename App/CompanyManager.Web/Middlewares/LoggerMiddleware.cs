namespace CompanyManager.Web.Middlewares
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Serilog;

    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Log.Logger.Information($"{context.GetEndpoint()?.DisplayName}");
            Log.Logger.Information($".userId");
            Log.Logger.Information($"{context.Response.StatusCode}");
            await _next.Invoke(context);
        }
    }
}
