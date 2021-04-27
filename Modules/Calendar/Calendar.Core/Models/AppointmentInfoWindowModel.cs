using System;

namespace Calendar.Core.Models
{
    public class AppointmentInfoWindowModel
    {
        public string Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public int TaskCount { get; set; }
    }
}
