namespace CompanyManager.Data.Repositories.GenericRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        TEntity GetById(object id);

        TEntity GetSingle(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] navigationProperties);

        IQueryable<TSubEntity> Get<TSubEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] navigationProperties)
            where TSubEntity : TEntity;

        IQueryable<TEntity> GetAll();

        void Load<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> navigationProperty)
            where TProperty : class;

        void Load<TCollection>(TEntity entity, Expression<Func<TEntity, ICollection<TCollection>>> navigationProperty)
            where TCollection : class;

        void Update(TEntity entity);

        void PartialUpdate(TEntity entity, object updatedEntity);

        void Delete(object id);

        void Delete(TEntity entity);

        void Delete(ICollection<TEntity> entities);

        Task<TEntity> GetByIdAsync(object id);
    }
}
