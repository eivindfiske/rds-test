using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages.Suggestions
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly rds_test.Data.ApplicationContext _context;

        public DetailsModel(rds_test.Data.ApplicationContext context)
        {
            _context = context;
        }

        public Suggestion Suggestion { get; set; } = default!;
        public Participants Participants { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.suggestion == null)
            {
                return NotFound();
            }

            var suggestion = await _context.suggestion.FirstOrDefaultAsync(m => m.case_num == id);
            var participants = await _context.participants.FirstOrDefaultAsync(m => m.case_num == id);
            if (suggestion == null)
            {
                return NotFound();
            }
            else
            {
                Participants = participants;
                Suggestion = suggestion;
            }
            return Page();

        }

        // public void GetName(int? id)
        // {
        //     var namewanted = (from a in _context.applicationUsers where a.Id = id select a.name);
        // }
    }
}
