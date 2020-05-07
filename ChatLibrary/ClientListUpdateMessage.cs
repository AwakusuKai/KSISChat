using ChatLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatLibrary
{
    [Serializable]
    public class ClientsListUpdateMessage : Message
    {
        public List<ChatPartisipant> ClientsList;
        public string Text;
        public ClientsListUpdateMessage(DateTime dateTime, string clientIp, int clientPort, string text, List<ChatPartisipant> clientsList) : base(dateTime, clientIp, clientPort)
        {
            Text = text;
            ClientsList = clientsList;
        }
    }
}
