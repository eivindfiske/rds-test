using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using rds_test.Models;

namespace rds_test.Pages
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly rds_test.Data.ApplicationContext _context;

        public IndexModel(rds_test.Data.ApplicationContext context)
        {
            _context = context;
        }

        public string currentFilter { get; set; }

        public string timestampSort { get; set; }
        public string deadlineSort { get; set; }
        public string timeframeJDISort { get; set; }
        public string timeframeShortSort { get; set; }
        public string timeframeLongSort { get; set; }

        public string statusPlanSort { get; set; }
        public string statusDoSort { get; set; }
        public string statusStudySort { get; set; }
        public string statusActSort { get; set; }

        public string deptProduksjonSort { get; set; }
        public string deptLogistikkSort { get; set; }
        public string deptSalgSort { get; set; }
        public string deptLederSort { get; set; }
        public string deptTekniskSort { get; set; }

        public IList<Suggestion> Suggestion { get; set; } = default!;

        public async Task OnGetAsync(string sortData, string searchString)
        {
            timestampSort = sortData == "timestamp" ? "timestamp_desc" : "timestamp";
            deadlineSort = sortData == "deadline" ? "deadline" : "deadline";
            timeframeJDISort = sortData == "timeframeJDI" ? "timeframeJDI" : "timeframeJDI";
            timeframeShortSort = sortData == "timeframeShort" ? "timeframeShort" : "timeframeShort";
            timeframeLongSort = sortData == "timeframeLong" ? "timeframeLong" : "timeframeLong";
            statusPlanSort = sortData == "statusPlan" ? "statusPlan" : "statusPlan";
            statusDoSort = sortData == "statusDo" ? "statusDo" : "statusDo";
            statusStudySort = sortData == "statusStudy" ? "statusStudy" : "statusStudy";
            statusActSort = sortData == "statusAct" ? "statusAct" : "statusAct";
            deptProduksjonSort = sortData == "deptProduksjon" ? "deptProduksjon" : "deptProduksjon";
            deptLogistikkSort = sortData == "deptLogistikk" ? "deptLogistikk" : "deptLogistikk";
            deptSalgSort = sortData == "deptSalg" ? "deptSalg" : "deptSalg";
            deptLederSort = sortData == "deptLeder" ? "deptLeder" : "deptLeder";
            deptTekniskSort = sortData == "deptTeknisk" ? "deptTeknisk" : "deptTeknisk";

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
                case "statusPlan":
                    getSuggestion = getSuggestion.Where(s => s.status.Contains("P"));
                    break;
                case "statusDo":
                    getSuggestion = getSuggestion.Where(s => s.status.Contains("D"));
                    break;
                case "statusStudy":
                    getSuggestion = getSuggestion.Where(s => s.status.Contains("S"));
                    break;
                case "statusAct":
                    getSuggestion = getSuggestion.Where(s => s.status.Contains("A"));
                    break;
                case "deptProduksjon":
                    getSuggestion = getSuggestion.Where(s => s.resdept.Contains("Produksjon"));
                    break;
                case "deptLogistikk":
                    getSuggestion = getSuggestion.Where(s => s.resdept.Contains("Logistikk"));
                    break;
                case "deptSalg":
                    getSuggestion = getSuggestion.Where(s => s.resdept.Contains("Salg og marked"));
                    break;
                case "deptLeder":
                    getSuggestion = getSuggestion.Where(s => s.resdept.Contains("Ledergruppe"));
                    break;
                case "deptTeknisk":
                    getSuggestion = getSuggestion.Where(s => s.resdept.Contains("Teknisk"));
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