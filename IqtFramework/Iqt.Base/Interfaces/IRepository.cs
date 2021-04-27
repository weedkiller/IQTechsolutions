using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Iqt.Base.Interfaces
{
    /// <summary>
    /// The generic repository used by the repository manager
    /// </summary>
    /// <typeparam name="TEntity">The entity of the repository</typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntityBase
    {
        /// <summary>
        /// The Enumerator that iterates of a collection
        /// </summary>
        /// <returns>The enumerator of the collection</returns>
        IEnumerator GetEnumerator();

        /// <summary>
        /// The data context of the Repository
        /// </summary>
        DbContext DbContext { get; set; }

        /// <summary>
        /// The dataset in the Repository
        /// </summary>
        DbSet<TEntity> DbSet { get; set; }

        /// <summary>
        /// Tries to find the specific TEntity
        /// </summary>
        /// <param name="id">The identity of the TEntity to be found</param>
        /// <param name="predicate"></param>
        /// <returns>The TEntity that is found or null for nothing</returns>
        TEntity Find(object id, Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// The asynchronous method to find a specific TEntity
        /// </summary>
        /// <param name="id">The identity of the TEntity to be found</param>
        /// <param name="predicate">The predicate used for the where function</param>
        /// <returns>The TEntity that is found or null for nothing</returns>
        Task<TEntity> FindAsync(object id, Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Tries to find the specific TEntity
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties">An array of all the properties to be included</param>
        /// <returns>The TEntity that is found or null for nothing</returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Tries to find the specific TEntity
        /// </summary>
        /// <param name="includeProperties">An array of all the properties to be included</param>
        /// <returns>The TEntity that is found or null for nothing</returns>
        TEntity FirstOrDefault(params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// The asynchronous method to find a specific TEntity
        /// </summary>
        /// <param name="includeProperties">An array of all the properties to be included</param>
        /// <returns>The TEntity that is found or null for nothing</returns>
        Task<TEntity> FirstOrDefaultAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// The asynchronous method to find a specific TEntity
        /// </summary>
        /// <param name="predicate">The condition of the query</param>
        /// <param name="includeProperties">An array of all the properties to be included</param>
        /// <returns>The TEntity that is found or null for nothing</returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// The method to get a specific entity
        /// </summary>
        /// <param name="id">The identity of the entity to be returned</param>
        /// <param name="predicate">The condition of the query</param>
        /// <param name="includeProperties">The child properties to be included in the query</param>
        /// <returns>a specific TEntity</returns>
        TEntity GetEntity(object id, Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// The method to get a specific entity
        /// </summary>
        /// <param name="id">The identity of the entity to be returned</param>
        /// <param name="includeProperties">The child properties to be included in the query</param>
        /// <returns>a specific TEntity</returns>
        TEntity GetEntity(object id, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// The asynchronous method to get a specific entity
        /// </summary>
        /// <param name="id">The identity of the entity to be returned</param>
        /// <param name="predicate">The condition of the query</param>
        /// <param name="includeProperties">The child properties to be included in the query</param>
        /// <returns>a specific TEntity</returns>
        Task<TEntity> GetEntityAsync(object id, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// The asynchronous method to get a specific entity
        /// </summary>
        /// <param name="id">The identity of the entity to be returned</param>
        /// <param name="includeProperties">The child properties to be included in the query</param>
        /// <returns>a specific TEntity</returns>
        Task<TEntity> GetEntityAsync(object id, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Method to get a list of all TEntity's
        /// </summary>
        /// <param name="predicate">The condition of the query</param>
        /// <param name="includeProperties">The child properties to be included in the query</param>
        /// <returns>Queryable of all TEntity</returns>
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Method to get a list of all TEntity's
        /// </summary>
        /// <param name="includeProperties">The child properties to be included in the query</param>
        /// <returns>Queryable of all TEntity</returns>
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Adds TEntity to the dataset
        /// </summary>
        /// <param name="entity">The entity to be added</param>
        void Add(TEntity entity);

        /// <summary>
        /// Updates the entity given
        /// </summary>
        /// <param name="entity">The enitty to update</param>
        void Update(TEntity entity);

        /// <summary>
        /// Removes specific entity from the dataset
        /// </summary>
        /// <param name="entity">The entity to be removed</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Removes specific entity from the dataset
        /// </summary>
        /// <param name="id">The identity of the entity to be removed</param>
        void Delete(string id);

        void Dispose();
        void Dispose(bool disposing);
    }
}
