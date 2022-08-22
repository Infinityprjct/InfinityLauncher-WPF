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
        public string name;
        public string ip;
        public string iconURL;
        public string xamlPageURL;
        //TODO

        public Server(string _name,string _ip, string _iconURL, string _xamlPageURL)
        {
            name = _name;
            ip = _ip;
            iconURL = _iconURL;
            xamlPageURL = _xamlPageURL;
        }
    }
}
