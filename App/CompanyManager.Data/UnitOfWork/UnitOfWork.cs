namespace CompanyManager.Data.UnitOfWork
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Repositories.RepositoryInterfaces;
    using CompanyManager.Data.Repositories.RepositoryRealization;
    using Microsoft.EntityFrameworkCore;

    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            var options = new DbContextOptionsBuilder<CompanyManagerContext>()
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(Settings.ConnectionString).Options;

            _context = new CompanyManagerContext(options);
        }

        #region Fields

        private readonly CompanyManagerContext _context;
        private IEmployeeRepository _employeeRepository;
        private IEnterpriseRepository _enterpriseRepository;
        private IPermissionRepository _permissionRepository;
        private IPurchaseRepository _purchaseRepository;
        private IRoleRepository _roleRepository;
        private IWorkAreaRepository _workAreaRepository;
        private IUserRepository _userRepository;

        #endregion

        #region Reps

        public CompanyManagerContext Context => _context;

        public IEmployeeRepository EmployeeRepository
        {
            get => _employeeRepository ?? new EmployeeRepository(_context);
            set => _employeeRepository = value;
        }

        public IEnterpriseRepository EnterpriseRepository
        {
            get => _enterpriseRepository ?? new EnterpriseRepository(_context);
            set => _enterpriseRepository = value;
        }

        public IPermissionRepository PermissionRepository
        {
            get => _permissionRepository ?? new PermissionRepository(_context);
            set => _permissionRepository = value;
        }

        public IPurchaseRepository PurchaseRepository
        {
            get => _purchaseRepository ?? new PurchaseRepository(_context);
            set => _purchaseRepository = value;
        }

        public IRoleRepository RoleRepository
        {
            get => _roleRepository ?? new RoleRepository(_context);
            set => _roleRepository = value;
        }

        public IWorkAreaRepository WorkAreaRepository
        {
            get => _workAreaRepository ?? new WorkAreaRepository(_context);
            set => _workAreaRepository = value;
        }

        public IUserRepository UserRepository
        {
            get => _userRepository ?? new UserRepository(_context);
            set => _userRepository = value;
        }

        #endregion

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("Error at applying context changes", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("Error at applying context changes", ex);
            }
        }

        public bool Disposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                _context.Dispose();
            }

            Disposed = true;
        }
    }
}
