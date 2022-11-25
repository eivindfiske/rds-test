using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using rds_test.Data;
using rds_test.Models;



namespace rds_test.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationContext _context;

        public DeleteModel(ApplicationContext context)
        {
            _context = context;
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
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null || _context.applicationUsers == null)
            {
                return NotFound();
            }
            var applicationUsers = await _context.applicationUsers.FindAsync(id);

            if (applicationUsers != null)
            {
                ApplicationUser = applicationUsers;
                _context.applicationUsers.Remove(ApplicationUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
