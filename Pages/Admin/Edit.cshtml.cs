using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using rds_test.Data;
using rds_test.Models;



namespace rds_test.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationContext _context;

        public EditModel(ApplicationContext context)
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
            ApplicationUser = applicationUsers;
            ViewData["team"] = new SelectList(_context.dept, "team", "team");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ApplicationUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpExists(ApplicationUser.emp_num))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmpExists(string? id)
        {
            return (_context.applicationUsers?.Any(e => e.emp_num == id)).GetValueOrDefault();
        }
    }
}
