using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

using SodaMachineLibrary.DataAccess;
using SodaMachineLibrary.Logics;

namespace SodaMachineConsoleUI
{
    class Program
    {
        private static ServiceProvider ServiceProvider { get; set; }
        
        static void Main(string[] args)
        {
            ConfigureServices();
            SodaMachineLogic sodaMachineLogic = ActivatorUtilities.CreateInstance<SodaMachineLogic>(ServiceProvider);

            Menu menu = new Menu();
            menu.PrintMenu();
        }

        static void ConfigureServices()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            ServiceCollection serviceCollection = new ServiceCollection();

            IConfigurationRoot Configuration = builder.Build();

            serviceCollection.AddSingleton<IConfiguration>(Configuration);
            serviceCollection.AddTransient<IDataAccess, TextFileDataAccess>();   
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
