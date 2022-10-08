using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Types.Files
{
    public interface ILauncherFile
    {
        string Name { get; set; }
        string Path { get; set; }
        string Hash { get; set; }
        long Size { get; set; }
    }
}
