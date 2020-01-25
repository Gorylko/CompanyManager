namespace CompanyManager.Data.Repositories.RepositoryRealization
{
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.GenericRepository;
    using CompanyManager.Data.Repositories.RepositoryInterfaces;

    public class PermissionRepository : GenericRepository<PermissionDto>, IPermissionRepository
    {
        public PermissionRepository(CompanyManagerContext context)
            : base(context)
        {
        }
    }
}
