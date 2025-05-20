using Microsoft.AspNetCore.Mvc;
using CC_Regist_System.Models;
using CC_Regist_System.ViewModels;
using razorproject.Database;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace razorproject.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDetail model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.LoginDetails
                    .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    // Set a session or cookie here if needed
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }
    }
}