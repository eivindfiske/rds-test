using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test.Models;
using rds_test.Data;

namespace rds_test.Pages.Account
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;

        public IndexModel(ApplicationContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> users { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.applicationUsers != null)
            {
                users = await _context.applicationUsers.ToListAsync();
            }
        }
    }
}