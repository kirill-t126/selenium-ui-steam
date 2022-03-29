using Microsoft.Extensions.Configuration;

namespace FindGames.Framework.Utils
{
    internal static class ConfigUtil
    {
        public const string pathToDriverConfig = "Resources/driverconfig.json";
        public const string pathToTestsConfig = "Resources/testsconfig.json";

        public static string GetValueByName(string configKey)
        {
            var configTests = new ConfigurationBuilder()
                .AddJsonFile(pathToDriverConfig)
                .AddJsonFile(pathToTestsConfig)
                .Build();
            IConfigurationSection section = configTests.GetSection(configKey);
            return section.Value;
        }
    }
}