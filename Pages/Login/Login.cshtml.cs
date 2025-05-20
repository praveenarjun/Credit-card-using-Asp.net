using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CC_Regist_System.Models;
using razorproject.Database;
using System.Threading.Tasks;
using System.Linq;

namespace razorproject.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginDetail LoginDetail { get; set; } = new LoginDetail();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Invalid login attempt." });
            }

            var user = _context.LoginDetails.FirstOrDefault(u => u.Username == LoginDetail.Username && u.Password == LoginDetail.Password);

            if (user != null)
            {
                // Set a session or cookie here if needed
                HttpContext.Session.SetString("Username", user.Username);
                return new JsonResult(new { success = true, message = "Login successful." });
            }

            return new JsonResult(new { success = false, message = "Invalid login attempt." });
        }
    }
}