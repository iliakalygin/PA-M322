using Microsoft.Extensions.Configuration;
using System.IO;

namespace JetStreamServiceApp
{
    public class AppSettings
    {
        public string? OrdersUrl { get; set; }
        private AppSettings() => Load();

        public static AppSettings Instance { get; set; } = new AppSettings();

        private void Load()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            if (configuration != null)
            {
                OrdersUrl = configuration["orderUrl:orders"];
            }
        }
    }
}
