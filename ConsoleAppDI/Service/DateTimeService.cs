using ConsoleAppDI.Interface.Repository;
using ConsoleAppDI.Interface.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDI.Service
{
    public class DateTimeService : IDateTimeService
    {
        private readonly IDateTimeRepository _dateTimeRepository;
        CultureInfo provider = CultureInfo.InvariantCulture;
        public DateTimeService(IDateTimeRepository dateTimeRepository)
        {
            _dateTimeRepository = dateTimeRepository;
        }
        public async Task<string> GetCurrentTimeAsStringBasedOnInputFormat(string format)
        {
           var dateTime = await _dateTimeRepository.GetCurrentTime();
            if (!string.IsNullOrEmpty(format))
            {
                try
                {
                    var isValidFormat = IsValidDateFormat(dateTime, format);
                    if (isValidFormat)
                    {
                        var parsedDatetime = dateTime.ToString(format);
                        return parsedDatetime;

                    }
                    else
                    {
                        return dateTime.ToUniversalTime().ToString();
                    }
                    
                }
                catch (Exception ex)
                {
                    //invalid format
                    return dateTime.ToUniversalTime().ToString() ;
                }
                

            }else
            {
                return dateTime.ToUniversalTime().ToString();
            }
        }

        private bool IsValidDateFormat(DateTime date, string format)
        {
            DateTime tempDate;
            var dateString = date.ToString("yyyy-MM-dd HH:mm:ss");
            return DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate);
        }
    }
}
