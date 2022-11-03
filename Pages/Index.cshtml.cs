using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly rds_test.Data.AppDbContext _context;

        public IndexModel(rds_test.Data.AppDbContext context)
        {
            _context = context;
        }

        public string currentFilter {get; set;}

        public IList<Suggestion> Suggestion { get;set; } = default!;

        // public async Task OnGetAsync()
        // {
        //     if (_context.suggestion != null)
        //     {
        //         Suggestion = await _context.suggestion.ToListAsync();
        //     }
        // }

        public async Task OnGetAsync(string searchString)
        {
            currentFilter = searchString;

            IQueryable<Suggestion> getSuggestion = from s in _context.suggestion select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                getSuggestion = getSuggestion.Where(s => s.title.Contains(searchString));
            }

            Suggestion = await getSuggestion.AsNoTracking().ToListAsync();
        }
    }
}