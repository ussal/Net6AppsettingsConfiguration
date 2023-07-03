namespace Net6AppsettingsConfiguration.Helpers
{
    public class ConfigurationHelper
    {
        private static IConfiguration _config;

        public static void Configure(IConfiguration config)
        {
            _config = config;
        }

        public static string GetConfigurationString(string Path)
        {
            return _config[Path];
        }
    }
}
