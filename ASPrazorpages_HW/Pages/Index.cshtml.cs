using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace ASPrazorpages_HW.Pages
{
    public class IndexModel : PageModel
    {
        public int? RandomNumber {  get; set; }

        public void OnGet()
        {
            #region turned into TimeService
            CultureInfo culture = CultureInfo.GetCultureInfo("ru-RU");
            //CultureInfo.CurrentCulture - get culture applied to our PC 

            //DayOfWeek = culture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);

            //char.ToUpper(); //turns char into up register
            RandomNumber = new Random().Next(); 
            #endregion
        }
    }
}
