using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserApplication.Data;
using UserApplication.Models;

namespace UserApplication.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserApplication.Data.UserApplicationContext _context;

        public CreateModel(UserApplication.Data.UserApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            var emptyUser = new User();

            if (await TryUpdateModelAsync<User>(
                emptyUser,
                "user",   // Prefix for form value.
                s => s.FirstName, s => s.LastName))
            {
                _context.Users.Add(emptyUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
