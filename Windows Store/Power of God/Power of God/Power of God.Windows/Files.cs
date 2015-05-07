using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Power_of_God
{
    public class Files
    {
        public static string FilePath()
        {
            return ApplicationData.Current.LocalFolder.Path + "\\power.of.god\\";
        }

        private static StorageFolder FilePathStorageFolder()
        {
            return ApplicationData.Current.LocalFolder;
        }

        public async static void CreateMainDir()
        {
            try
            {
                await FilePathStorageFolder().CreateFolderAsync("power.of.god", CreationCollisionOption.ReplaceExisting);
            }
            catch (ArgumentException e)
            {
                var baseException = e.GetBaseException();
                await new MsgBox(baseException.ToString(), baseException.StackTrace).ShowDialog();
            }
        }

        public static readonly string[] FilesStr = {
            "power.of.god\\",
            "power.of.god\\userInfo.json"
        };

        //arrayIndex should equal the item in FilesStr needing to be checked
        public static async Task<bool> Exists(int arrayIndex)
        {
            String fileName = FilesStr[arrayIndex];
            var fileExists = true;
            Stream fileStream = null;

            try
            {
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                fileStream = await file.OpenStreamForReadAsync();
                fileStream.Dispose();
            }
            catch (FileNotFoundException)
            {
                // If the file dosn't exits it throws an exception, make fileExists false in this case 
                fileExists = false;
            }
            finally
            {
                fileStream?.Dispose();
            }

            return fileExists;
        }
    }
}
