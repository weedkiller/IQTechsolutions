using Microsoft.AspNetCore.Identity;

namespace DuPlessisLegal.Web.Site.Areas.Identity.Data
{
    public class CellNumber : IdentityUser
    {
        public string CellNr { get; set; }

    }
}