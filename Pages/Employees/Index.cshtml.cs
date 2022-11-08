// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.EntityFrameworkCore;
// using rds_test.Data;
// using rds_test.Models;

// namespace rds_test.Pages_Employees
// {
//     public class IndexModel : PageModel
//     {
//         private readonly rds_test.Data.AppDbContext _context;

//         public IndexModel(rds_test.Data.AppDbContext context)
//         {
//             _context = context;
//         }

//         public IList<Emp> Emp { get;set; } = default!;

//         public async Task OnGetAsync()
//         {
//             if (_context.emp != null)
//             {
//                 Emp = await _context.emp
//                 .Include(e => e.dept).ToListAsync();
//             }
//         }
//     }
// }
