using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ProductShowcase.Core.Models;
using System.Threading.Tasks;

namespace ProductShowcase.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
