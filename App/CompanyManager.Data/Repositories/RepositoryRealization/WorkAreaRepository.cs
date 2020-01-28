namespace CompanyManager.Data.Repositories.RepositoryRealization
{
    using System.Linq;
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.GenericRepository;
    using CompanyManager.Data.Repositories.RepositoryInterfaces;

    public class WorkAreaRepository : GenericRepository<WorkAreaDto>, IWorkAreaRepository
    {
        public WorkAreaRepository(CompanyManagerContext context)
            : base(context)
        {
        }

        public IQueryable<WorkAreasByEnterpriseIdResult> GetByEnterpriseId(int enterpriseId)
        {
            return _context.WorkAreasByEnterpriseId(enterpriseId);
        }
    }
}
