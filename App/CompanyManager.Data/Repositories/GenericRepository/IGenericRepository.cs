namespace CompanyManager.Data.Repositories.GenericRepository
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);

        TEntity GetById(object id);

        Task<TEntity> GetByIdAsync(object id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);
    }
}
