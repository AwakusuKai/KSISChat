using ChatServer;
using System.Collections.Generic;
using System.Windows.Forms;



namespace ChatClient
{
    public partial class MainForm : Form
    {
        private Client client;
        

        public MainForm()
        {
            InitializeComponent();
            client = new Client(new BinaryMessageSerializer());
            client.SearchServers();
        }

        private void ShowServersButton_Click(object sender, System.EventArgs e)
        {
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
            }
        }
    }
}
