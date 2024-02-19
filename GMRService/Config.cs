using Microsoft.Extensions.Configuration;

namespace GMRService;

public class Config
{
    IConfigurationRoot Configuration;
    public Config()
    {
        // Set up configuration sources
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        Configuration = builder.Build();

        // Access configuration by key
    }

    string Get(string variable)
    {
        return Configuration?[variable];
    }
}