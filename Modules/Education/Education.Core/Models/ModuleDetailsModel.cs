using Education.Base.Entities;
using Iqt.Base.Models;

namespace Education.Core.Models
{
    /// <summary>
    /// The base <see cref="Module"/> details model
    /// </summary>
    public class ModuleDetailsModel : DetailsModelBase<Module>
    {
        /// <summary>
        /// The <see cref="Module"/> details model base
        /// </summary>
        /// <param name="entity">The <see cref="Module"/> that is featured by this model</param>
        public ModuleDetailsModel(Module entity) : base(entity)
        {
        }
    }
}
