namespace CompanyManager.Data.Context
{
    using CompanyManager.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

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

        public DbSet<UserInformationDto> UserInformation { get; set; }

        public DbSet<UsersToEnterprisesDto> UsersToEnterprises { get; set; }

        public DbSet<RolesToPermissionDto> RolesToPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersToEnterprisesDto>()
                .HasKey(x => new { x.EnterpriseId, x.UserId });

            modelBuilder.Entity<RolesToPermissionDto>()
                .HasKey(x => new { x.RoleId, x.PermissionId });
        }

        public virtual IQueryable<EmployeeByEnterpriseIdResult> EmployeeByEnterpriseId()
        {
            return this.Query<EmployeeByEnterpriseIdResult>().FromSql("sp_select_employees_by_enterprise_id").AsQueryable();
        }
    }
}
