using Microsoft.AspNetCore.Mvc;
using CC_Regist_System.Models;
using razorproject.Database;

namespace razorproject.Controllers
{
    public class ApplyCardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplyCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Apply(ApplyCardViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.ApplyCardViewModels.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Confirmation");
            }
            return View(model);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}