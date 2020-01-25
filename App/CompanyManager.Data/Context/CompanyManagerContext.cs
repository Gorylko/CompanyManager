namespace CompanyManager.Data.Context
{
    using CompanyManager.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CompanyManagerContext : DbContext
    {
        public CompanyManagerContext(DbContextOptions<CompanyManagerContext> options)
                : base(options)
        {
        }

        public DbSet<EmployeeDto> Employees { get; set; }

        public DbSet<EnterpriseDto> Enterprises { get; set; }

        public DbSet<PermissionDto> Permissions { get; set; }

        public DbSet<PurchaseDto> Purchases { get; set; }

        public DbSet<RoleDto> Roles { get; set; }

        public DbSet<UserDto> Users { get; set; }

        public DbSet<WorkAreaDto> WorkAreas { get; set; }
    }
}
