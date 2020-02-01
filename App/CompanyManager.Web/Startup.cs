namespace CompanyManager.Web
{
    using CompanyManager.Business.Dependency;
    using CompanyManager.Data.Dependency;
    using CompanyManager.Web.Middlewares;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using CompanyManager.Web.ExceptionHandling;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using System;
    using System.Net;
    using CompanyManager.Web.ExceptionHandling.Builders;
    using Microsoft.Azure.Documents;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataDependencies();
            services.AddBusinessDependencies();

            services.AddControllers();

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Company Manager API";
                    document.Info.Description = "Hello";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Proj",
                        Email = string.Empty,
                        Url = "https://dev.azure.com/KirylShamiakou/CompanyManager",
                    };
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandling(builder =>
            {
                builder.WithException<DocumentClientException>(ex => (HttpStatusCode)ex.StatusCode);
                builder.WithException<ArgumentNullException>(HttpStatusCode.LengthRequired);
                builder.WithException<Exception>(HttpStatusCode.NotFound);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();

            ConfigureLogger();

            app.UseMiddleware<LoggerMiddleware>();
        }

        private void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
        }
    }
}
