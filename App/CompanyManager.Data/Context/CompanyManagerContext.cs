namespace CompanyManager.Data.Context
{
    using Microsoft.EntityFrameworkCore;

    public class CompanyManagerContext : DbContext
    {
        public CompanyManagerContext(DbContextOptions<CompanyManagerContext> options)
                : base(options)
        {
        }
    }
}
