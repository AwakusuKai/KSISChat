﻿using ChatLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Message = ChatLibrary.Message;



namespace ChatClient
{
    public partial class MainForm : Form
    {
        private Client client;
        

        public MainForm()
        {
            
            InitializeComponent();
            client = new Client(new BinaryMessageSerializer());
            client.UpdateClientsListEvent += UpdateDialogsList;
            client.ShowMessageEvent += ShowMessageOnTextBox;
            client.ShowPrivateMessageEvent += ShowPrivateMessageOnTextBox;
            client.ShowServerInformationEvent += AddNewServer;
            client.ShowMessagesHistoryEvent += ShowMessagesHistoryOnTextBox;
            client.SearchServers();
            
        }

        public void ShowMessagesHistoryOnTextBox(HistoryMessage historyMessage)
        {
            System.Action action = delegate
            {
                foreach (CommonMessage commonMessage in historyMessage.MessageHistory)
                {
                    chatTextBox.Text += Environment.NewLine + commonMessage.SendTime.ToString("h:mm tt") + " " + commonMessage.SenderNickname + ": " + commonMessage.MessageText;
                }
};
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        public void AddNewServer(List<ServerInformation> servers)
        { 
            System.Action action = delegate
            {
                serversListBox.Items.Clear();

                foreach (ServerInformation server in servers)
                {
                    serversListBox.Items.Add(server);
                }
            };
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        public void ShowMessageOnTextBox(CommonMessage message)
        {
            System.Action action = delegate
            {
                chatTextBox.Text += Environment.NewLine + message.SendTime.ToString("h:mm tt") + " " + message.SenderNickname + ": " + message.MessageText;
            };
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        public void ShowPrivateMessageOnTextBox(PrivateMessage message)
        {
            System.Action action = delegate
            {
                chatTextBox.Text += Environment.NewLine + message.SendTime.ToString("h:mm tt") + " " + message.SenderNickname + "[ЧАСТНО]" + ": " + message.MessageText;
            };
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        public void UpdateDialogsList(ClientsListUpdateMessage message)
        {
            System.Action action = delegate
            { 
                dialogsListBox.Items.Clear();
                

                foreach (ChatPartisipant client in message.ClientsList)
                {
                    dialogsListBox.Items.Add(client);
                }
                chatTextBox.Text += Environment.NewLine + message.SendTime.ToString("h:mm tt") + " " + message.Text;
            };
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
            

        }

        private void ShowServersButton_Click(object sender, System.EventArgs e)
        {
            serversListBox.Items.Clear();
            foreach(ServerInformation serverInformation in client.serversInfo)
            {
                serversListBox.Items.Add(serverInformation.ServerName);
            }
            //не работает исправить
        }

        private void connectButton_Click(object sender, System.EventArgs e)
        {
            if((nicknameTextBox.Text != "") && (serversListBox.SelectedItems.Count == 1))
            {
                ServerInformation server = (ServerInformation)serversListBox.Items[serversListBox.SelectedIndex];
                client.ConnectToServer(server.ServerIP, server.ServerPort, nicknameTextBox.Text);
                client.Nickname = nicknameTextBox.Text;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            client.SendCommonMessage(messageTextBox.Text);
            messageTextBox.Clear();
        }

       private void sendPrivateMessageButton_Click(object sender, EventArgs e)
        {
            ChatPartisipant recipient = (ChatPartisipant)dialogsListBox.Items[dialogsListBox.SelectedIndex];
            client.SendPrivateMessage(messageTextBox.Text, recipient.id);
            messageTextBox.Clear();
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            client.DisconnectFromServer();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.DisconnectFromServer();
        }
    }
}
