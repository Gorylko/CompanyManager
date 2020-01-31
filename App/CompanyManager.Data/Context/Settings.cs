namespace CompanyManager.Data.Context
{
    using System;
    using Microsoft.Extensions.Configuration;

    public static class Settings
    {
        static Settings()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("settings.json", false, true);

            IConfiguration configuration = builder.Build();
            ConnectionString = configuration.GetConnectionString("localConnection");
        }

        public static string ConnectionString { get; }
    }
}
