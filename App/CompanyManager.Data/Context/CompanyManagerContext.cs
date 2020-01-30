namespace CompanyManager.Data.Context
{
    using System.Linq;
    using CompanyManager.Data.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    public class CompanyManagerContext : DbContext
    {
        public CompanyManagerContext(DbContextOptions<CompanyManagerContext> options)
                : base(options)
        {
            Database.EnsureCreated();
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

        public virtual IQueryable<EmployeeDto> EmployeeByEnterpriseId(object enterpriseId)
        {
            SqlParameter enterpriseIdParameter = new SqlParameter("@enterpriseId", enterpriseId);

            return Set<EmployeeDto>().FromSqlRaw("EXEC [dbo].[sp_select_employees_by_enterprise_id] @enterpriseId", enterpriseIdParameter);
        }

        public virtual IQueryable<PurchaseDto> PurchasesByEnterpriseId(object enterpriseId)
        {
            SqlParameter enterpriseIdParameter = new SqlParameter("@enterpriseId", enterpriseId);

            return Set<PurchaseDto>().FromSqlRaw("EXEC [dbo].[sp_select_purchases_by_enterprise_id] @enterpriseId", enterpriseIdParameter);
        }

        public virtual IQueryable<WorkAreaDto> WorkAreasByEnterpriseId(object enterpriseId)
        {
            SqlParameter enterpriseIdParameter = new SqlParameter("@enterpriseId", enterpriseId);

            return Set<WorkAreaDto>().FromSqlRaw("EXEC [dbo].[sp_select_areas_by_enterprise_id] @enterpriseId", enterpriseIdParameter);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersToEnterprisesDto>()
                .HasKey(x => new { x.UserId, x.EnterpriseId });

            modelBuilder.Entity<RolesToPermissionDto>()
                .HasKey(x => new { x.RoleId, x.PermissionId });
        }
    }
}
