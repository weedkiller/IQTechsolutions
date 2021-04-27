using System.Collections.Generic;

namespace ExcelImportClient.Entities
{
    /// <summary>
    /// Represents an imported excel row
    /// </summary>
    public class ExcelRow
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="name">The name of the row</param>
        public ExcelRow(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name of the Excel row
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the column collection of the row
        /// </summary>
        public virtual ICollection<ExcelCell> Cells { get; set; } = new List<ExcelCell>();
    }
}
