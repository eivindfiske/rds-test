using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using rds_test.Data;
using rds_test.Models;

namespace rds_test.Pages.Suggestions
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public List<SelectListItem> empList { get; set; }
        [BindProperty]
        public List<SelectListItem> deptList { get; set; }


        public IActionResult OnGet()
        {
            empList = _context.applicationUsers.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.name
            }).ToList();

            deptList = _context.dept.Select(a => new SelectListItem
            {
                Value = a.dept.ToString(),
                Text = a.dept
            }).ToList();

            return Page();
        }

        [BindProperty]
        public Suggestion Suggestion { get; set; } = default!;
        [BindProperty]
        public Participants Participants { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            byte[] bytes = null;
            if (Suggestion.pic_before != null)
            {
                using (Stream fs = Suggestion.pic_before.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }
                }
                Suggestion.pic_before_data = Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            byte[] bytes2 = null;
            if (Suggestion.pic_after != null)
            {
                using (Stream fs = Suggestion.pic_after.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes2 = br.ReadBytes((Int32)fs.Length);
                    }
                }
                Suggestion.pic_after_data = Convert.ToBase64String(bytes2, 0, bytes2.Length);
            }

            var entry = _context.Add(new Suggestion());
            entry.CurrentValues.SetValues(Suggestion);

            // List<Participants> parEntry = new List<Participants>() {new Participants() {Id = Participants.Id}};
            // parEntry.Add(Participants);
            // _context.participants.AddRange(parEntry);

            var parEntry = _context.Add(new Participants() { Id = Participants.Id });
            parEntry.CurrentValues.SetValues(Participants);


            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
