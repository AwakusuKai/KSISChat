using System;
using System.Collections.Generic;
using System.Text;

namespace ChatLibrary
{
    [Serializable]
    public class ChatPartisipant
    {
        public string nickname;
        public int id;

        public ChatPartisipant(string nickname, int id)
        {
            this.nickname = nickname;
            this.id = id;
        }
    }
}
