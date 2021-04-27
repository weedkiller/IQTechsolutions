using Identity.Base.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoldTechInnovation.Web.DataStore
{
    public class GoldTechDbContext : IdentityDbContext<ApplicationUser>
    {
        public GoldTechDbContext(DbContextOptions<GoldTechDbContext> options)
            : base(options)
        {
        }
    }
}
