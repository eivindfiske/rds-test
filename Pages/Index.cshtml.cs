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

        public string timestampSort {get; set;}
        public string timeframeSort {get; set;}
        public string titleSort {get; set;}
        public string currentFilter {get; set;}

        public IList<Suggestion> Suggestion { get;set; } = default!;

        // public async Task OnGetAsync()
        // {
        //     if (_context.suggestion != null)
        //     {
        //         Suggestion = await _context.suggestion.ToListAsync();
        //     }
        // }

        public async Task OnGetAsync(string sortData, string searchString)
        {
            timestampSort = sortData == "timestamp" ? "timestamp_desc" : "timestamp"; 
            titleSort = String.IsNullOrEmpty(sortData) ? "title" : "";
            timeframeSort = sortData == "timeframe" && sortData.Contains("just do it") ? "timeframe" : "timeframe";

            currentFilter = searchString;

            IQueryable<Suggestion> getSuggestion = from s in _context.suggestion select s;

            switch(sortData)
            {
                case "timestamp": getSuggestion = getSuggestion.OrderByDescending(s => s.timestamp);
                break;
                case "title": getSuggestion = getSuggestion.OrderBy(s => s.title);
                break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                getSuggestion = getSuggestion.Where(s => s.title.Contains(searchString) || s.description.Contains(searchString) || 
                s.timeframe.Contains(searchString));
            }

            Suggestion = await getSuggestion.AsNoTracking().ToListAsync();
        }
    }
}