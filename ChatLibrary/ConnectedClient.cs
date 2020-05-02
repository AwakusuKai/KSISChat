using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
    public class ConnectedClient
    {
        public string nickname;
        public int id;
        
        public ConnectedClient(string nickname, int id)
        {
            this.nickname =nickname;
            this.id = id;
        } 
    }
}
