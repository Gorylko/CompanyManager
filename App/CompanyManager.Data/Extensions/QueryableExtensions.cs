namespace CompanyManager.Data.Extensions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public static class QueryableExtensions
    {
        public static Task<TSource> GetSingleAsync<TSource>([NotNullAttribute] this IQueryable<TSource> source, CancellationToken cancellationToken = default)
        {
            return source.SingleAsync(cancellationToken);
        }

        public static Task<List<TSource>> GetListAsync<TSource>([NotNullAttribute] this IQueryable<TSource> source, CancellationToken cancellationToken = default)
        {
            return source.ToListAsync(cancellationToken);
        }

        public static IQueryable<TEntity> GetNoTracking<TEntity>([NotNullAttribute] this IQueryable<TEntity> source)
            where TEntity : class
        {
            return source.AsNoTracking();
        }
    }
}
