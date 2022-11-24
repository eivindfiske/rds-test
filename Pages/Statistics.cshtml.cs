using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using rds_test.Models.StatModels;

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

            var teams = (from a in _context.applicationUsers select a.team).Distinct().ToArray();

            var suggestions = (from s in _context.suggestion
                                join a in _context.applicationUsers on s.Id equals a.Id 
                                group s by a.team into g
                                select g.Count() 
                                ).ToArray();
            
            var stats = new List<StatAllTeams>();
        
            for (int i = 0; i < teams.Length; i++)
            {
                var stat = new StatAllTeams();
                stat.count = suggestions[i];
                stat.teams = teams[i];
                stats.Add(stat);
            }

            // var suggestions = (from s in _context.suggestion 
            //                     join a in _context.applicationUsers on s.Id equals a.Id
            //                     select new {s.case_num, a.name}
            //                     ).ToArray();

            return new JsonResult(stats.ToArray());

        }

        
        public IActionResult onGet()
        {
            return Page();
        }

    }
}