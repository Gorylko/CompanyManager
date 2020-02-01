namespace CompanyManager.Web.ExceptionHandling
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using CompanyManager.Web.ExceptionHandling.Builders;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;

    internal static class ExceptionMiddlewareExtensions
    {
        internal static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, Action<ExceptionHandlerBuilder> setupActions)
        {
            var builder = new ExceptionHandlerBuilder(setupActions);

            app.UseExceptionHandler(
                options =>
                {
                    options.Run(builder.BuildRequestDelegate());
                });
            return app;
        }
    }
}
