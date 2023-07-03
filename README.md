# Net6AppsettingsConfiguration
Calling string data in appsettings.json with static class in .Net 6

If you want to get a value from appsettings.json in .Net 6, you can follow the steps below.

## appsettings.json
```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "Application": {
        "configText": "I am a config Text"
    },
    "AllowedHosts": "*"
}
```

I want to get configText value

## ConfigurationHelper.cs (Compose a new class in Helpers folder)
```csharp
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
```


## Program.cs (Run the void function)
```csharp
//Static ConfigurationHelper set configure interface
ConfigurationHelper.Configure(app.Services.GetService<IConfiguration>());
```


## HomeController.cs (Now you can use static class)
```csharp
public IActionResult Index()
        {
            //Getting configuration string
            var configText = ConfigurationHelper.GetConfigurationString("Application:configText");
            //Send data to View
            ViewData["configText"] = configText;
            return View();
        }
```

