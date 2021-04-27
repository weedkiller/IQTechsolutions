using Calendar.Base.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Calendar.Core.Models
{
    public class AddExistingTaskModel
    {
        public SelectList ExistingTasks { get; set; }

        public string SelectedTask { get; set; }

        public RouteLocation RouteLocation { get; set; }
    }
}
