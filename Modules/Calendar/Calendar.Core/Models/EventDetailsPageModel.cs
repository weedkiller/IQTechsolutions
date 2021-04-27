using System.Collections.Generic;
using Calendar.Base.Entities;
using Iqt.Base.Models;

namespace Calendar.Core.Models
{
    public class EventDetailsPageModel : DetailsModelBase<Event>
    {
        #region Constructors

        public EventDetailsPageModel(Event entity) : base(entity)
        {
        }

        #endregion

        public List<Event> FeaturedeEvents { get; set; } = new List<Event>();

        ///// <summary>
        ///// A review to leave on the model
        ///// </summary>
        //public ReviewModel Comment { get; set; }
    }
}
