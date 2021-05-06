using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetProjekt.Data;
using AspNetProjekt.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetProjekt.Pages.Organizer
{
    public class CheckEventsModel : PageModel 
    {
        private readonly AspNetProjekt.Data.EventDbContext _context;
        private readonly userManager<MyUser> _userManager;

        public CheckEventsModel(AspNetProjekt.Data.EventDbContext context, UserManager<MyUser> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }

        public IList<Events> Events { get;set; }

        public async Task OnGetAsync() // Gör så den hämtar id från den som är inloggad, titta på "MyEvents" sidan.
        {
            Events = await _context.Event.ToListAsync();
        }
    }
}
