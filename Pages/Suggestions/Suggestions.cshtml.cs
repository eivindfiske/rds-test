using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test.Models;
using rds_test.Data;

namespace rds_test.Pages.Suggestions
{
    public class SuggestionModel : PageModel
    {
        private readonly AppDbContext _context;

        public SuggestionModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Suggestion> suggestions { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        {
            
            suggestions = await _context.suggestion.ToListAsync();
            return Page();
             
        }

        [BindProperty]
        public Suggestion suggestion { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var entry = _context.Add(new Suggestion());
            entry.CurrentValues.SetValues(suggestion);
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Suggestions");
        }
    }
}