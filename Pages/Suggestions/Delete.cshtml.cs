using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages.Suggestions
{
    public class DeleteModel : PageModel
    {
        private readonly rds_test.Data.AppDbContext _context;

        public DeleteModel(rds_test.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Suggestion Suggestion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.suggestion == null)
            {
                return NotFound();
            }

            var suggestion = await _context.suggestion.FirstOrDefaultAsync(m => m.case_num == id);

            if (suggestion == null)
            {
                return NotFound();
            }
            else 
            {
                Suggestion = suggestion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.suggestion == null)
            {
                return NotFound();
            }
            var suggestion = await _context.suggestion.FindAsync(id);

            if (suggestion != null)
            {
                Suggestion = suggestion;
                _context.suggestion.Remove(Suggestion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
