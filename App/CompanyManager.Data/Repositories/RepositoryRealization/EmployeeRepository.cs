namespace CompanyManager.Data.Repositories.RepositoryRealization
{
    using System.Linq;
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.GenericRepository;
    using CompanyManager.Data.Repositories.RepositoryInterfaces;

    public class EmployeeRepository : GenericRepository<EmployeeDto>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyManagerContext context)
            : base(context)
        {
        }

        public IQueryable<EmployeeByEnterpriseIdResult> GetByEnterpriseId(int enterpriseId)
        {
            return _context.EmployeeByEnterpriseId(enterpriseId);
        }
    }
}
