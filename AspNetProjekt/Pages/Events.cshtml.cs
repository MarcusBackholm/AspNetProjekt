using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetProjekt.Data;
using AspNetProjekt.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspNetProjekt.Pages
{
    public class EventsModel : PageModel
    {
        private readonly AspNetProjekt.Data.EventDbContext _context;

        public EventsModel(AspNetProjekt.Data.EventDbContext context)
        {
            _context = context;
        }

        public IList<Events> Events { get;set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Event.ToListAsync();
        }
    }
}
