using ConsoleAppDI.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDI.Repository
{
    public class DateTimeRepositoryUSTime : IDateTimeRepository
    {
        public Task<DateTime> GetCurrentTime()
        {
            DateTime utcNow = DateTime.UtcNow; // Get the current UTC time

            // Specify the desired time zone (e.g., Eastern Standard Time)
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            // Convert UTC time to the specified time zone
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, timeZone);
            return Task.FromResult( localTime);
        }
    }
}
