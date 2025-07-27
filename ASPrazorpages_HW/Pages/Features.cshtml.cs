using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPrazorpages.Pages
{
    public class FeaturesModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<string> GetMessageAsync()
        {
            return "Hello world";
        }
    }
}
