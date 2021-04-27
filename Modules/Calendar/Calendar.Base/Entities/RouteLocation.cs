using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;
using Iqt.Base.Entities;

namespace Calendar.Base.Entities
{
    public class RouteLocation : EntityBase
    {
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [ForeignKey(nameof(Route))]
        public string RouteId { get; set; }
        public Route Route { get; set; }


        /// <summary>
        /// The location of the task
        /// </summary>
        public Address<RouteLocation> Address { get; set; }

        public ICollection<EntityTask<RouteLocation>> Tasks { get; set; } = new List<EntityTask<RouteLocation>>();
    }
}
