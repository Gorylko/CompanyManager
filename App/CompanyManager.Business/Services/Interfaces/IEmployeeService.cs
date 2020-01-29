namespace CompanyManager.Business.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CompanyManager.Models;

    public interface IEmployeeService : IService<Employee>
    {
        Task<IEnumerable<Employee>> GetByEnterpriseId(int id);
    }
}
