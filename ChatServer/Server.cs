﻿using ChatLibrary;
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
        private List<ChatPartisipant> chatPartisipants;
        private int clientID = 0;
        private List<CommonMessage> messagesHistory;

        public Server(IMessageSerializer messageSerializer)
        {
            this.messageSerializer = messageSerializer;
            clientsList = new List<ConnectedClient>();
            chatPartisipants = new List<ChatPartisipant>();
            messagesHistory = new List<CommonMessage>();
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
            Console.WriteLine(localTcpIp.ToString());
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
                            HandleConnectionMessage(messageSerializer.Deserialize(memoryStream.ToArray()), connectedSocket);
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

            if (message is CommonMessage)
            {
                CommonMessage commonMessage = (CommonMessage)message;
                messagesHistory.Add(commonMessage);
                SendMessageToAllClients(commonMessage);
            }

            if (message is PrivateMessage)
            {
                PrivateMessage privateMessage = (PrivateMessage)message;
                SendMessageToClient(privateMessage, privateMessage.recipientID);
            }

            if (message is DisconnectionMessage)
            {
                string nickname = "";

                DisconnectionMessage disconnectionMessage = (DisconnectionMessage)message;
                foreach(ConnectedClient connectedClient in clientsList)
                {
                    if (connectedClient.id == disconnectionMessage.ClientID)
                    {
                        clientsList.Remove(connectedClient);
                        break;
                    }
                        
                }

                foreach(ChatPartisipant chatPartisipant in chatPartisipants)
                {
                    if (chatPartisipant.id == disconnectionMessage.ClientID)
                    {
                        nickname = chatPartisipant.nickname;
                        chatPartisipants.Remove(chatPartisipant);
                        break;
                    }
                }

                Console.WriteLine("[" + DateTime.Now.ToString() + "]: Пользователь " + nickname + " отключился.");
                string text = "Пользователь " + nickname + " отключился.";
                SendMessageToAllClients(new ClientsListUpdateMessage(DateTime.Now, NetworkInformation.GetCurrrentHostIp().ToString(), serverPort, text, chatPartisipants));
            }
        }

        public void SendMessageToClient(Message message, int id)
        {
            foreach (ConnectedClient connectedClient in clientsList)
            {
                if(connectedClient.id == id)
                    connectedClient.tcpSocket.Send(messageSerializer.Serialize(message));
            }
        }

        public void HandleConnectionMessage(Message message, Socket connectedSocket) //обработчик сообщений
        {
            if (message is ConnectionMessage)
            {
                ConnectionMessage ConnectionMessage = (ConnectionMessage)message;
                int clientID = GetClientID();

                ConnectedClient connectedClient = new ConnectedClient(ConnectionMessage.ClientNickname, clientID, connectedSocket, messageSerializer);
                connectedClient.ReceiveMessageEvent += HandleReceivedMessage;
                clientsList.Add(connectedClient);
                connectedClient.StartListenTcp();

                chatPartisipants.Add(new ChatPartisipant(ConnectionMessage.ClientNickname, clientID));
                Console.WriteLine("[" + DateTime.Now.ToString() + "]: Пользователь " + ConnectionMessage.ClientNickname + " присоединился.");
                string text = "Пользователь " + ConnectionMessage.ClientNickname + " присоединился.";
                HistoryMessage historyMessage = new HistoryMessage(DateTime.Now, NetworkInformation.GetCurrrentHostIp().ToString(), serverPort, messagesHistory, clientID);
                connectedClient.tcpSocket.Send(messageSerializer.Serialize(historyMessage));

                SendMessageToAllClients(new ClientsListUpdateMessage(DateTime.Now, NetworkInformation.GetCurrrentHostIp().ToString(), serverPort, text, chatPartisipants));
                
            }  
        }

        private void HandleClientUdpRequestMessage(ClientUdpRequestMessage clientUdpRequestMessage)
        {
            ServerUdpAnswerMessage serverUdpAnswerMessage = new ServerUdpAnswerMessage(DateTime.Now, NetworkInformation.GetCurrrentHostIp().ToString(), serverPort, serverName);
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Parse(clientUdpRequestMessage.SenderIp), clientUdpRequestMessage.SenderPort);
            Socket serverUdpAnswerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverUdpAnswerSocket.SendTo(messageSerializer.Serialize(serverUdpAnswerMessage), clientEndPoint);
        }

        public void SendMessageToAllClients(Message message)
        {
            foreach(ConnectedClient connectedClient in clientsList)
            {  
                connectedClient.tcpSocket.Send(messageSerializer.Serialize(message));
            }
        }

        int GetClientID()
        {
            return clientID++;
        }

        
    }

    
}


