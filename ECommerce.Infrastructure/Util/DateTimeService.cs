
namespace ECommerce.Application.Util
{
    public class DateTimeService : IDateTimeService
    {
        const string CentralStandardTime = "Central Standard Time";

        public DateTime Now()
        {
            return DateTime.Now;
        }
        public DateTime GetCentralTimeDate()
        {
            var date = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, CentralStandardTime);
            return date;
        }
    }
}
