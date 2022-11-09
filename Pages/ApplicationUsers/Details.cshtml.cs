using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages_Employees
{
    public class DetailsModel : PageModel
    {
        private readonly rds_test.Data.ApplicationContext _context;

        public DetailsModel(rds_test.Data.ApplicationContext context)
        {
            _context = context;
        }

        public ApplicationUser ApplicationUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || _context.applicationUsers == null)
            {
                return NotFound();
            }

            var applicationUsers = await _context.applicationUsers.FirstOrDefaultAsync(m => m.emp_num == id);
            if (applicationUsers == null)
            {
                return NotFound();
            }
            else
            {
                ApplicationUser = applicationUsers;
            }
            return Page();
        }
    }
}
