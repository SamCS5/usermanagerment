using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserApplication.Data;
using UserApplication.Models;

namespace UserApplication.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly UserApplication.Data.UserApplicationContext _context;

        public EditModel(UserApplication.Data.UserApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var studentToUpdate = await _context.Users.FindAsync(id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<User>(
                studentToUpdate,
                "user",
                s => s.FirstName, s => s.LastName))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
        private bool UserExists(int id)
        {
          return _context.Users.Any(e => e.ID == id);
        }
    }
}
