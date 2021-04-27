namespace ExcelImportClient.Entities
{
    /// <summary>
    /// Represents an imported excel Cell
    /// </summary>
    public class ExcelCell

    {
    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="name">The name of the column</param>
    /// <param name="value">The column value</param>
    public ExcelCell(string name, string value)
    {
        Name = name;
        Value = value;
    }

    /// <summary>
    /// Gets or sets the name of the cell
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the cell value
    /// </summary>
    public string Value { get; set; }
    }
}
