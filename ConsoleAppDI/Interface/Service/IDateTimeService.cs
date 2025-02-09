using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDI.Interface.Service
{
    public interface IDateTimeService
    {
        /// <summary>
        /// Get current time and converts to formatted time
        /// If invalid format time vil be returned in default format
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        Task<string> GetCurrentTimeAsStringBasedOnInputFormat(string format);
    }
}
