using Microsoft.AspNetCore.Identity;

namespace DuPlessisLegal.Web.Site.Areas.Identity.Data
{
    public class Address : IdentityUser
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 {get;set;}
    }
}