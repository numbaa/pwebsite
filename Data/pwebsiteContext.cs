using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pwebsite.Models;

namespace pwebsite.Data
{
    public class pwebsiteContext : DbContext
    {
        public pwebsiteContext (DbContextOptions<pwebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<pwebsite.Models.Summary> Summary { get; set; }
    }
}
