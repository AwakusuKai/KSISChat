using System;
using System.Collections.Generic;
using System.Text;

namespace ChatLibrary
{
    [Serializable]
    public class DisconnectionMessage : Message
    {
        public int ClientID;

        public DisconnectionMessage(DateTime dateTime, string clientIp, int clientPort, int clientID) : base(dateTime, clientIp, clientPort)
        {
            ClientID = clientID;
        }
    }
}
