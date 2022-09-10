using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InfinityLauncher.Utils.Hash
{
    public class FolderHasher
    {
        /// <summary>
        /// Recursive intendent function. Updating string of all files hashes.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentMD5"></param>
        /// <returns></returns>
        private static void GetMD5FromSubdirectories(string path, ref List<string> filesMD5)
        {
            MessageBox.Show("Starting in " + path);
            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (var folder in dir.GetDirectories())
            {
                foreach (FileInfo file in folder.GetFiles())
                {
                    MD5 md5Hasher = MD5.Create();
                    var stream = File.OpenRead(file.FullName);
                    var hash = md5Hasher.ComputeHash(stream);
                    filesMD5.Add(BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant());
                }
                GetMD5FromSubdirectories(path + "\\" + folder.Name, ref filesMD5);
            }

        }

        /// <summary>
        /// Get MD5 of folder. Method returns hash of string, which contains all file hashes from
        /// files in directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Hash string</returns>
        public static string GetFolderMD5(string path)
        {
            MD5 folderMD5 = MD5.Create();
            List<string> filesMD5 = new List<string>();
            byte folderMD5Hash;

            GetMD5FromSubdirectories(path, ref filesMD5);

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo file in dir.GetFiles())
            {
                // MD5 from file in head directory
                MD5 md = MD5.Create();
                var stream = File.OpenRead(file.FullName);
                var hash = md.ComputeHash(stream);
                filesMD5.Add(BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant());
            }

            string filesMD5String = "";
            filesMD5.Sort();
            foreach (string hash in filesMD5)
            {
                filesMD5String += hash;
            }
            // Convert string (containts hashes) to MD5 Hash
            byte[] inputBytes = Encoding.ASCII.GetBytes(filesMD5String);
            byte[] hashBytes = folderMD5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes).ToLower();

        }
    }
}
