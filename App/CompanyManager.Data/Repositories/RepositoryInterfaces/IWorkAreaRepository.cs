namespace CompanyManager.Data.Repositories.RepositoryInterfaces
{
    using System.Linq;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.GenericRepository;

    public interface IWorkAreaRepository : IGenericRepository<WorkAreaDto>
    {
        IQueryable<WorkAreasByEnterpriseIdResult> GetByEnterpriseId(int enterpriseId);
    }
}
