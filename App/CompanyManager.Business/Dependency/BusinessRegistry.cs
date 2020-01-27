namespace CompanyManager.Business.Dependency
{
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Business.Services.Realizations;
    using Microsoft.Extensions.DependencyInjection;

    public static class BusinessRegistry
    {
        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEnterpriseService, EnterpriseService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
