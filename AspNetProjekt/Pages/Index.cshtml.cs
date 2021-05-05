using AspNetProjekt.Data;
using AspNetProjekt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetProjekt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(
            ILogger<IndexModel> logger,
            EventDbContext context,
            UserManager<MyUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task OnGetAsync(bool? resetDb)
        {
            if (resetDb ?? false)
            {
                await _context.resetDb(_userManager, _roleManager);
            }
        }
    }
}
