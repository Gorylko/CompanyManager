namespace CompanyManager.Data.Dependency
{
    using CompanyManager.Data.Context;
    using CompanyManager.Data.UnitOfWork;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DataRegistry
    {
        public static void AddDataDependencies(this IServiceCollection services)
        {
            services.AddDbContext<CompanyManagerContext>(options =>
                options.UseSqlServer(Settings.ConnectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
