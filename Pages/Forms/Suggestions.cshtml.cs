using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rds_test.Models;

namespace rds_test.MVC.Pages.Forms
{
    public class SuggestionModel : PageModel
    {
        [BindProperty]
        public Suggestion suggestion { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("/Pages/Index.cshtml");
        }
    }
}