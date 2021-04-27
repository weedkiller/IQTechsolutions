using Iqt.Calender.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projects.Core.Models
{
    public class LinkProjectModel : TaskModel
    {
        public SelectList Projects { get; set; }

        public string SelectedProject { get; set; }
            
    }
}
