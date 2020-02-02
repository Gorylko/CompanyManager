namespace CompanyManager.Business.Dependency
{
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Business.Services.Realizations;
    using CompanyManager.Data.UnitOfWork;
    using Microsoft.Extensions.DependencyInjection;

    public static class BusinessRegistry
    {
        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEnterpriseService, EnterpriseService>();
            services.AddScoped<IWorkAreaService, WorkAreaService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
