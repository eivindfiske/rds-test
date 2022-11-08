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
//     public class DetailsModel : PageModel
//     {
//         private readonly rds_test.Data.AppDbContext _context;

//         public DetailsModel(rds_test.Data.AppDbContext context)
//         {
//             _context = context;
//         }

//       public Emp Emp { get; set; } = default!; 

//         public async Task<IActionResult> OnGetAsync(int? id)
//         {
//             if (id == null || _context.emp == null)
//             {
//                 return NotFound();
//             }

//             var emp = await _context.emp.FirstOrDefaultAsync(m => m.emp_num == id);
//             if (emp == null)
//             {
//                 return NotFound();
//             }
//             else 
//             {
//                 Emp = emp;
//             }
//             return Page();
//         }
//     }
// }
