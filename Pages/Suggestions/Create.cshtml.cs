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
<<<<<<< HEAD


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
=======
        [BindProperty]
        public Participants Participants {get; set;}
        
>>>>>>> a6a1f53ba731754683b8a628cbbd78221f871a2f
        public async Task<IActionResult> OnPostAsync()
        {

            var entry = _context.Add(new Suggestion());
            var parEntry = _context.Add(new Participants());
            
            
            entry.CurrentValues.SetValues(Suggestion);
<<<<<<< HEAD

=======
            parEntry.CurrentValues.SetValues(Participants);
            
>>>>>>> a6a1f53ba731754683b8a628cbbd78221f871a2f
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
