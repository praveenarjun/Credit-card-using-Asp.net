using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CC_Regist_System.Models;
using CC_Regist_System.ViewModels;
using razorproject.Database;
using System.Threading.Tasks;
using System.Linq;

namespace razorproject.Pages.User
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; } = new RegisterViewModel();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check if the username already exists
            var existingUser = _context.LoginDetails.FirstOrDefault(u => u.Username == RegisterViewModel.Username);
            if (existingUser != null)
            {
                // Generate a unique username
                RegisterViewModel.Username = GenerateUniqueUsername(RegisterViewModel.Username);
            }

            var user = new UserDetails
            {
                Username = RegisterViewModel.Username,
                Fullname = RegisterViewModel.Fullname,
                Email = RegisterViewModel.Email,
                PhoneNumber = RegisterViewModel.PhoneNumber,
                Password = RegisterViewModel.Password // Ensure to hash the password in a real application
            };
            var loginDetail = new LoginDetail
            {
                Username = RegisterViewModel.Username,
                Password = RegisterViewModel.Password // Ensure to hash the password in a real application
            };

            _context.UserDetails.Add(user);
            _context.LoginDetails.Add(loginDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Login/Login");
        }

        private string GenerateUniqueUsername(string baseUsername)
        {
            int counter = 1;
            string uniqueUsername = baseUsername;

            while (_context.LoginDetails.Any(u => u.Username == uniqueUsername))
            {
                uniqueUsername = $"{baseUsername}{counter}";
                counter++;
            }

            return uniqueUsername;
        }
    }
}