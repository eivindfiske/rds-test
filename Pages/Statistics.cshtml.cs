using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            var suggestions = (from s in _context.suggestion
                                
                                select new {s.case_num, s.title}
                                ).ToArray();

                return new JsonResult(suggestions);
        }

//select AspNetUsers.name, suggestion.Id, count(*) from suggestion join AspNetUsers on 
//suggestion.Id = AspNetUsers.Id group by id order by count(*) desc limit 3;

//select AspNetUsers.team, suggestion.Id, count(*) from suggestion join 
//AspNetUsers on suggestion.Id = AspNetUsers.Id group by team order by count(*) desc;
        
        public IActionResult onGet()
        {
            

            return Page();
        }

    }
}