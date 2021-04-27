using System.Collections.Generic;
using Education.Base.Entities;
using Iqt.Base.Models;

namespace Education.Core.Models
{
    /// <summary>
    /// The base <see cref="Module"/> index model
    /// </summary>
    public class ModuleIndexModel : IndexModelBase<Module>
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="collection">The training section collection</param>
        /// <param name="size">The amount of objects on the page</param>
        /// <param name="page">The current page</param>
        /// <param name="sort">The sort order</param>
        public ModuleIndexModel(ICollection<Module> collection, int? size = null, int? page = null, int? sort = null) : base(collection, size, page, sort)
        {
        }
    }
}
