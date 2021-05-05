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

namespace AspNetProjekt.Pages
{
    public class MyEventsModel : PageModel
    {
        private readonly AspNetProjekt.Data.EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;

        public MyEventsModel(AspNetProjekt.Data.EventDbContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Events> Events { get;set; }
        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            var userJoin = await _context.MyUser
              .Where(e => e.Id == userId)
              .Include(a => a.JoinedEvents)
              .FirstOrDefaultAsync();

            Events = userJoin.JoinedEvents;
        }
    }
}
