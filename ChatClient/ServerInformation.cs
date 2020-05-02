using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class ServerInformation
    {
        public string ServerIP;
        public string ServerName;
        public int ServerPort;

        public ServerInformation(string serverIP, string serverName, int serverPort)
        {
            ServerIP = serverIP;
            ServerName = serverName;
            ServerPort = serverPort;
        }
    }
}
