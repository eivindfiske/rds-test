using Microsoft.AspNetCore.Mvc;
using rds_test.Areas.Identity.Data;

namespace rds_test.Properties.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationContext _context;

        public UserController(ApplicationContext context)
        {
            _context = context;
        }
    }
}
