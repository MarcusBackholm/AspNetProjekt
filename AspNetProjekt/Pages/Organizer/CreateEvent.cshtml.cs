using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetProjekt.Data;
using AspNetProjekt.Models;

namespace AspNetProjekt.Pages.Organizer
{
    public class CreateEventModel : PageModel
    {
        private readonly AspNetProjekt.Data.EventDbContext _context;

        public CreateEventModel(AspNetProjekt.Data.EventDbContext context)
        {
            _context = context;
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
