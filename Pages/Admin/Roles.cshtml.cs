using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rds_test.Models;
using System.ComponentModel.DataAnnotations;

namespace rds_test.Pages.Admin
{
   
        public class RolesModel : PageModel
        {


        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public RolesModel(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser>userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            
        }
        public List<IdentityRole> Roles { get; set; }
        [BindProperty]
        public string Name { get; set; }
        public SelectList RoleData { get; set; }
        public SelectList UserData { get; set; }
        [BindProperty, Required, Display(Name = "Role")]
        public string SelectedRole { get; set; }
        [BindProperty, Required, Display(Name = "User")]
        public string SelectedUser { get; set; }

        public async Task OnGet()
        {
            Roles = _roleManager.Roles.ToList();
            await GetOptions();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = Name };
                await _roleManager.CreateAsync(role);
                var user = await _userManager.FindByNameAsync(SelectedUser);
                await _userManager.AddToRoleAsync(user, SelectedRole);
                return RedirectToPage();
            }
            return Page();
        }

        public async Task GetOptions()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var users = await _userManager.Users.ToListAsync();
            RoleData = new SelectList(roles, nameof(IdentityRole.Name));
            UserData = new SelectList(users, nameof(ApplicationUser.UserName));
        }

    }

    }

