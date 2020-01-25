namespace CompanyManager.Data.Repositories.Interfaces
{
    using System.Linq;

    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);

        TEntity GetById(object id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);
    }
}
