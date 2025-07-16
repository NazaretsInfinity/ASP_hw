
using System.Globalization;

namespace ASPrazorpages.Services.Implementations
{
    public class TimeService : ITimeService
    {

        private readonly IStringService _stringService;
        private readonly CultureInfo _culture;

        public TimeService(IStringService stringService)
        {
            _culture = CultureInfo.GetCultureInfo("ru-RU");
            _stringService = stringService;
        }
        public string GetDayOfWeek(DayOfWeek day) => _stringService.ToTitle(_culture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek));
        

        public string GetDayOfWeek()
        {
           return GetDayOfWeek(DateTime.Now.DayOfWeek);
        }
    }
}
