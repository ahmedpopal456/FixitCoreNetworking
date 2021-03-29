
namespace Fixit.Core.Networking.Utils
{
    public static class StringUtils
    {
        public static string TrimCharacter(string str, char charToTrim = '/')
        {
            return str.Trim(charToTrim);
        }
        public static string ToAzureDirectoryPath(string directory)
        {
            return directory.Replace('\\', '/');
        }
    }
}
