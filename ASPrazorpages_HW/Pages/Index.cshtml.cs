using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace ASPrazorpages_HW.Pages
{
    public class IndexModel : PageModel
    {
        public string? DayOfWeek { get; set; }
        public int? RandomNumber {  get; set; }

        public void OnGet()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("ru-RU");
            DayOfWeek = culture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);

            RandomNumber = new Random().Next();
        }
    }
}
