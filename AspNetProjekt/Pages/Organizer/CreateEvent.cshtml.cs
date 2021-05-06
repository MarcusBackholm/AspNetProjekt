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

namespace AspNetProjekt.Pages.Organizer
{
    public class CreateEventModel : PageModel
    {
        private readonly EventDbContext _context;
        private readonly userManager<MyUser> _userManager;

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

            _context.Event.Add(Events);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
