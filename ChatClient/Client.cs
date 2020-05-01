using ChatLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = ChatLibrary.Message;

namespace ChatClient
{

    class Client
    {
        private const int ServerPort = 49001;
        public int id;
        //private Socket tcpSocket;
        private Socket udpSocket;
        private Thread udpListenThread;
        //private Thread listenTcpThread;
        private IMessageSerializer messageSerializer;

        public Client(IMessageSerializer messageSerializer)
        {
            this.messageSerializer = messageSerializer;
            //serversInfo = new List<ServerInfo>();
            //participants = new List<ChatParticipant>();
            //tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.EnableBroadcast = true;
            udpListenThread = new Thread(ListenUDP);
            //listenTcpThread = new Thread(ListenTcp);
        }

        public void SearchServers()
        {
            IPEndPoint broadcastEndPoint = new IPEndPoint(IPAddress.Broadcast, ServerPort);
            IPEndPoint localIp = new IPEndPoint(IPAddress.Any, 0);
            udpSocket.Bind(localIp);
            Socket sendUdpRequest = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sendUdpRequest.EnableBroadcast = true;
            sendUdpRequest.SendTo(messageSerializer.Serialize(GetClientUdpRequestMessage()), broadcastEndPoint);
            udpListenThread.Start();
        }

        private ClientUdpRequestMessage GetClientUdpRequestMessage()
        {
            IPEndPoint localIp = (IPEndPoint)udpSocket.LocalEndPoint;
            return new ClientUdpRequestMessage(DateTime.Now, NetworkInformation.GetCurrrentHostIp().ToString(), localIp.Port);
        }

        public void ListenUDP()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            EndPoint endPoint = ipEndPoint;
            int receivedDataBytesCount;
            byte[] dataBuffer;
            while (true)
            {
                dataBuffer = new byte[1024];
                using (MemoryStream receivedDataStream = new MemoryStream())
                {
                    do
                    {
                        receivedDataBytesCount = udpSocket.ReceiveFrom(dataBuffer, dataBuffer.Length, SocketFlags.None, ref endPoint);
                        receivedDataStream.Write(dataBuffer, 0, receivedDataBytesCount);
                    }
                    while (udpSocket.Available > 0);
                    if (receivedDataBytesCount > 0)
                        HandleReceivedMessage(messageSerializer.Deserialize(receivedDataStream.ToArray()));
                }

            }
        }

        public void HandleReceivedMessage(Message message)
        {
            if (message is ServerUdpAnswerMessage)
            {
                MessageBox.Show("Найден сервер!");
            }
        }

    }
}
