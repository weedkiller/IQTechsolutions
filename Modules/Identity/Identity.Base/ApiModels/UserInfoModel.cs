using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Base.ApiModels
{
    public class UserInfoModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNr { get; set; }
        public string Address { get; set; }

        public int PostCount { get; set; }
        public int Following { get; set; }
        public int Followers { get; set; }
    }
}
