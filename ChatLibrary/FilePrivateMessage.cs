using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary
{
    [Serializable]
    public class FilePrivateMessage : PrivateMessage
    {
        public Dictionary<int, string> Files { get; }

        public FilePrivateMessage(DateTime dateTime, string senderIp, int senderPort, string content, string clientNickname, int receiverId, Dictionary<int, string> files) : base(dateTime, senderIp, senderPort, content, clientNickname, receiverId)
        {
            Files = files;
        }
    }
}
