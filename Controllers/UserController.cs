using Microsoft.AspNetCore.Mvc;
using CC_Regist_System.Models;
using CC_Regist_System.ViewModels;
using razorproject.Database;
using System.Threading.Tasks;

namespace razorproject.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDetails
                {
                    Username = model.Username,
                    Fullname = model.Fullname,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password // Ensure to hash the password in a real application
                };

                _context.UserDetails.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login", "Auth");
            }

            return View(model);
        }
    }
}