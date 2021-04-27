using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.Interfaces;

namespace Iqt.Base.BaseTypes
{
    /// <inheritdoc />
    /// <summary>
    /// Base class for any entity that will be created
    /// </summary>
    public abstract class EntityBase : IEntityBase
    {
        #region Constructors

        /// <summary>
        /// Base Constructor
        /// </summary>
        protected EntityBase()
        {
            SetCreation();
        }

        /// <summary>
        /// Constructor with current entity already in memory
        /// </summary>
        /// <param name="baseEntity">entity to be loaded</param>
        protected EntityBase(EntityBase baseEntity)
        {
            Id = baseEntity.Id;
            SetCreation();
        }

        #endregion

        #region Properties

        /// <inheritdoc />
        /// <summary>
        /// Identity Guid as string
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, DisplayName("Id"), Column("Id")]
        public string Id { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///  Display Index of Entity
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None), Column("DisplayIndex")]
        public int? DisplayIndex { get; set; }

        #endregion

        #region Creation/Modification Members

        /// <inheritdoc />
        /// <summary>
        /// Name of the entity that created the object
        /// </summary>
        [DisplayName("Created By:")]
        public string CreatedBy { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Date the object was created
        /// </summary>
        [DisplayName("Created On:")]
        public DateTime Created { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Name of the entity that modified the object
        /// </summary>
        [DisplayName("Modified By:")]
        public string ModifiedBy { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Date the object was modified
        /// </summary>
        [DisplayName("Modified On:")]
        public DateTime? Modified { get; set; }

        /// <summary>
        /// The created date to string format
        /// </summary>
        public string CreatedDateString
        {
            get
            {
                return GetDateString(Created);
            }
        }

        /// <summary>
        /// The modified date to string format
        /// </summary>
        public string ModifiedDateString
        {
            get
            {
                if (Modified != null)
                {
                    return GetDateString(Modified.Value);
                }
                else return "";
            }
        }

        #region Methods

        /// <summary>
        /// Gets a date in a specific date string
        /// </summary>
        /// <param name="dateTime">The date to be converted</param>
        /// <returns></returns>
        public string GetDateString(DateTime dateTime)
        {
            if (dateTime.Date.Day == DateTime.Now.Day)
            {
                return "Today " + dateTime.ToLongDateString();
            }
            else if (dateTime.Date.AddDays(-1).Day == DateTime.Now.Day)
            {
                return "Yesterday " + dateTime.ToLongDateString();
            }
            return dateTime.ToLongDateString();
        }

        /// <inheritdoc />
        /// <summary>
        /// Method used to get the entity that is creating/modifying the object
        /// </summary>
        /// <param name="identity">identity of entity</param>
        /// <returns></returns>
        public string IdentityCreatingOrModifying(string identity)
        {
            return string.IsNullOrEmpty(identity) ? "Unknown User" : identity;
        }

        /// <inheritdoc />
        /// <summary>
        /// The method to set the creation of a object
        /// </summary>
        public void SetCreation(string identity = null)
        {
            CreatedBy = IdentityCreatingOrModifying(identity);
            Created = DateTime.Now;
        }

        /// <inheritdoc />
        /// <summary>
        /// The method to set the modification of a object
        /// </summary>
        public void SetModification(string identity = null)
        {
            ModifiedBy = IdentityCreatingOrModifying(identity);
            Modified = DateTime.Now;
        }

        #endregion

        #endregion
    }
}
