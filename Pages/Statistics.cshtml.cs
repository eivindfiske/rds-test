using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages
{
    // [Authorize]
    public class StatisticsModel : PageModel
    {
        public readonly ApplicationContext _context;

         public StatisticsModel(ApplicationContext context)
        {
            _context = context;
        }


        public IActionResult OnGetChartData()
        {
            //SQL
            // select AspNetUsers.team, count(*) from suggestion join
            // AspNetUsers on suggestion.Id = AspNetUsers.Id group by team order by count(*) desc;

            var suggestions = (from s in _context.suggestion
                                join a in _context.applicationUsers on s.Id equals a.Id 
                                group s by a.team into g
                                select g.Count()
                                ).ToArray();
            
            var teams = (from a in _context.applicationUsers select a.team).Distinct().ToArray();

            return new JsonResult(new {teams, suggestions});

        }

        
        public IActionResult onGet()
        {
            return Page();
        }

    }
}