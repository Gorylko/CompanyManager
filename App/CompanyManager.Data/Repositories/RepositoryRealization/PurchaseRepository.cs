namespace CompanyManager.Data.Repositories.RepositoryRealization
{
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.GenericRepository;
    using CompanyManager.Data.Repositories.RepositoryInterfaces;

    public class PurchaseRepository : GenericRepository<PurchaseDto>, IPurchaseRepository
    {
        public PurchaseRepository(CompanyManagerContext context)
            : base(context)
        {
        }
    }
}
