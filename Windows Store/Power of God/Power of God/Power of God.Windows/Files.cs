using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Power_of_God
{
    public class Files
    {
        private const string FilePath = "power.of.god/";

        public static readonly string[] FilesStr = new string[]
        {
            FilePath,
            "userInfo.json"
        };

        public static async Task<bool> Exists(int loop)
        {
            var sFolder = GetDirectoryArrayIndex(loop);
            var fileStr = FilesStr[loop];
            try
            {
                var item = await sFolder.TryGetItemAsync(fileStr);
                return (item != null);
            }
            catch (Exception)
            {
                // Should never get here 
                return false;
            }
        }
        public static StorageFolder GetDirectoryArrayIndex(int fileIndex)
        {
            switch (fileIndex)
            {
                case 1:
                    return FolderPaths()[fileIndex];
                default:
                    return null;
            }
        }

        private static StorageFolder[] FolderPaths()
        {
            return new[] {
                StorageFolder.GetFolderFromPathAsync(FilePath).GetResults(),
                StorageFolder.GetFolderFromPathAsync("").GetResults()
            };
        }
        
        /*public static async Task<bool> Exists(int itemArray)
        {
            StorageFolder folder = GetDirectoryArrayIndex(itemArray);
            String itemName = FilesStr[itemArray];
            try
            {
                var item = await folder.TryGetItemAsync(itemName);
                return (item != null);
            }
            catch (Exception)
            {
                // Should never get here 
                return false;
            }
        }*/
    }
}
