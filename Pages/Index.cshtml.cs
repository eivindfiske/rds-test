using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages
{
    // [Authorize]
    public class IndexModel : PageModel
    {
        private readonly rds_test.Data.ApplicationContext _context;

        public IndexModel(rds_test.Data.ApplicationContext context)
        {
            _context = context;
        }

        public string timestampSort { get; set; }
        public string timeframeJDISort { get; set; }
        public string timeframeShortSort { get; set; }
        public string timeframeLongSort { get; set; }
        public string deadlineSort { get; set; }
        public string currentFilter { get; set; }

        public IList<Suggestion> Suggestion { get; set; } = default!;

        public async Task OnGetAsync(string sortData, string searchString)
        {
            timestampSort = sortData == "timestamp" ? "timestamp_desc" : "timestamp";
            deadlineSort = sortData == "deadline" ? "deadline" : "deadline";
            timeframeJDISort = sortData == "timeframeJDI" ? "timeframeJDI" : "timeframeJDI";
            timeframeShortSort = sortData == "timeframeShort" ? "timeframeShort" : "timeframeShort";
            timeframeLongSort = sortData == "timeframeLong" ? "timeframeLong" : "timeframeLong";

            currentFilter = searchString;

            IQueryable<ApplicationUser> getAppUser = from a in _context.applicationUsers select a;
            IQueryable<Suggestion> getSuggestion = from s in _context.suggestion select s;

            switch (sortData)
            {
                case "timestamp":
                    getSuggestion = getSuggestion.OrderByDescending(s => s.timestamp);
                    break;
                case "deadline":
                    getSuggestion = getSuggestion.OrderBy(s => s.deadline);
                    break;
                case "timeframeJDI":
                    getSuggestion = getSuggestion.Where(s => s.timeframe.Contains("Just do it"));
                    break;
                case "timeframeShort":
                    getSuggestion = getSuggestion.Where(s => s.timeframe.Contains("Kortsiktig"));
                    break;
                case "timeframeLong":
                    getSuggestion = getSuggestion.Where(s => s.timeframe.Contains("Langsiktig"));
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                getSuggestion = getSuggestion.Where(s => s.title.Contains(searchString) 
                || s.description.Contains(searchString) || s.timeframe.Contains(searchString)
                || s.pdsa_plan.Contains(searchString));
            }

            Suggestion = await getSuggestion.AsNoTracking().ToListAsync();
        }
    }
}