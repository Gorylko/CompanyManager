namespace CompanyManager.Data.Repositories.RepositoryRealization
{
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.GenericRepository;
    using CompanyManager.Data.Repositories.RepositoryInterfaces;

    public class EnterpriseRepository : GenericRepository<EnterpriseDto>, IEnterpriseRepository
    {
        public EnterpriseRepository(CompanyManagerContext context)
            : base(context)
        {
        }
    }
}
