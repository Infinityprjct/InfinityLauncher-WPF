using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Model
{
    /// <summary>
    ///  Account class is represent information of player to launcher
    ///  
    /// </summary>
    public class Account
    {
        public Int64 id { get; set; }
        public string email { get; set; }
        public string nickname { get; set; }
        public string uuid { get; set; }


        public Account(Int64 _id,string _email, string _nickname, string _uuid)
        {
            id = _id;
            email = _email;
            nickname = _nickname;
            uuid = _uuid;
            
        }
    }
}
