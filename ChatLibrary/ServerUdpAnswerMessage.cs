using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary
{
    [Serializable]
    public class ServerUdpAnswerMessage : Message
    {
        public string ServerName { get; }
        public List<CommonMessage> messagesHistory;
        public ServerUdpAnswerMessage(DateTime dateTime, string serverIp, int serverPort, string serverName) : base(dateTime, serverIp, serverPort)
        {
            ServerName = serverName;
        }
    }
}
