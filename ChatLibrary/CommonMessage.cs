using ChatLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatLibrary
{
    [Serializable]
    public class CommonMessage : Message
    {
        public string MessageText;
        public string SenderNickname;

        public CommonMessage(DateTime dateTime, string clientIp, int clientPort, string messageText, string senderNickName) : base(dateTime, clientIp, clientPort)
        {
            MessageText = messageText;
            SenderNickname = senderNickName;
        }
    }
}
