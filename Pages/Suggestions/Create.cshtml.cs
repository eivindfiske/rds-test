using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages.Suggestions
{
    public class CreateModel : PageModel
    {
        private readonly rds_test.Data.ApplicationContext _context;

        public CreateModel(rds_test.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Suggestion Suggestion { get; set; } = default!;
        [BindProperty]
        public Participants Participants { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            var entry = _context.Add(new Suggestion());
            var parEntry = _context.Add(new Participants());


            entry.CurrentValues.SetValues(Suggestion);
            parEntry.CurrentValues.SetValues(Participants);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
