namespace CompanyManager.Business.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CompanyManager.Data.UnitOfWork;

    public interface IService<T>
        where T : class
    {
        //Task<int> AddAsync(T entity);

        //Task<T> GetByIdAsync(int id);

        ////IEnumerable<T> GetAll();

        //// DLT
        //// void Delete(int id);

        //void Delete(T entity);

        //void Update(T entity);

        // New async functional

        Task<T> GetById(int id);

        //Task<IEnumerable<T>> GetByEnterpriseId(int id);

        Task<IEnumerable<T>> GetAll();

        Task<int> Save(T model);

        Task<int> Update(T model);

        Task<object> Delete(int id);
    }
}
