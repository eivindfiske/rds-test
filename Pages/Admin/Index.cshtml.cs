using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using rds_test.Models;
using System.ComponentModel.DataAnnotations;

namespace rds_test.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            
            _userManager = userManager;
        }
        public SelectList UserData { get; set; }
        [BindProperty, Required, Display(Name = "User")]
        public string SelectedUser { get; set; }
        public async Task OnGet()
        {
            await GetOptions();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(SelectedUser);
                user.LockoutEnd = DateTime.Now.AddMinutes(1);
                
                
            }
            
            await GetOptions();
            return RedirectToPage("/index");
        }

        public async Task GetOptions()
        {
            var users = await _userManager.Users.ToListAsync();
            UserData = new SelectList(users, nameof(ApplicationUser.UserName));
        }
    }
}