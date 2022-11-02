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

namespace rds_test.Pages.Suggestions
{
    public class EditModel : PageModel
    {
        private readonly rds_test.Data.AppDbContext _context;

        public EditModel(rds_test.Data.AppDbContext context)
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

            var suggestion =  await _context.suggestion.FirstOrDefaultAsync(m => m.case_num == id);
            if (suggestion == null)
            {
                return NotFound();
            }
            Suggestion = suggestion;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
       public async Task<IActionResult> OnPostAsync(int id)
        {
        var emptySuggestion = await _context.suggestion.FindAsync(id);

        if (emptySuggestion == null) 
        {
            return NotFound();
        }

        await TryUpdateModelAsync<Suggestion>(
            emptySuggestion,
            "suggestion",
            m => m.title, m => m.description);
        
            await _context.SaveChangesAsync();
            return RedirectToPage("./Details", new {id = id});
        }
}
}
