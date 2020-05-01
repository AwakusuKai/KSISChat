using System;
using System.Net;

namespace ChatLibrary
{
    [Serializable]
    public abstract class Message
    {
        public DateTime SendTime { get; }

        public string SenderIp { get; }

        public int SenderPort { get; }

        public Message(DateTime dateTime, string senderIp, int senderPort)
        {
            SendTime = dateTime;
            SenderIp = senderIp;
            SenderPort = senderPort;
        }
    }
}
