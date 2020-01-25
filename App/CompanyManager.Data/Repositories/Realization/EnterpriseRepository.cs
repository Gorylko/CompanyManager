namespace CompanyManager.Data.Repositories.Realization
{
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.Interfaces;

    public class EnterpriseRepository : GenericRepository<Enterprise>, IEnterpriseRepository
    {
        public EnterpriseRepository(CompanyManagerContext context)
            : base(context)
        {
        }
    }
}
