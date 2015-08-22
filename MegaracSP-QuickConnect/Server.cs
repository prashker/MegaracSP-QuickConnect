using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaracSP_QuickConnect
{
    public class Server
    {
        public String host { get; set; }
        public String username { get; set; }
        public String password { get; set; }

        public Server()
        {
            host = "";
            username = "";
            password = "";
        }

        public Server(String host, String username, String password)
        {
            this.host = host;
            this.username = username;
            this.password = password;
        }

    }

}
