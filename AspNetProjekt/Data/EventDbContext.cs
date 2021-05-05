using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetProjekt.Models;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspNetProjekt.Data
{
    public class  EventDbContext : IdentityDbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetProjekt.Models.Events> Event { get; set; }
    }
}
