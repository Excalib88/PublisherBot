using System;
using PublisherBot.Scheduler;
using PublisherBot.TelegramAPI;
using Telegram.Bot;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace PublisherBot.Server
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();
            var appConfig = serviceProvider.GetService<IConfigurationRoot>();
          
            var postSender = new PostSender(
                new TelegramBotClient(appConfig.GetValue<string>("TelegramKeyApi")), appConfig.GetValue<string>("ChatId"));

            MessageScheduler.Start();

            Console.ReadKey();
        }
        
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            // Initialize serilog logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(
                    $"Logs/log-{DateTime.Now.ToString("dd.MM.yyyy(HH.mm.ss)", CultureInfo.InvariantCulture)}.log")
                .CreateLogger();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton(configuration);
        }
    }
}