namespace CompanyManager.Data.Repositories.RepositoryInterfaces
{
    using System.Linq;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.GenericRepository;

    public interface IPurchaseRepository : IGenericRepository<PurchaseDto>
    {
        IQueryable<PurchasesByEnterpriseIdResult> GetByEnterpriseId(int enterpriseId);
    }
}
