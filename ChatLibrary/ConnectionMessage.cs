using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ChatServer
{
    [Serializable]
    public class ConnectionMessage : Message
    {
        public string ClientNickname;

        public ConnectionMessage(DateTime dateTime, string clientIp, int clientPort, string clientNickname) : base(dateTime, clientIp, clientPort)
        {
            ClientNickname = clientNickname;
        }
    }
}
