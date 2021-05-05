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
    public class JoineEventModel : PageModel
    {
        private readonly EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;

        public JoineEventModel(EventDbContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Events Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User); //När man är inloggad så joinar den inloggade usern ett event.
            var userJoin = await _context.MyUser
                .Where(e => e.Id == userId)
                .Include(a => a.JoinedEvents)
                .FirstOrDefaultAsync();

            userJoin.JoinedEvents.Add(Event);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}