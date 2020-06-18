using System;
using System.Collections.Generic;
using System.Net;

namespace ChatLibrary
{
    [Serializable]
    public class FileCommonMessage : CommonMessage
    {
        public Dictionary<int, string> Files { get; }

        public FileCommonMessage(DateTime dateTime, string senderIp, int senderPort, string content, string clientNickname, Dictionary<int, string> files) : base(dateTime, senderIp, senderPort, content, clientNickname)
        {
            Files = files;
        }
    }
}