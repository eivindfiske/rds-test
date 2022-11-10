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
        private readonly ApplicationContext _context;

        public CreateModel(ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<SelectListItem> empList { get; set; }
        // public string getUser {get; set;}
        
        public IActionResult OnGet()
        {
            // getUser = this.User.Identity.Name;

            empList = _context.applicationUsers.Select(a => new SelectListItem
            {
                Value = a.emp_num.ToString(),
                Text = a.name
            }).ToList();
            
            return Page();
        }

        [BindProperty]
        public Suggestion Suggestion { get; set; } = default!;
        [BindProperty]
        public Participants Participants { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var entry = _context.Add(new Suggestion());
            entry.CurrentValues.SetValues(Suggestion);
            
            var parEntry = _context.Add(new Participants());
            parEntry.CurrentValues.SetValues(Participants);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
