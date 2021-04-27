namespace Filing.Base.Entities
{
    /// <summary>
    /// The crop image settings
    /// </summary>
    public class CropSettings
    {
        /// <summary>
        /// Gets or Sets the X-Coordinate for the top left corner
        /// </summary>
        public string X { get; set; } = "0";

        /// <summary>
        /// Gets or Sets the Y-Coordinate for the top left corner
        /// </summary>
        public string Y { get; set; } = "0";

        /// <summary>
        /// Gets or Sets the width of the image
        /// </summary>
        public string Width { get; set; } = "0";

        /// <summary>
        /// Gets or Sets the height of the image
        /// </summary>
        public string Height { get; set; } = "0";

        /// <summary>
        /// Gets or Sets the degree of the image rotation
        /// </summary>
        public string Rotate { get; set; } = "0";

        /// <summary>
        /// Gets of sets the X-scale starting point
        /// </summary>
        public string ScaleX { get; set; } = "0";

        /// <summary>
        /// Gets of sets the Y-scale starting point
        /// </summary>
        public string ScaleY { get; set; } = "0";
    }
}
