using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Iqt.Base.Interfaces
{
    /// <summary>
    /// The repository manager used by the application
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// The DataContext used by the Repository Manager
        /// </summary>
        DbContext Context { get; }

        /// <summary>
        /// The Repository of the Repository Manager
        /// </summary>
        /// <typeparam name="TEntity">The Repository Entity</typeparam>
        /// <returns></returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntityBase;

        /// <summary>
        /// Save the changes to the database
        /// </summary>
        void Save();

        /// <summary>
        /// Save the changes to the database asyncronously
        /// </summary>
        /// <returns></returns>
        Task SaveAsync(CancellationToken cancellationToken = new CancellationToken());

        /// <summary>
        /// Reset the current repository to its orignal state
        /// </summary>
        void Reset();

        /// <summary>
        /// Reset the repository manager to its original state
        /// </summary>
        void ResetAll();

        /// <summary>
        /// Test to check if the repository manager has pending changes
        /// </summary>
        /// <returns>bool to indicate if changes are pending</returns>
        bool HasChanges();

        /// <summary>
        /// Method to dispose of the manager
        /// </summary>
        void Dispose();

        /// <summary>
        /// Method to dispose of the manager
        /// </summary>
        /// <param name="disposing">Flag set the disposing state</param>
        void Dispose(bool disposing);
    }
}
