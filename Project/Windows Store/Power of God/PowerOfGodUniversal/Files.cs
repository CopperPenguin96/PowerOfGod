using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PowerOfGodUniversal
{
    public class Files
    {
        private const string _mainPath = "ms-appdata:///local/power.of.god/";

        public static readonly List<string> ListFiles = new List<string>
        {
            _mainPath, // 0
            _mainPath + "userInfo.powerinfo", // 1
            _mainPath + "logins.txt", // 2
            _mainPath + "lastopen.txt", // 3
            _mainPath + "settings.json", // 4
            _mainPath + "KJV.xml", // 5
            _mainPath + "ESV.xml", // 6
            _mainPath + "NIV.xml", // 7
            _mainPath + "NLT.xml", // 8
            _mainPath + "dailyscripture.json", // 9
            _mainPath + "lastds.txt", // 10
            "test.txt" // 11
        };

        public static List<string> FilesStr()
        {
            //TODO CHECK FOR FILE EXISTING
            if (!Directory.Exists(ListFiles.ElementAt(0)))
            {
                Directory.CreateDirectory(ListFiles.ElementAt(0));
            }
            return ListFiles;
        }

        public async static Task<bool> FileExists(int file)
        {
            var folder = StorageFolder.GetFolderFromPathAsync(_mainPath).GetResults();
            try
            {
                var item = await folder.TryGetItemAsync(ListFiles.ElementAt(11));
                return (item != null);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /*public async Task<bool> IfStorageItemExist(StorageFolder folder, string itemName)
        {
            folder = StorageFolder.GetFolderFromPathAsync()
            try
            {
                var item = await folder.TryGetItemAsync(itemName);
                return (item != null);
            }
            catch (Exception ex)
            {
                // Should never get here 
                return false;
            }
        }*/
    }
}
