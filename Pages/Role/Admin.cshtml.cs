using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using rds_test.Models;
using rds_test.Pages.Suggestions;
using System.ComponentModel.DataAnnotations;

namespace rds_test.Pages.Role
{
    public class AdminModel : PageModel
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        [BindProperty]
        public string Name { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var role = new IdentityRole { Name = Name };
                await _roleManager.CreateAsync(role);
                return RedirectToPage();
            }
            return Page();
        }



 


        public List<IdentityRole> roles { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            roles = await _roleManager.Roles.ToListAsync();

            return Page();
        }


    }

}
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.Azure.Cosmos;
//using Microsoft.Build.Framework;
//using Microsoft.EntityFrameworkCore;
//using rds_test.Data;
//using rds_test.Models;
//using rds_test.Pages.Suggestions;
//using System.ComponentModel.DataAnnotations;
//using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

//namespace rds_test.Pages.Role
//{
//    public class AdminModel : PageModel
//    {

//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly UserManager<ApplicationUser> _userManager;
//        public AdminModel(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
//        {
//            _roleManager = roleManager;
//            _userManager = userManager;
//        }


//        [BindProperty]
//        public string Name { get; set; }
//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (ModelState.IsValid)
//            {
//                var role = new IdentityRole { Name = Name };
//                await _roleManager.CreateAsync(role);
//                return RedirectToPage();
//            }
//            return Page();
//        }


//        public SelectList Roles { get; set; }
//        public SelectList Users { get; set; }
//        [BindProperty, Required, Display(Name = "Role")]
//        public string SelectedRole { get; set; }
//        [BindProperty, Required, Display(Name = "User")]
//        public string SelectedUser { get; set; }
//        public async Task OnGet()
//        {
//            await GetOptions();
//        }
//        public async Task<IActionResult> OnPostAsync2()
//        {
//            if (ModelState.IsValid)
//            {
//                var user = await _userManager.FindByNameAsync(SelectedUser);
//                await _userManager.AddToRoleAsync(user, SelectedRole);
//                return RedirectToPage("/RolesManager/Index");
//            }
//            await GetOptions();
//            return Page();
//        }

//        public async Task GetOptions()
//        {
//            var roles = await _roleManager.Roles.ToListAsync();
//            var users = await _userManager.Users.ToListAsync();
//            Roles = new SelectList(roles, nameof(IdentityRole.Name));
//            Users = new SelectList(users, nameof(ApplicationUser.UserName));
//        }



//        public List<IdentityRole> roles { get; set; }
//        public async Task<IActionResult> OnGetAsync()
//        {
//            roles = await _roleManager.Roles.ToListAsync();

//            return Page();
//        }


//    }

//}