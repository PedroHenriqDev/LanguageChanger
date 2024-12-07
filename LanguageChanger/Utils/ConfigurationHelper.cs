using Microsoft.Extensions.Configuration;

namespace LanguageChanger.Utils;

public static class ConfigurationHelper
{
    public static IConfiguration CreateConfiguration(string baseDirectory, string? language, string? fileName)
    {
        return new ConfigurationBuilder().SetBasePath(PathHelper.GetPath(baseDirectory, language)).AddJsonFile(fileName!).Build();
    }
}
