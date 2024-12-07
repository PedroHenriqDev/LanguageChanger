namespace LanguageChanger.Tracker
{
    public interface ILanguageTracker
    {
        string? GetText(string key, string? fileName = null, string? language = null);
        Dictionary<string, string?> GetTexts(string section, string? fileName = null, string? language = null);
    }
}
