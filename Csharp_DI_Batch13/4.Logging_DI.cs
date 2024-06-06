using BankAccountDINameSpace;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingNamespace
{

    public interface ILoggingService
    {
        void Log(string message);
    }

    public interface IDataAccessService
    {
        void SaveData(string data);
    }

    public interface IDownloadService
    {
        void fileDownload();
    }

    public class ConsoleLoggingService : ILoggingService
    {
        
        private IDownloadService _downloadSerivce;
        public ConsoleLoggingService(IDownloadService downloadService)
        {
            _downloadSerivce = downloadService;
        }

        public void Log(string message)
        {
            _downloadSerivce.fileDownload();
            Console.WriteLine($"Logging: {message}");
        }
    }

    public class DataAccessService : IDataAccessService
    {
        public void SaveData(string data)
        {
            Console.WriteLine("Saving Data");
        }
    }


    public class DownloadService : IDownloadService
    {
        public void fileDownload()
        {
            Console.WriteLine("File Download");
        }
    }


    public class Program
    {
        static void Main()
        {

            // Create a new ServiceCollection
            ServiceCollection serviceCollection = new ServiceCollection();

            //ITransaction ctransaction = new ComplexTrancation();//You can do it.
            // Register services
            serviceCollection.AddScoped<ILoggingService, ConsoleLoggingService>();
            serviceCollection.AddScoped<IDownloadService, DownloadService>();
            serviceCollection.AddScoped<IDataAccessService, DataAccessService>();

            //Build service collection
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            //The way you have to get the memebers from AccountService
            ILoggingService loggingService = serviceProvider.GetService<ILoggingService>();
                                            //ConsoleLoggingService
            IDownloadService downloadService = serviceProvider.GetService<IDownloadService>();
                                              //
            IDataAccessService dataService = serviceProvider.GetService<IDataAccessService>();
            //DataAccessService



            //Main Target is below
            loggingService.Log("User logged at 06-06-24");
            downloadService.fileDownload();
            dataService.SaveData("User register the class at 06-06-24");

            Console.ReadLine();
        }
    }







}
