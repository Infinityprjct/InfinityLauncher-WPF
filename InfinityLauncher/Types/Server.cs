using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InfinityLauncher.Types
{
    public class Server
    {
        public int id;
        public string Name;
        public string ip;
        public string iconURL;
        public Page serverPage;
        //TODO

        public Server(string _name,string _ip, string _iconURL, Page _serverPage)
        {
            Name = _name;
            ip = _ip;
            iconURL = _iconURL;
            serverPage = _serverPage;
        }
    }
}
