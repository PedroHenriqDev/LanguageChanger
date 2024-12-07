using LanguageChanger.Models;
using LanguageChanger.Utils;
using LanguageChanger.Validations;
using Microsoft.Extensions.Configuration;

namespace LanguageChanger;

public class LanguageTracker
{

    public readonly LanguageTrackerConfig _Config;

    public LanguageTracker(LanguageTrackerConfig config)
    {
        _Config = config;
    }

    public string? GetText(string key, string? fileName = null, string? language = null)
    {
        if (fileName == null)
            fileName = _Config.FileNameDefault;

        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException($"The {nameof(key)} parameter is null or empty.");

        if (string.IsNullOrEmpty(language))
            language = _Config.DefaultLanguage;

        if (!Validator.IsJsonFileName(fileName))
            fileName += _Config.GetExtensionJson();

        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(PathHelper.GetPath(_Config.BaseDirectory, language)).AddJsonFile(fileName).Build();

        return configuration[key];
    }
}
