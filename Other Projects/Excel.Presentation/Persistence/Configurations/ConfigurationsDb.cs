using Microsoft.Extensions.Configuration;

namespace Excel.Presentation.Persistence.Configurations
{
    public static class ConfigurationsDb
    {
        public static string GetString(string key)
        {
            ConfigurationManager configurationManager = new();

            string path = $"C:\\Users\\Bhs\\Desktop\\C-Sharp-Lesson\\Other Projects\\Excel.Presentation\\Persistence\\Configurations\\";

            configurationManager.SetBasePath(path);

            configurationManager.AddJsonFile("PrivateInformations.json"); 

            return configurationManager.GetSection(key).Value;
        }

    }
}
