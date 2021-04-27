using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;

namespace Iqt.Base.Entities
{
    /// <summary>
    /// An element used to build an application form for a task, service, product, etc
    /// </summary>
    public class FormElement<T> : EntityBase
    {
        /// <summary>
        /// The element ui type
        /// </summary>
        public FormElementType ElementType { get; set; }

        /// <summary>
        /// The label of the element
        /// </summary>
        public string ElementName { get; set; }

        /// <summary>
        /// The required flag, is required when true
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// The task associated with this form element
        /// </summary>
        [ForeignKey(nameof(Entity))]
        public string EntityId { get; set; }
        public T Entity { get; set; }
    }

    /// <summary>
    /// The form element type for the UI
    /// </summary>
    public enum FormElementType
    {
        SingleLineText,
        MultiLineText,
        Number,
        Decimal,
        Image,
    }
}
