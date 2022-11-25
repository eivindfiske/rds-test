using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;



namespace rds_test.Pages.Admin
{
    [Authorize(Roles = "Admin")]

    public class RolesModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [BindProperty]
        public string Name { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = Name };
                await _roleManager.CreateAsync(role);
                return RedirectToPage();
            }
            return Page();
        }
    }

}


