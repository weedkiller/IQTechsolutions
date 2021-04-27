using System.ComponentModel.DataAnnotations;

namespace Iqt.Calender.Models
{
    public class TaskModel
    {
        public string EntityId { get; set; }
        public string ParentId { get; set; }


        public string Heading { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }

    
}
