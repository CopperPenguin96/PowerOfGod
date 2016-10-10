using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Power_of_God_Lib.Utilities
{
    public class StringHelper
    {
        public static string ReplaceSwears(string str)
        {
            var url = "http://godispower.us/Application/Users/words/words.php?word=fish&string=" + str;
            var client = new WebClient();
            var html = client.DownloadData(url);
            var utf = new UTF8Encoding();
            return utf.GetString(html);
        }

        public static string[] GetWords(string input)
        {
            var matches = Regex.Matches(input, @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select TrimSuffix(m.Value);

            return words.ToArray();
        }

        public static string TrimSuffix(string word)
        {
            var apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }
        #region MD5
        public static string GetMd5Hash(HashAlgorithm md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(HashAlgorithm md5Hash, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            var comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }

        public static int[] GetOccurences(string mainStr, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            var indexes = new List<int>();
            for (var index = 0; ; index += value.Length)
            {
                index = mainStr.IndexOf(value, index);
                if (index == -1)
                    return indexes.ToArray();
                indexes.Add(index);
            }
        }
        #endregion
    }
}
