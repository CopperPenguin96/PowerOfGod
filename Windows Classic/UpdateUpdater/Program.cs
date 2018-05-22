using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UpdateUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Delete("Updater.exe");
            File.Delete("Newtonsoft.Json.dll");
            File.Delete("updaterVersion.txt");
            using (var client = new WebClient())
            {
                client.DownloadFile("http://godispower.us/Application/Update/Download/Updater.zip", "Updater.zip");
            }
            ZipFile.ExtractToDirectory("Updater.zip", Directory.GetCurrentDirectory());
            using (var client = new WebClient())
            {
                client.DownloadFile("http://godispower.us/Application/Update/UpdaterVersion.txt", "updaterVersion.txt");
            }
            Process.Start("Power of God.exe");
            
        }
    }
}
