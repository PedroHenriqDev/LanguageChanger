using Microsoft.Extensions.Configuration;

namespace LanguageChanger.Extensions;

public static class ConfigurationExtension
{
    public static IEnumerable<KeyValuePair<string, string?>> SectionToKeyValuePairs(this IConfiguration configuration, string section)
    {
        return configuration.AsEnumerable().Where(s => s.Key.Split(":")[0] == section && s.Value != null).ToList();
    }
}
