using System.ComponentModel.DataAnnotations;
namespace TextEditor.Models
{
    public class TextEditorViewModel
    {
        [RichTextEditor.Models.AllowHtml]
        [Display(Name = "Message")]
        public string Message
        {
            get;
            set;
        }
    }
}