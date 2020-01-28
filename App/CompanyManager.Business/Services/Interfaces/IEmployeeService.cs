namespace CompanyManager.Business.Services.Interfaces
{
    using CompanyManager.Models;

    public interface IEmployeeService : IService<Employee>
    {
        // DLT
        // IQueryable<Employee> GetByEnterpriseId(int enterpriseId);
    }
}
