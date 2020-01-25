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

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Enterprise> Enterprises { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<WorkArea> WorkAreas { get; set; }
    }
}
