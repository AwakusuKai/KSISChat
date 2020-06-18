using ChatLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatLibrary
{
    [Serializable]
    public class PrivateMessage : Message
    {
        public string MessageText;
        public string SenderNickname;
        public int recipientID;

        public PrivateMessage(DateTime dateTime, string clientIp, int clientPort, string messageText, string senderNickName, int recipientID) : base(dateTime, clientIp, clientPort)
        {
            MessageText = messageText;
            SenderNickname = senderNickName;
            this.recipientID = recipientID;
        }

        public override string ToString() { return SendTime.ToString("h:mm tt") + " " + SenderNickname + "[ЧАСТНО]" + ": " + MessageText; }
    }
}
