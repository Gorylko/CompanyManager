namespace CompanyManager.Data.Repositories.RepositoryInterfaces
{
    using System.Linq;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.GenericRepository;

    public interface IEmployeeRepository : IGenericRepository<EmployeeDto>
    {
        IQueryable<EmployeeByEnterpriseIdResult> GetByEnterpriseId(int enterpriseId);
    }
}
