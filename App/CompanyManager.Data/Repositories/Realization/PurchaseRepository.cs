namespace CompanyManager.Data.Repositories.Realization
{
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.Interfaces;

    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(CompanyManagerContext context)
            : base(context)
        {
        }
    }
}
