using ChatLibrary;
using System.Windows.Forms;



namespace ChatClient
{
    public partial class chatForm : Form
    {
        private Client client;

        public chatForm()
        {
            InitializeComponent();
            client = new Client(new BinaryMessageSerializer());
            client.SearchServers();
        }


    }
}
