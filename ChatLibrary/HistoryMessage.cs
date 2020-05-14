using System;
using System.Collections.Generic;
using System.Text;

namespace ChatLibrary
{
    [Serializable]
    public class HistoryMessage : Message
    {
        public List<CommonMessage> MessageHistory;

        public HistoryMessage(DateTime dateTime, string clientIp, int clientPort, List<CommonMessage> messageHistory) : base(dateTime, clientIp, clientPort)
        {
            MessageHistory = messageHistory;
        }
    }
}
