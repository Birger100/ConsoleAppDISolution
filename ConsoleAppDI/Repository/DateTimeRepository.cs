using ConsoleAppDI.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDI.Repository
{
    public class DateTimeRepository : IDateTimeRepository
    {
        public Task<DateTime> GetCurrentTime()
        {
            return Task.FromResult(DateTime.Now);
        }
    }
}
