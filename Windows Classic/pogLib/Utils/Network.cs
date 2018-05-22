using System;
using System.Net;

namespace pogLib.Utils
{
    public class Network
    {
        public static string cool = "";
        /// Executes supplied url
        /// </summary>
        /// <param name="url">The url to be executed</param>
        /// <param name="response">Response from the server, or from the system</param>
        /// <returns>Returns true if successful, false if unsuccessful</returns>
        public static bool ExecuteUrl(string url, out string response)
        {
            try
            {
                var client = new WebClient();
                response = client.DownloadString(url);
                cool = response;
                return true;
            }
            catch (Exception ex)
            {
                response = ex.ToString() + "\n" + ex.StackTrace;
                cool = response;
                return false;
            }
        }
    }
}
