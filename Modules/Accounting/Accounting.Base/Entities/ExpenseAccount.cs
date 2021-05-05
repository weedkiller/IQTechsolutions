using Iqt.Base.BaseTypes;

namespace Accounting.Base.Entities
{
    public class ExpenseAccount : EntityBase
    {
        /// <summary>
        /// Gets or Sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the Description
        /// </summary>
        public string Description { get; set; }
    }
}
