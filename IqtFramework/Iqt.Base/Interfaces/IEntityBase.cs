using System;

namespace Iqt.Base.Interfaces
{
    /// <summary>
    /// Base class for any entity that we will create
    /// </summary>
    public interface IEntityBase
    {
        /// <summary>
        /// Identity Guid as string
        /// </summary>
        string Id { get; set; }

        /// <summary>
        ///  Display Index of Entity
        /// </summary>
        int? DisplayIndex { get; set; }

        /// <summary>
        /// Name of the entity that created the object
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Date the object was created
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// Name of the entity that modified the object
        /// </summary>
        string ModifiedBy { get; set; }

        /// <summary>
        /// Date the object was modified
        /// </summary>
        DateTime? Modified { get; set; }

        /// <summary>
        /// Method used to get the entity that is creating/modifying the object
        /// </summary>
        /// <param name="identity">identity of entity</param>
        /// <returns></returns>
        string IdentityCreatingOrModifying(string identity);

        /// <summary>
        /// The method to set the creation of a object
        /// </summary>
        void SetCreation(string identity = null);

        /// <summary>
        /// Set the
        /// </summary>
        void SetModification(string identity = null);
    }
}
