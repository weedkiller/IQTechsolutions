using System.Linq;
using System.Text;

namespace Filing.Core.Helpers
{
    /// <summary>
    /// Helper class used for image creation
    /// </summary>
    public class WriterHelper
    {
        /// <summary>
        /// The image formats that are used by the application
        /// </summary>
        public enum ImageFormat
        {
            Bmp,
            Jpeg,
            Gif,
            Tiff,
            Png,
            Unknown
        }

        /// <summary>
        /// Static method to get the image extention used
        /// </summary>
        /// <param name="bytes">The image in bytes</param>
        /// <returns>The format of the image</returns>
        public static ImageFormat GetImageFormat(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");                // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");               // GIF
            var png = new byte[] { 137, 80, 78, 71 };               // PNG
            var tiff = new byte[] { 73, 73, 42 };                   // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };                  // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 };           // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 };          // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.Bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.Gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.Png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.Tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.Tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.Jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.Jpeg;

            return ImageFormat.Unknown;
        }
    }
}
