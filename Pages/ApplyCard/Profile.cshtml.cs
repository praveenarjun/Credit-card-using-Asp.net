using Microsoft.AspNetCore.Mvc.RazorPages;
using razorproject.Database;
using CC_Regist_System.Models;
using System.Linq;

namespace razorproject.Pages.Profile
{
    public class ProfileModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProfileModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public CardDetails CardDetails { get; private set; }

        public void OnGet()
        {
            // Assuming the user is authenticated and we can get their ID
            // For demonstration purposes, we'll just get the first card details
            CardDetails = _context.CardDetails.FirstOrDefault();
        }
    }
}