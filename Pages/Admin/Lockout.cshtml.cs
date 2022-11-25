using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages.Admin
{
    public class LockoutModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationContext _context;

        public LockoutModel(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; } = default!;



        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || _context.applicationUsers == null)
            {
                return NotFound();
            }

            var applicationUsers = await _context.applicationUsers.FirstOrDefaultAsync(m => m.emp_num == id);


            if (applicationUsers == null)
            {
                return NotFound();
            }
            else
            {
                ApplicationUser = applicationUsers;
                applicationUsers.LockoutEnabled = true;
                applicationUsers.LockoutEnd = DateTime.UtcNow.AddYears(100);
                applicationUsers.Lockout = true;
                await _userManager.UpdateAsync(applicationUsers);

            }
            return Page();
        }
    }
}
