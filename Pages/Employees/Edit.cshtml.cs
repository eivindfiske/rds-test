using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages_Employees
{
    public class EditModel : PageModel
    {
        private readonly rds_test.Data.AppDbContext _context;

        public EditModel(rds_test.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Emp Emp { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.emp == null)
            {
                return NotFound();
            }

            var emp =  await _context.emp.FirstOrDefaultAsync(m => m.emp_num == id);
            if (emp == null)
            {
                return NotFound();
            }
            Emp = emp;
           ViewData["team"] = new SelectList(_context.dept, "team", "team");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Emp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpExists(Emp.emp_num))
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

        private bool EmpExists(int id)
        {
          return (_context.emp?.Any(e => e.emp_num == id)).GetValueOrDefault();
        }
    }
}
