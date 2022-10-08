using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace InfinityLauncher.Types.Files
{
    public class LocalFile : ILauncherFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Hash { get; set; }
        public long Size { get; set; }
        private string folderPath = Settings.Default.LauncherFolder;

        public LocalFile(string _name, string _path)
        {
            Name = _name;
            Path = _path.Replace(folderPath + @"\","");
            Hash = GetHashOfFile(_path);
            Size = GetSizeOfFile(_path);
        }

        private string GetHashOfFile(string filePath)
        {
            MD5 md5Hasher = MD5.Create();
            var stream = File.OpenRead(filePath);
            var hash = md5Hasher.ComputeHash(stream);
            string hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            return hashString;
        }

        private long GetSizeOfFile(string filePath)
        {
            long length = new FileInfo(filePath).Length;
            return length;
        }
    }
}
