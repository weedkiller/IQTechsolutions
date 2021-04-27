using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Metsi.Web.Site.Admin.Areas.Calendar.Models
{
    public class AppointmentJsonModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("allDay")]
        public bool AllDay { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
