using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages_Employees
{
    public class CreateModel : PageModel
    {
        private readonly rds_test.Data.AppDbContext _context;

        public CreateModel(rds_test.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["team"] = new SelectList(_context.dept, "team", "team");
            return Page();
        }

        [BindProperty]
        public Emp Emp { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var entry = _context.Add(new Emp());
            entry.CurrentValues.SetValues(Emp);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Employees/Index");
        }
    }
}
