namespace CompanyManager.Business.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CompanyManager.Models;

    public interface IWorkAreaService : IService<WorkArea>
    {
        Task<IEnumerable<WorkArea>> GetByEnterpriseId(int id);
    }
}
