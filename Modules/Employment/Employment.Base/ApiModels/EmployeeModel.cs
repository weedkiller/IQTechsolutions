﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Employment.Base.ApiModels
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Designation { get; set; }
        public string Email { get; set; }
        public string ContactNr { get; set; }

        public string Address { get; set; }

        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }
    }
}
