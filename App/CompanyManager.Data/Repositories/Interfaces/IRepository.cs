namespace CompanyManager.Data.Repositories.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> GetAll();

        T GetById(int id);

        void Save(T obj);

        void Update(T obj);

        void Delete(int id);
    }
}
