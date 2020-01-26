namespace CompanyManager.Business.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IService<T>
    {
        Task<int> AddAsync(T entity);

        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAll();

        void Delete(int id);

        void Delete(T entity);

        void Update(T entity);
    }
}
