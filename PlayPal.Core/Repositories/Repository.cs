using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Data;
using PlayPal.Data.Models.Interfaces;
using System.Linq.Expressions;

namespace PlayPal.Core.Repositories
{
    public class Repository : IRepository
    {
        /// <summary>
        /// Entity framework DB context holding connection information and properties
        /// and tracking entity states 
        /// </summary>
        private readonly PlayPalDbContext _context;

        public Repository(PlayPalDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Representation of table in database
        /// </summary>
        protected DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();
        }

        /// <summary>
        /// Adds entity to the database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        public async Task AddAsync<T>(T entity) where T : IDeletable
        {
            await DbSet<T>().AddAsync(entity);
            await SaveChangesAsync();
        }

        /// <summary>
        /// Ads collection of entities to the database
        /// </summary>
        /// <param name="entities">Enumerable list of entities</param>
        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : IDeletable
        {
            await DbSet<T>().AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        public IQueryable<T> All<T>() where T : IDeletable
        {
            return DbSet<T>()
                .Where(e => e.IsDeleted == false)
                .AsQueryable();
        }

        public IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : IDeletable
        {
            return this.DbSet<T>()
                .Where(e => e.IsDeleted == false)
                .Where(search)
                .AsQueryable();
        }

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        public IQueryable<T> AllReadonly<T>() where T : IDeletable
        {
            return this.DbSet<T>()
                .Where(e => e.IsDeleted)
                .AsQueryable()
                .AsNoTracking();
        }
        public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : IDeletable
        {
            return this.DbSet<T>()
                .Where(search)
                .AsQueryable()
                .AsNoTracking();
        }

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <param name="id">Identificator of record to be deleted</param>
        public async Task DeleteAsync<T>(object id) where T : IDeletable
        {
            T entity = await GetByIdAsync<T>(id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                await SaveChangesAsync();
            }
        }

        /// <summary>
        /// Disposing the context when it is not neede
        /// Don't have to call this method explicitely
        /// Leave it to the IoC container
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// Gets specific record from database by primary key
        /// </summary>
        /// <param name="id">record identificator</param>
        /// <returns>Single record</returns>
        public async Task<T> GetByIdAsync<T>(object id) where T : IDeletable
        {
            T entity = await DbSet<T>().FindAsync(id);

            if (entity?.IsDeleted ?? true)
            {
                return null;
            }

            return entity;
        }

        /// <summary>
        /// Saves all made changes in trasaction
        /// </summary>
        /// <returns>Error code</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a record in database
        /// </summary>
        /// <param name="entity">Entity for record to be updated</param>
        public async void Update<T>(T entity) where T : IDeletable
        {
            this.DbSet<T>().Update(entity);
            await SaveChangesAsync();
        }

        /// <summary>
        /// Updates set of records in the database
        /// </summary>
        /// <param name="entities">Enumerable collection of entities to be updated</param>
        public async void UpdateRange<T>(IEnumerable<T> entities) where T : IDeletable
        {
            this.DbSet<T>().UpdateRange(entities);
            await SaveChangesAsync();
        }

        /// <summary>
        /// Delete a set of records from the database
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="entities">Enumerable collection of entities to be deleted</param>
        public async void DeleteRange<T>(IEnumerable<T> entities) where T : IDeletable
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                Update<T>(entity);
            }
            await SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">he type of the entity</typeparam>
        /// <param name="deleteWhereClause">The condition for the delete</param>
        public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : IDeletable
        {
            var entities = All<T>(deleteWhereClause);
            DeleteRange<T>(entities);
        }

        public async Task HardDeleteAsync<T>(object id) 
            where T : class
        {
            T? entity = await DbSet<T>().FindAsync(id);

            if (entity != null)
            {
                DbSet<T>().Remove(entity);
            }
        }
    }
}
