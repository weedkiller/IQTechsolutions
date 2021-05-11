using System.ComponentModel.DataAnnotations;
namespace TextEditor.Models
{
    public class TextEditorViewModel
    {
      
        [Display(Name = "Message")]
        public string Message
        {
            get;
            set;
        }
    }
}