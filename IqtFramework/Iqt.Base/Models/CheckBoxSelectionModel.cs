using System.Collections.Generic;
using System.Linq;
using Iqt.Base.BaseTypes;

namespace Iqt.Base.Models
{
    /// <summary>
    /// The model used for selection of a entity in a list
    /// </summary>
    public class CheckBoxSelectionModel<T> where T : EntityBase
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CheckBoxSelectionModel() { }

        /// <summary>
        /// Parameter Constructor
        /// </summary>
        /// <param name="id">The identity of the category</param>
        /// <param name="parentIdentity">The identity of the parent checkbox selection</param>
        /// <param name="name">The name of the category</param>
        /// <param name="coverImage">The cover image of the category</param>
        /// <param name="description">The description of the category</param>
        public CheckBoxSelectionModel(string id, string parentIdentity, string name, string coverImage, string description)
        {
            Identity = id;
            ParentIdentity = parentIdentity;
            Name = name;
            CoverImage = coverImage;
            Description = description;
        }

        public CheckBoxSelectionModel(T entity)
        {
            Entity = entity;
        }

        #endregion

        public T Entity { get; set; }

        public bool HasChildSelection => ChildSelection.Any();

        /// <summary>
        /// The identity
        /// </summary>
        public string Identity { get; set; }

        public string ParentIdentity { get; set; }

        /// <summary>
        /// Flag to indicate whether this model is selected or not
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// The cover image
        /// </summary>
        public string CoverImage { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The sub-category list
        /// </summary>
        public List<CheckBoxSelectionModel<T>> ChildSelection { get; set; } = new List<CheckBoxSelectionModel<T>>();
    }
}
