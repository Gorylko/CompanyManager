namespace CompanyManager.Data.Repositories.Realization
{
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.Interfaces;

    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(CompanyManagerContext context)
            : base(context)
        {
        }
    }
}
