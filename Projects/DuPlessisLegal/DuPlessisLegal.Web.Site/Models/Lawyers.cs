using System;
using System.Collections.Generic;

namespace DuPlessisLegal.Web.Site.Models
{
    public class Lawyers
    {
        public int LawyerID { get; set; }
        public string LawyerFirstName { get; set; }
        public string LawyerLastName { get; set; }
        public string LawyerEmail { get; set; }
        public string LawyerExpertise { get; set; }
    }

    public class Fields
    {
        public int FieldID { get; set; }
        public string FieldName { get; set; }
        public List<Lawyers> Experts { get; set; }
    }
}
