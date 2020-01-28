namespace CompanyManager.Business.Services.Interfaces
{
    using CompanyManager.Models;
    using System.Linq;

    public interface IEmployeeService : IService<Employee>
    {
        IQueryable<Employee> GetByEnterpriseId(int enterpriseId);
    }
}
