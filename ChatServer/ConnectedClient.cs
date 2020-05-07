using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ChatLibrary;

namespace ChatServer
{
    [Serializable]
    public class ConnectedClient
    {
        public string nickname;
        public int id;
        public Socket tcpSocket;
        private Thread listenTcpThread;
        public delegate void ReceiveMessageDelegate(Message message);
        public event ReceiveMessageDelegate ReceiveMessageEvent;
        private IMessageSerializer messageSerializer;

        public ConnectedClient(string nickname, int id, Socket tcpSocket, IMessageSerializer messageSerializer)
        {
            this.nickname =nickname;
            this.id = id;
            this.tcpSocket = tcpSocket;
            this.messageSerializer = messageSerializer;
            

        }

        public void StartListenTcp()
        {
            listenTcpThread = new Thread(ListenTcp);
            listenTcpThread.Start();
        }

        private void ListenTcp()
        {
            int receivedDataBytesCount;
            byte[] receivedDataBuffer;
            while (true)
            {
                receivedDataBuffer = new byte[1024];
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    do
                    {
                        receivedDataBytesCount = tcpSocket.Receive(receivedDataBuffer, receivedDataBuffer.Length, SocketFlags.None);
                        memoryStream.Write(receivedDataBuffer, 0, receivedDataBytesCount);
                    }
                    while (tcpSocket.Available > 0);
                    if (receivedDataBytesCount > 0)
                        ReceiveMessageEvent(messageSerializer.Deserialize(memoryStream.ToArray()));
                }
            }
        }
    }
}
