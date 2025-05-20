using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using razorproject.Database;
using CC_Regist_System.Models;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace razorproject.Pages.ApplyCard
{
    public class ApplyModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplyModel> _logger;

        public ApplyModel(ApplicationDbContext context, ILogger<ApplyModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public ApplyCardViewModel ApplyCardViewModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    var key = state.Key;
                    var errors = state.Value.Errors;
                    foreach (var error in errors)
                    {
                        _logger.LogError($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }


            // Save uploaded files
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            string passportOrBankAccountPath = null;
            if (ApplyCardViewModel.PassportOrBankAccount != null)
            {
                passportOrBankAccountPath = Path.Combine(uploads, ApplyCardViewModel.PassportOrBankAccount.FileName);
                using (var fileStream = new FileStream(passportOrBankAccountPath, FileMode.Create))
                {
                    await ApplyCardViewModel.PassportOrBankAccount.CopyToAsync(fileStream);
                }
                _logger.LogInformation($"Passport or Bank Account file saved to {passportOrBankAccountPath}");
            }

            string incomeCertificatePath = null;
            if (ApplyCardViewModel.IncomeCertificate != null)
            {
                incomeCertificatePath = Path.Combine(uploads, ApplyCardViewModel.IncomeCertificate.FileName);
                using (var fileStream = new FileStream(incomeCertificatePath, FileMode.Create))
                {
                    await ApplyCardViewModel.IncomeCertificate.CopyToAsync(fileStream);
                }
                _logger.LogInformation($"Income Certificate file saved to {incomeCertificatePath}");
            }

            string photoPath = null;
            if (ApplyCardViewModel.Photo != null)
            {
                photoPath = Path.Combine(uploads, ApplyCardViewModel.Photo.FileName);
                using (var fileStream = new FileStream(photoPath, FileMode.Create))
                {
                    await ApplyCardViewModel.Photo.CopyToAsync(fileStream);
                }
                _logger.LogInformation($"Photo file saved to {photoPath}");
            }

            string malaysianCitizenshipIdCardPath = null;
            if (ApplyCardViewModel.MalaysianCitizenshipIdCard != null)
            {
                malaysianCitizenshipIdCardPath = Path.Combine(uploads, ApplyCardViewModel.MalaysianCitizenshipIdCard.FileName);
                using (var fileStream = new FileStream(malaysianCitizenshipIdCardPath, FileMode.Create))
                {
                    await ApplyCardViewModel.MalaysianCitizenshipIdCard.CopyToAsync(fileStream);
                }
                _logger.LogInformation($"Malaysian Citizenship ID Card file saved to {malaysianCitizenshipIdCardPath}");
            }

            // Save user details and file paths
            ApplyCardViewModel.PassportOrBankAccountPath = passportOrBankAccountPath;
            ApplyCardViewModel.IncomeCertificatePath = incomeCertificatePath;
            ApplyCardViewModel.PhotoPath = photoPath;
            ApplyCardViewModel.MalaysianCitizenshipIdCardPath = malaysianCitizenshipIdCardPath;

            _context.ApplyCardViewModels.Add(ApplyCardViewModel);
            await _context.SaveChangesAsync();

            _logger.LogInformation("User details saved to the database");

            // Generate and save card details
            var cardDetails = new CardDetails
            {
                CardNumber = GenerateCardNumber(),
                CVV = GenerateCVV(),
                ExpiryDate = DateTime.Now.AddYears(10),
                FullName = ApplyCardViewModel.FullName
            };

            _context.CardDetails.Add(cardDetails);
            await _context.SaveChangesAsync();

            // Redirect to a confirmation page with the ID of the newly created record
            return RedirectToPage("Confirmation", new { id = ApplyCardViewModel.Id });
        }

        private string GenerateCardNumber()
        {
            Random random = new Random();
            return string.Join(" ", Enumerable.Range(0, 4).Select(_ => random.Next(1000, 9999).ToString("D4")));
        }

        private string GenerateCVV()
        {
            Random random = new Random();
            return random.Next(100, 999).ToString("D3");
        }
    }
}