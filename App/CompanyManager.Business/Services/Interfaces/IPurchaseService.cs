namespace CompanyManager.Business.Services.Interfaces
{
    using CompanyManager.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPurchaseService : IService<Purchase>
    {
        Task<IEnumerable<Purchase>> GetByEnterpriseId(int id);
    }
}
