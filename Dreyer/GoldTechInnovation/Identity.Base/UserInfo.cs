using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Identity.Base
{
    public class UserInfo
    {
        
        [DisplayName("First Name"), Column("FirstName")]
        public string FirstName { get; set; }

       
        [DisplayName("Last Name"), Column("LastName")]
        public string LastName { get; set; }
    }
}
