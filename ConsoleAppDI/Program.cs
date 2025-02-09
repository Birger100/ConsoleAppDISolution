using ConsoleAppDI.Interface.Repository;
using ConsoleAppDI.Interface.Service;
using ConsoleAppDI.Repository;
using ConsoleAppDI.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleAppDI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region DI setup
            Console.WriteLine("Set up DI");
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddScoped<IDateTimeService, DateTimeService>();
            if(DateTime.Now.Minute % 2 == 0)
            {
                builder.Services.AddScoped<IDateTimeRepository, DateTimeRepository>();
            }else
            {
                builder.Services.AddScoped<IDateTimeRepository, DateTimeRepositoryUSTime>();

            }

            using IHost host = builder.Build();
            Console.WriteLine("DI setup done");

            #endregion

            #region logic

            //get the time
            DoDateTimeThing(host.Services);

            #endregion
        }



        static async void DoDateTimeThing(IServiceProvider serviceProvider)
        {
            using IServiceScope serviceScope = serviceProvider.CreateScope();
            IDateTimeService _dateTimeService = serviceProvider.GetService<IDateTimeService>();
            var format = "dd/MM/yyyy HH:mm:ss";
            Console.WriteLine("Input :  " + format  );
            Console.WriteLine("Output : " + await _dateTimeService.GetCurrentTimeAsStringBasedOnInputFormat(format));

            format = "yyyyMMdd HH:mm:ss";
            Console.WriteLine("Input :  " + format);
            Console.WriteLine("Output : " + await _dateTimeService.GetCurrentTimeAsStringBasedOnInputFormat(format));

            format = "yxyyMMdd HH:mm:ss";
            Console.WriteLine("Input :  " + format);
            Console.WriteLine("Output : " + await _dateTimeService.GetCurrentTimeAsStringBasedOnInputFormat(format));

        }
    }
}
