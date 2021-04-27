using System.Collections.Generic;

namespace ExcelImportClient.Entities
{
    /// <summary>
    /// Represents an imported Excel Workbook
    /// </summary>
    public class ExcelWorkbook
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="workbookName">The name of the workbook</param>
        /// <param name="fileName">The name of the imported file</param>
        /// <param name="filePath">The path to the original imported file</param>
        public ExcelWorkbook(string workbookName, string fileName, string filePath)
        {
            Name = workbookName;
            FileName = fileName;
            FilePath = filePath;
        }

        /// <summary>
        /// Gets or sets the name of the workbook
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the file that was imported
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The full path to the original file
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// The collection of <see cref="ExcelSheet"/> that belong to this Workbook
        /// </summary>
        public ICollection<ExcelSheet> Sheets { get; set; } = new List<ExcelSheet>();
    }
}
