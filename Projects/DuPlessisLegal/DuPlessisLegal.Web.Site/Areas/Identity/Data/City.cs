using Microsoft.AspNetCore.Identity;

namespace DuPlessisLegal.Web.Site.Areas.Identity.Data
{
    public class City : IdentityUser
    {
        public string UserCity { get; set; }
    }
}