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

        
        public void OnGet()
        {

        }

        [BindProperty]
        public Suggestion suggestion { get; set; }

        [HttpPost]

        public async Task<IActionResult> OnPostAsync()
        {
            await _context.Database.OpenConnectionAsync();
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
           if (suggestion != null) 
            {
                _context.suggestion.Add(suggestion);
            }
            await _context.SaveChangesAsync();

            await _context.Database.CloseConnectionAsync();

            return RedirectToPage("./Suggestions");
        }
    }
}