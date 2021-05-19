using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Calendar.Base.Enums;
using Filing.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Entities;

namespace Calendar.Base.Entities
{
    public class Event : ImageFileCollection<Event>
    {
        #region Properties

        /// <summary>
        /// The recurrence rule
        /// </summary>
        public Recurrence RecurrenceRule { get; set; } = Recurrence.None;

        /// <summary>
        /// The heading
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The start date
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now.Date;

        /// <summary>
        /// The start time
        /// </summary>
        public TimeSpan StartTime { get; set; } = DateTime.Now.TimeOfDay;

        /// <summary>
        /// The end date
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now.Date;

        /// <summary>
        /// The start time
        /// </summary>
        public TimeSpan EndTime { get; set; } = new TimeSpan(0, 23, 59, 59);

        /// <summary>
        /// Flag to see if product is featured
        /// </summary>
        [DisplayName("Featured")]
        public bool Featured { get; set; }

        #endregion

        #region Relationships

        #region Location

        [ForeignKey("Location"), DisplayName("Location")]
        public  string LocationId { get; set; }
        public Address<Event> Location { get; set; }

        #endregion

        #region Video

        /// <summary>
        /// The video
        /// </summary>
        [DisplayName("Video")]
        public ICollection<Video<Event>> EventVideos { get; set; }

        #endregion

        #endregion

        #region Collections

        /// <summary>
        /// The contacts for this event
        /// </summary>
        public ICollection<ContactNumber<Event>> Contacts { get; set; } = new List<ContactNumber<Event>>();

        /// <summary>
        /// The Categories for this event
        /// </summary>
        public ICollection<EntityCategory<Event>> Categories { get; set; } = new List<EntityCategory<Event>>();

        /// <summary>
        /// The webtags for this Event
        /// </summary>
        public string Tags { get; set; }
        ///// <summary>
        ///// The reviews for this <see cref="Event"/>
        ///// </summary>
        //public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        /// <summary>
        /// The reviews for this <see cref="Event"/>
        /// </summary>
        public virtual ICollection<EventRegistration> Registrations { get; set; } = new List<EventRegistration>();
        public virtual ICollection<EventDay> EventDays { get; set; } = new List<EventDay>();

        #endregion

    }
}
