namespace LanguageChanger.Models
{
    public class LanguageTrackerConfig
    {
        public LanguageTrackerConfig(string baseDirectory = "Languages", string defaultLanguage = "English", string fileNameDefault = "Main")
        {
            BaseDirectory = baseDirectory;
            DefaultLanguage = defaultLanguage;
            FileNameDefault = fileNameDefault;
        }

        public string BaseDirectory { get; set; }
        public string DefaultLanguage { get; set; }
        public string FileNameDefault { get; set; }
        public string GetExtensionJson() => ".json"; 
    }
}
