using ChatLibrary;
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
        private const int serverPort = 49001;
        private string serverName;
        private Socket udpSocket;
        private Thread udpListenThread;
        private IMessageSerializer messageSerializer;

        public Server(IMessageSerializer messageSerializer)
        {
            this.messageSerializer = messageSerializer;
            //clients = new List<ClientHandler>();
            //messageHistory = new List<Message>();
            udpListenThread = new Thread(ListenUDP);
            //listenTcpThread = new Thread(ListenTcp);
        }

        public void Start()
        {
            Console.Write("Server name: ");
            serverName = Console.ReadLine();
            if (SetupUdpAndTcpLocalIp())
            {
                Console.WriteLine("Server is ready!");
                udpListenThread.Start();
                //listenTcpThread.Start();
            }
        }

        private bool SetupUdpAndTcpLocalIp()
        {
            udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.EnableBroadcast = true;
            //tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localUdpIp = new IPEndPoint(IPAddress.Any, serverPort);
            //IPEndPoint localTcpIp = new IPEndPoint(CommonFunctions.GetCurrrentHostIp(), ServerPort);
            try
            {
                udpSocket.Bind(localUdpIp);
                //tcpSocket.Bind(localTcpIp);
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

        public void HandleReceivedMessage(Message message) //обработчик сообщений
        {
            if (message is ClientUdpRequestMessage)
            {
                ClientUdpRequestMessage clientUdpRequestMessage = (ClientUdpRequestMessage)message;
                HandleClientUdpRequestMessage(clientUdpRequestMessage);
            } 
        }

        private void HandleClientUdpRequestMessage(ClientUdpRequestMessage clientUdpRequestMessage)
        {
            ServerUdpAnswerMessage serverUdpAnswerMessage = new ServerUdpAnswerMessage(DateTime.Now, NetworkInformation.GetCurrrentHostIp().ToString(), serverPort, serverName);
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Parse(clientUdpRequestMessage.SenderIp), clientUdpRequestMessage.SenderPort);
            Socket serverUdpAnswerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverUdpAnswerSocket.SendTo(messageSerializer.Serialize(serverUdpAnswerMessage), clientEndPoint);
            Console.WriteLine("Сообщение получено");
        }

        
    }

    
}


