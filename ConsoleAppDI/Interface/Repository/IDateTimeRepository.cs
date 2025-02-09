using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDI.Interface.Repository
{
    public interface IDateTimeRepository
    {
        Task<DateTime> GetCurrentTime();

    }
}
