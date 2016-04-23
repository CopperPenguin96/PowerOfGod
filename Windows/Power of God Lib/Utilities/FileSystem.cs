using System.IO;
using System.Reflection;

namespace Power_of_God_Lib.Utilities
{
    public class FileSystem
    {
        private const string Main = "power.of.god/";

        private static string[] _fileList =
        {
            Main + "settings.json"
        };

        public static string BaseDir()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return directoryName?.Replace("\\", "/");
        }

        public static void DeleteAllFilesInDirectory(string targetDir)
        {
            var files = Directory.GetFiles(targetDir);
            var dirs = Directory.GetDirectories(targetDir);

            foreach (var file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
               // DeleteAllFilesInDirectory(dir);
            }

            //Directory.Delete(targetDir, false);
        }
    }
}
