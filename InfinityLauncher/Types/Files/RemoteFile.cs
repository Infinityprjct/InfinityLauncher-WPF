using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Types.Files
{
    public class RemoteFile : ILauncherFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Hash { get; set; }
        public long Size { get; set; }

        public RemoteFile(string _name, string _path, string _hash, long _size)
        {
            Name = _name;
            Path = _path;
            Hash = _hash;
            Size = _size;
        }


    }
}
