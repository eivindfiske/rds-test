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

        public string data;

        public IActionResult OnGetChartData()
        {
            var countRevenue = (from s in _context.suggestion
                                join a in _context.applicationUsers on s.Id equals a.Id
                                select new {a.name, s.case_num}
                                ).ToArray().Count();
                return new JsonResult(countRevenue);
        }

        
        public IActionResult onGet()
        {
            

            return Page();
        }

    }
}