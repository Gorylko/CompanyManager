namespace CompanyManager.Data.Repositories.RepositoryRealization
{
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.GenericRepository;
    using CompanyManager.Data.Repositories.RepositoryInterfaces;

    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(CompanyManagerContext context)
            : base(context)
        {
        }
    }
}
