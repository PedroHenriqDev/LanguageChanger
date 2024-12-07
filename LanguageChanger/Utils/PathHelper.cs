using System.Text;

namespace LanguageChanger.Utils
{
    public static class PathHelper
    {
        public static string GetPath(params string?[] directories)
        {
            StringBuilder sb = new StringBuilder();

            DirectoryInfo? directoryInfo = GetBaseDirectory();

            string? baseDirectory = directoryInfo?.FullName.Split("bin")[0];

            sb.Append(baseDirectory);

            foreach (string? directory in directories)
                sb.Append($"/{directory}");

            return sb.ToString();
        }

        public static DirectoryInfo? GetBaseDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo? parentDirectory = Directory.GetParent(baseDirectory)?.Parent;
            return parentDirectory;
        }
    }
}
