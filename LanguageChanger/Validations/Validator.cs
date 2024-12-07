namespace LanguageChanger.Validations
{
    public static class Validator
    {
        public static bool IsJsonFileName(string? fileName)
        {
            return fileName != null && fileName.Contains(".json");
        }
    }
}
