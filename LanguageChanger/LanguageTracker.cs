using LanguageChanger.Extensions;
using LanguageChanger.Entities;
using LanguageChanger.Resources;
using LanguageChanger.Tracker;
using LanguageChanger.Utils;
using LanguageChanger.Validations;
using Microsoft.Extensions.Configuration;

namespace LanguageChanger;

public class LanguageTracker : ILanguageTracker
{

    public readonly LanguageTrackerConfig _Config;

    public LanguageTracker(LanguageTrackerConfig config)
    {
        _Config = config;
    }

    public string? GetText(string key, string? fileName = null, string? language = null)
    {
        key = key.ExecuteIf(string.IsNullOrEmpty(key), () => throw new ArgumentNullException(string.Format(MessagesResource.NULL_PARAMETER, nameof(key))));
        
        language = language.ExecuteIf(string.IsNullOrEmpty(language), () => _Config.DefaultLanguage);

        fileName = fileName.ExecuteIf(string.IsNullOrEmpty(fileName), () => _Config.FileNameDefault);

        fileName = fileName.ExecuteIf(!Validator.IsJsonFileName(fileName), () => fileName + _Config.GetExtensionJson());

        IConfiguration configuration = ConfigurationHelper.CreateConfiguration(_Config.BaseDirectory, language, fileName);          

        return configuration[key];
    }

    public Dictionary<string, string?> GetTexts(string section, string? fileName = null, string? language = null)
    {
 
        section = section.ExecuteIf(string.IsNullOrEmpty(section), () => throw new ArgumentNullException(string.Format(MessagesResource.NULL_PARAMETER, nameof(section))));

        language = language.ExecuteIf(string.IsNullOrEmpty(language), () => _Config.DefaultLanguage);

        fileName = fileName.ExecuteIf(string.IsNullOrEmpty(fileName), () => _Config.FileNameDefault);

        fileName = fileName.ExecuteIf(!Validator.IsJsonFileName(fileName), () => fileName + _Config.GetExtensionJson());

        IConfiguration configuration = ConfigurationHelper.CreateConfiguration(_Config.BaseDirectory, language, fileName);

        IEnumerable<KeyValuePair<string, string?>> foundedSection = configuration.SectionToKeyValuePairs(section);

        var sectionDict = foundedSection.ToDictionary(s => s.Key, s => s.Value);

        return sectionDict;
        
    }
}
