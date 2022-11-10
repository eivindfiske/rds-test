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
        private readonly rds_test.Data.ApplicationContext _context;

        public EditModel(rds_test.Data.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Suggestion Suggestion { get; set; } = default!;
        // public Participants Participants { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.suggestion == null)
            {
                return NotFound();
            }

            var suggestion =  await _context.suggestion.FirstOrDefaultAsync(m => m.case_num == id);
            // var participants =  await _context.participants.FirstOrDefaultAsync(m => m.case_num == id);
            if (suggestion == null)
            {
                return NotFound();
            }
            Suggestion = suggestion;
            // Participants = participants;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
        var editSuggestion = await _context.suggestion.FindAsync(id);
        // var editParticipants = await _context.participants.FindAsync(id);

        if (editSuggestion == null) 
        {
            return NotFound();
        }

        await TryUpdateModelAsync<Suggestion>(
         editSuggestion, "suggestion",
            m => m.title, m => m.description, m => m.pdsa_plan,
            m => m.pdsa_do, m => m.pdsa_study, m => m.pdsa_act,
            m => m.status, m => m.responsible, m => m.resdept,
            m => m.pic_before, m => m.pic_after, m => m.timeframe,
            m => m.deadline);
        
        // await TryUpdateModelAsync<Participants>(
        // editParticipants, "participants", m => m.emp_num);
        

        await _context.SaveChangesAsync();
        return RedirectToPage("./Details", new {id = id});
        }             
}
}
