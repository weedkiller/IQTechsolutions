namespace Iqt.Base.Models
{
    public class CropModel
    {
        public string OriginalImageUrl { get; set; }

        public string CropImageUrl { get; set; }

        public int MinWidth { get; set; } = 600;
        public int MinHeight { get; set; } = 400;

        public string PreviewClass { get; set; } = "previewd";
        public string UploadProperty { get; set; } = "CoverUpload";

        public string XTag { get; set; } = "CoverCropSettings_X";
        public string YTag { get; set; } = "CoverCropSettings_Y";
        public string WidthTag { get; set; } = "CoverCropSettings_Width";
        public string HeightTag { get; set; } = "CoverCropSettings_Height";
        public string RotateTag { get; set; } = "CoverCropSettings_Rotate";
        public string ScaleXTag { get; set; } = "CoverCropSettings_ScaleX";
        public string ScaleYTag { get; set; } = "CoverCropSettings_ScaleY";


    }
}
