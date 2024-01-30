using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserApplication.Data;
using UserApplication.Models;

namespace UserApplication.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly UserApplication.Data.UserApplicationContext _context;

        public DetailsModel(UserApplication.Data.UserApplicationContext context)
        {
            _context = context;
        }

      public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            User = await _context.Users
       .Include(p => p.Permissions)
       .ThenInclude(g => g.Group)
       .AsNoTracking()
       .FirstOrDefaultAsync(m => m.ID == id);
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
