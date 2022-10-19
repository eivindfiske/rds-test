using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

    public class SuggestionsModel : PageModel
    {
        private readonly ILogger<SuggestionsModel> _logger;

        public SuggestionsModel(ILogger<SuggestionsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}