using ChatServer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatServer
{
    public class Server
    {
        private const int serverPort = 50000;
        private string serverName;
        private const int ClientsLimit = 10;
        private Socket udpSocket;
        private Socket tcpSocket;
        private Thread tcpListenThread;
        private Thread udpListenThread;
        private IMessageSerializer messageSerializer;
        private List<ConnectedClient> clientsList;

        public Server(IMessageSerializer messageSerializer)
        {
            this.messageSerializer = messageSerializer;
            clientsList = new List<ConnectedClient>();
            //messageHistory = new List<Message>();
            udpListenThread = new Thread(ListenUDP);
            tcpListenThread = new Thread(ListenTCP);
        }

        public void Start()
        {
            Console.Write("Server name: ");
            serverName = Console.ReadLine();
            if (SetupUdpAndTcpLocalIp())
            {
                Console.WriteLine("Server is ready!");
                udpListenThread.Start();
                tcpListenThread.Start();
            }
        }

        private bool SetupUdpAndTcpLocalIp()
        {
            udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.EnableBroadcast = true;
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localUdpIp = new IPEndPoint(IPAddress.Any, serverPort);
            IPEndPoint localTcpIp = new IPEndPoint(NetworkInformation.GetCurrrentHostIp(), serverPort);
            try
            {
                udpSocket.Bind(localUdpIp);
                tcpSocket.Bind(localTcpIp);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }

        }

        public void ListenUDP()
        {
            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            int receivedBytesCount;
            byte[] dataBuffer;
            while (true)
            {
                    dataBuffer = new byte[1024];
                    using (MemoryStream receivedDataStream = new MemoryStream())
                    {
                    do
                    {
                        receivedBytesCount = udpSocket.ReceiveFrom(dataBuffer, dataBuffer.Length, SocketFlags.None, ref endPoint);
                        receivedDataStream.Write(dataBuffer, 0, receivedBytesCount);
                    }
                    while (udpSocket.Available > 0);
                    if (receivedBytesCount > 0)
                        HandleReceivedMessage(messageSerializer.Deserialize(receivedDataStream.ToArray()));
                    }
            }
        }

        public void ListenTCP()
        {
            int receivedDataBytesCount;
            byte[] receivedDataBuffer;
            tcpSocket.Listen(ClientsLimit);
            while (true)
            {
                try
                {
                    Socket connectedSocket = tcpSocket.Accept();
                    receivedDataBuffer = new byte[1024];
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        do
                        {
                            receivedDataBytesCount = connectedSocket.Receive(receivedDataBuffer, receivedDataBuffer.Length, SocketFlags.None);
                            memoryStream.Write(receivedDataBuffer, 0, receivedDataBytesCount);
                        }
                        while (udpSocket.Available > 0);
                        if (receivedDataBytesCount > 0)
                            HandleReceivedMessage(messageSerializer.Deserialize(memoryStream.ToArray()));
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void HandleReceivedMessage(Message message) //обработчик сообщений
        {
            if (message is ClientUdpRequestMessage)
            {
                ClientUdpRequestMessage clientUdpRequestMessage = (ClientUdpRequestMessage)message;
                HandleClientUdpRequestMessage(clientUdpRequestMessage);
            }

            if (message is ConnectionMessage)
            {
                ConnectionMessage ConnectionMessage = (ConnectionMessage)message;
                clientsList.Add(new ConnectedClient(ConnectionMessage.ClientNickname, clientsList.Count));
                Console.WriteLine("[" + DateTime.Now.ToString() + "]: Пользователь " + ConnectionMessage.ClientNickname + "присоединился.");
            }
        }

        private void HandleClientUdpRequestMessage(ClientUdpRequestMessage clientUdpRequestMessage)
        {
            ServerUdpAnswerMessage serverUdpAnswerMessage = new ServerUdpAnswerMessage(DateTime.Now, NetworkInformation.GetCurrrentHostIp().ToString(), serverPort, serverName);
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Parse(clientUdpRequestMessage.SenderIp), clientUdpRequestMessage.SenderPort);
            Socket serverUdpAnswerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverUdpAnswerSocket.SendTo(messageSerializer.Serialize(serverUdpAnswerMessage), clientEndPoint);
        }

        
    }

    
}


