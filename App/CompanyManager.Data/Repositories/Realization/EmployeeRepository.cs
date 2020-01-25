namespace CompanyManager.Data.Repositories.Realization
{
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.Interfaces;

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyManagerContext context)
            : base(context)
        {
        }
    }
}
