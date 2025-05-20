using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorproject.Database;
using CC_Regist_System.Models;
using System.Linq;

namespace razorproject.Pages.ApplyCard
{
    public class ConfirmationModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ConfirmationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplyCardViewModel ApplyCardViewModel { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            ApplyCardViewModel = _context.ApplyCardViewModels.FirstOrDefault(m => m.Id == id);

            if (ApplyCardViewModel == null)
            {
                return NotFound();
            }

            // Redirect to the profile page with the card ID
            var cardDetails = _context.CardDetails.FirstOrDefault(c => c.FullName == ApplyCardViewModel.FullName);
            if (cardDetails != null)
            {
                return RedirectToPage("/Profile/Profile", new { id = cardDetails.Id });
            }

            return Page();
        }
    }
}