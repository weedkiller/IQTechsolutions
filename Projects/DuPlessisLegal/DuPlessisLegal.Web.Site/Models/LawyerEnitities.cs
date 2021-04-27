using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuPlessisLegal.Web.Site.Models
{
    public class LawyerEnitities : DbContext
    {
        public DbSet<Lawyers> Lawyers { get; set; }
        public DbSet<Fields> Fields { get; set; }
    }
}
