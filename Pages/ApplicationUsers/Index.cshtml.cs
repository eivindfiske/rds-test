using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages_ApplicationUsers
{
    public class IndexModel : PageModel
    {
        private readonly rds_test.Data.ApplicationContext _context;

        public IndexModel(rds_test.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> ApplicationUser { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.applicationUsers != null)
            {
                ApplicationUser = await _context.applicationUsers
                .Include(e => e.dept).ToListAsync();
            }
        }
    }
}
