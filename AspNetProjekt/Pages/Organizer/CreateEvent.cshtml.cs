using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetProjekt.Data;
using AspNetProjekt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AspNetProjekt.Pages.Organizer
{
    [Authorize (Roles = "organizer")] // Gör så att bara organizer har behörighet.
    public class CreateEventModel : PageModel
    {
        private readonly EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;

        public CreateEventModel(EventDbContext context, UserManager<MyUser> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Events Events { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() // Gör som på "JoinEventsidan" 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var GetId = _userManager.GetUserId(User);

            var user = await _context.MyUser
                .Where(u => u.Id == GetId)
                .Include(u => u.HostedEvents)
                .FirstOrDefaultAsync();

            user.HostedEvents.Add(Events);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
