using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Iqt.Base.BaseTypes;

namespace Calendar.Base.Entities
{
    public class Route : EntityBase
    {
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ICollection<RouteLocation> RouteLocations { get; set; } = new List<RouteLocation>();
    }
}
