namespace CompanyManager.Data.Repositories.GenericRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using CompanyManager.Data.Context;
    using Microsoft.EntityFrameworkCore;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly CompanyManagerContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(CompanyManagerContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> @where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = navigationProperties
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(_dbSet, (current, navigationProperty)
                => current.Include(navigationProperty));

            return dbQuery.FirstOrDefault();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> @where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = navigationProperties
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(_dbSet, (current, navigationProperty)
                => current.Include(navigationProperty));

            return await dbQuery.FirstOrDefaultAsync(where);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = _dbSet;

            if (filter != null)
            {
                dbQuery = dbQuery.Where(filter);
            }

            return navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));
        }

        public IQueryable<TSubEntity> Get<TSubEntity>(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] navigationProperties)
            where TSubEntity : TEntity
        {
            return Get(filter, navigationProperties).OfType<TSubEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public void Load<TCollection>(TEntity entity, Expression<Func<TEntity, ICollection<TCollection>>> navigationProperty)
            where TCollection : class
        {
        }

        public void Load<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> navigationProperty)
            where TProperty : class
        {
            _context.Entry(entity).Reference(navigationProperty).Load();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void PartialUpdate(TEntity entity, object updatedEntity)
        {
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
        }

        public void Delete(object id)
        {
            TEntity entity = _dbSet.Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public void Delete(ICollection<TEntity> entities)
        {
            foreach (var entity in entities.Where(entity => _context.Entry(entity).State == EntityState.Detached))
            {
                _dbSet.Attach(entity);
            }

            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
