using System;
using System.Collections.Generic;
using System.Text;

namespace ChatLibrary
{
    [Serializable]
    public class HistoryMessage : Message
    {
        public List<CommonMessage> MessageHistory;
        public int ClientID;
        public HistoryMessage(DateTime dateTime, string clientIp, int clientPort, List<CommonMessage> messageHistory, int clientID) : base(dateTime, clientIp, clientPort)
        {
            MessageHistory = messageHistory;
            ClientID = clientID;
        }
    }
}
