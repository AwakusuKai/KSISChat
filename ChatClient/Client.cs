using ChatServer;
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
using Message = ChatServer.Message;

namespace ChatClient
{

    class Client
    {
        private const int ServerPort = 50000;
        public int id;
        private Socket tcpSocket;
        private Socket udpSocket;
        private Thread udpListenThread;
        private Thread listenTcpThread;
        private IMessageSerializer messageSerializer;
        public List<ServerInformation> serversInfo;

        public Client(IMessageSerializer messageSerializer)
        {
            this.messageSerializer = messageSerializer;
            serversInfo = new List<ServerInformation>();
            //participants = new List<ChatParticipant>();
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.EnableBroadcast = true;
            udpListenThread = new Thread(ListenUDP);
            listenTcpThread = new Thread(ListenTcp);
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

        public void ListenTcp()
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
                        HandleReceivedMessage(messageSerializer.Deserialize(memoryStream.ToArray()));
                }
            }
        }

        public List<ServerInformation> GetServersList()
        {
            return serversInfo;
        }

        public void AddServerInformation(ServerUdpAnswerMessage serverUdpAnswerMessage)
        {
            ServerInformation currentServer = new ServerInformation(serverUdpAnswerMessage.SenderIp, serverUdpAnswerMessage.ServerName, serverUdpAnswerMessage.SenderPort);
            serversInfo.Add(currentServer);
        }

        public void HandleReceivedMessage(Message message)
        {
            if (message is ServerUdpAnswerMessage)
            {
                AddServerInformation((ServerUdpAnswerMessage)message);
            }
        }

        public void ConnectToServer(int serverIndex, string clientName)
        {
            if ((serverIndex >= 0) && (serverIndex <= serversInfo.Count - 1))
            {
                IPEndPoint serverIPEndPoint = new IPEndPoint(IPAddress.Parse(serversInfo[serverIndex].ServerIP), serversInfo[serverIndex].ServerPort);
                tcpSocket.Connect(serverIPEndPoint);
                listenTcpThread.Start();
                SendMessage(GetConnectionMessage(clientName));
            }
        }

        public void SendMessage(Message message)
        {
            tcpSocket.Send(messageSerializer.Serialize(message));
        }

        private ConnectionMessage GetConnectionMessage(string clientName)
        {
            IPEndPoint clientIp = (IPEndPoint)(tcpSocket.LocalEndPoint);
            return new ConnectionMessage(DateTime.Now, clientIp.Address.ToString(), clientIp.Port, clientName);
        }

    }
}
