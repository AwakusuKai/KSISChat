using ChatLibrary;
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
            client.SearchServers();
        }

        public void ShowMessageOnTextBox(CommonMessage message)
        {
            System.Action action = delegate
            {
                chatTextBox.Text += message.SenderNickname + ": " + message.MessageText + Environment.NewLine;
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
                    dialogsListBox.Items.Add(client.nickname);
                }
                chatTextBox.Text = chatTextBox.Text + Environment.NewLine + message.Text;
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
        }

        private void connectButton_Click(object sender, System.EventArgs e)
        {
            if(nicknameTextBox.Text != "")
            {
                client.ConnectToServer(serversListBox.SelectedIndex, nicknameTextBox.Text);
                client.Nickname = nicknameTextBox.Text;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            client.SendCommonMessage(messageTextBox.Text);
            messageTextBox.Clear();
        }
    }
}
