using System.Collections.Generic;

namespace ExcelImportClient.Entities
{
    /// <summary>
    /// An imported excel sheet
    /// </summary>
    public class ExcelSheet 
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="name">The name of the Sheet</param>
        public ExcelSheet(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name of the sheet
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the row collection
        /// </summary>
        public virtual ICollection<ExcelRow> Rows { get; set; } = new List<ExcelRow>();
    }
}
