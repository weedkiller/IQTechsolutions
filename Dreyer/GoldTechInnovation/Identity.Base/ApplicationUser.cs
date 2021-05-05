using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Base
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserInfo = new UserInfo();
        }

       public UserInfo UserInfo { get; set; }
    }




}
