using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetProjekt.Data;
using AspNetProjekt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetProjekt.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class AdminPropertiesModel : PageModel
    {
        private readonly EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminPropertiesModel(EventDbContext context, UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public List<MyUser> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.MyUser.ToListAsync();
        }

        public async Task OnPost(string? id)
        {
            var newrole = _context.MyUser.Where(a => a.Id == id).FirstOrDefault();
            if (!_userManager.IsInRoleAsync(newrole, "organizer").Result) // Om man inte är orhganizer så blir man det när man checkar i boxen.
            {
                await _userManager.AddToRoleAsync(newrole, "organizer");
                await _userManager.RemoveFromRoleAsync(newrole, "user");
                await _context.SaveChangesAsync();
            }
            else
            {
                await _userManager.AddToRoleAsync(newrole, "user");
                await _userManager.RemoveFromRoleAsync(newrole, "organizer");
                await _context.SaveChangesAsync();
            }
            await OnGetAsync();
        }
    }
}
