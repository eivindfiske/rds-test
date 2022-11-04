using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test;
using rds_test.Areas.Identity.Data;

namespace rds_test.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly rds_test.Areas.Identity.Data.ApplicationContext _context;

        public IndexModel(rds_test.Areas.Identity.Data.ApplicationContext context)
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