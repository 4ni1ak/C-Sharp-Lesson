using Microsoft.Extensions.Configuration;

namespace Excel.Presentation.Persistence.Configurations
{
    public static class ConfigurationsDb
    {
        public static string GetString(string key)
        {
            ConfigurationManager configurationManager = new();

            string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Persistence\\Configurations";

            configurationManager.SetBasePath(path);

            configurationManager.AddJsonFile("PrivateInformations.json"); 

            return configurationManager.GetSection(key).Value;
        }

    }
}
