using System;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;

namespace Calendar.Base.Entities
{
    public class EventDay : EntityBase
    {
        public DateTime DateTime { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        [ForeignKey("EventRegistration")]
        public string EventRegistrationId { get; set; }
        public EventRegistration EventRegistration { get; set; }

        [ForeignKey("Event")]
        public string EventId { get; set; }
        public Event Event { get; set; }
    }
}
