using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProductShowcase.WebApp.Pages
{
    public class TestPageModel : PageModel
    {
        public string? CurrentTime { get; set; }

        public void OnGet()
        {
            CurrentTime = System.DateTime.Now.ToString();
        }
    }
}
