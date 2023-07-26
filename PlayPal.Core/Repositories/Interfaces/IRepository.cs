using PlayPal.Data.Models.Interfaces;
using System.Linq.Expressions;

namespace PlayPal.Core.Repositories.Interfaces
{
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All<T>() where T : IDeletable;

        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : IDeletable;

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadonly<T>() where T : IDeletable;

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : IDeletable;

        /// <summary>
        /// Gets specific record from database by primary key
        /// </summary>
        /// <param name="id">record identificator</param>
        /// <returns>Single record</returns>
        Task<T> GetByIdAsync<T>(Guid id) where T : IDeletable;

        /// <summary>
        /// Adds entity to the database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        Task AddAsync<T>(T entity) where T : IDeletable;

        /// <summary>
        /// Ads collection of entities to the database
        /// </summary>
        /// <param name="entities">Enumerable list of entities</param>
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : IDeletable;

        /// <summary>
        /// Updates a record in database
        /// </summary>
        /// <param name="entity">Entity for record to be updated</param>
        Task Update<T>(T entity) where T : IDeletable;

        /// <summary>
        /// Updates set of records in the database
        /// </summary>
        /// <param name="entities">Enumerable collection of entities to be updated</param>
        void UpdateRange<T>(IEnumerable<T> entities) where T : IDeletable;

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <param name="id">Identificator of record to be deleted</param>
        Task DeleteAsync<T>(Guid id) where T : IDeletable;

        void DeleteRange<T>(IEnumerable<T> entities) where T : IDeletable;

        void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : IDeletable;

        /// <summary>
        /// Saves all made changes in trasaction
        /// </summary>
        /// <returns>Error code</returns>
        Task<int> SaveChangesAsync();

        Task HardDeleteAsync<T>(Guid id) where T : class;

        void HardDeleteAsync<T>(Func<T, bool> deleteCondition)
            where T : class;
    }
}
