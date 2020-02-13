namespace CompanyManager.Data.UnitOfWork
{
    using System;
    using System.Threading.Tasks;
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Repositories.RepositoryInterfaces;

    public interface IUnitOfWork : IDisposable
    {
        CompanyManagerContext Context { get; }

        #region Repositories

        IEmployeeRepository EmployeeRepository { get; set; }

        IEnterpriseRepository EnterpriseRepository { get; set; }

        IPermissionRepository PermissionRepository { get; set; }

        IPurchaseRepository PurchaseRepository { get; set; }

        IRoleRepository RoleRepository { get; set; }

        IUserRepository UserRepository { get; set; }

        IWorkAreaRepository WorkAreaRepository { get; set; }

        IUserInfomationRepository UserInformationRepository { get; set; }

        #endregion

        void SaveChanges();

        Task SaveChangesAsync();

        bool Disposed { get; }
    }
}
