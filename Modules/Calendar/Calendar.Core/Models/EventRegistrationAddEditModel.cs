using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using Calendar.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Enums.Personal;
using Iqt.Base.Extensions;
using Iqt.Base.Models;

namespace Calendar.Core.Models
{
    public class EventRegistrationAddEditModel
    {
        #region Constructors

        public EventRegistrationAddEditModel() { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor with product parameter
        /// </summary>
        public EventRegistrationAddEditModel(string eventId, DateTime startDate, DateTime endDate, ICollection<EventDay> currentEventDays = null)
        {
            EventId = eventId;
            if (currentEventDays != null && currentEventDays.Any())
            {
                foreach (var item in currentEventDays)
                {
                    SelectedEventDates.Add(item.DateTime);
                }
            }

            var dates = DateTimeExtensions.GetDatesBetween(startDate, endDate);

            AddToAvailableEventDays(dates.OrderByDescending(c => c.Date).ToList());
        }

        private void AddToAvailableEventDays(IList<DateTime> list)
        {
            foreach (var item in list)
            {
                var checkboxModel = new CheckBoxSelectionModel<Category<Event>>(item.Date.ToString(CultureInfo.InvariantCulture), null, item.Date.ToString(CultureInfo.InvariantCulture), null, item.Date.ToLongDateString());

                if (SelectedEventDates.Any(c => c.Date == item.Date))
                        checkboxModel.IsSelected = true;

                AvailableEventDay.Add(checkboxModel);
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The identity of the parent event id
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// Title of the of the Registrar
        /// </summary>
        [DisplayName("Title")]
        public Title Title { get; set; }

        /// <summary>
        /// The firstname of the Registrar
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The lastname of the Registrar
        /// </summary>
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// The contact number of the Registrar
        /// </summary>
        [DisplayName("Contact Nr")]
        public string ContactNr { get; set; }

        /// <summary>
        /// The ammount of people that will be attending 
        /// </summary>
        [DisplayName("Attendees")]
        public int Attendees { get; set; }

        /// <summary>
        /// The email address of the Registrar
        /// </summary>
        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Any extra notes for the event manager
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public ICollection<DateTime> SelectedEventDates { get; set; } = new List<DateTime>();

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public List<CheckBoxSelectionModel<Category<Event>>> AvailableEventDay { get; set; } = new List<CheckBoxSelectionModel<Category<Event>>>();

        #endregion
    }
}
