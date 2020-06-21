using ChatLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Message = ChatLibrary.Message;
using FileTransferLibrary;
using System.IO;

namespace ChatClient
{
    public partial class MainForm : Form
    {
        private Client client;
        private const string FileSharingServerUrl = "http://localhost:8888/";
        private FileTransferClient FileTransferClient;

        public MainForm()
        {
            FileTransferClient = new FileTransferClient();
            InitializeComponent();
            client = new Client(new BinaryMessageSerializer());
            client.UpdateClientsListEvent += UpdateDialogsList;
            client.ShowMessageEvent += ShowMessageOnTextBox;
            client.ShowPrivateMessageEvent += ShowPrivateMessageOnTextBox;
            client.ShowServerInformationEvent += AddNewServer;
            client.ShowMessagesHistoryEvent += ShowMessagesHistoryOnTextBox;
            FileTransferClient.UpdateFilesToLoadListEvent += UpdateFilesToLoadList;
            client.SearchServers();
            
        }

        private void UpdateFilesToLoadList(Dictionary<int, string> files)
        {
            attachedFilesListBox.Items.Clear();
            foreach (var file in files)
            {
                attachedFilesListBox.Items.Add(file.Value);
            }
        }

        public void ShowMessagesHistoryOnTextBox(HistoryMessage historyMessage)
        {
            System.Action action = delegate
            {
                foreach (CommonMessage commonMessage in historyMessage.MessageHistory)
                {
                    messagesListBox.Items.Add(commonMessage);
                    //chatTextBox.Text += Environment.NewLine + commonMessage.SendTime.ToString("h:mm tt") + " " + commonMessage.SenderNickname + ": " + commonMessage.MessageText;
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
                messagesListBox.Items.Add(message);
                //chatTextBox.Text += Environment.NewLine + message.SendTime.ToString("h:mm tt") + " " + message.SenderNickname + ": " + message.MessageText;
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
                messagesListBox.Items.Add(message);
                //chatTextBox.Text += Environment.NewLine + message.SendTime.ToString("h:mm tt") + " " + message.SenderNickname + "[ЧАСТНО]" + ": " + message.MessageText;
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
                messagesListBox.Items.Add(message.SendTime.ToString("h:mm tt") + " " + message.Text);
                //chatTextBox.Text += Environment.NewLine + message.SendTime.ToString("h:mm tt") + " " + message.Text;
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
            /*serversListBox.Items.Clear();
            foreach(ServerInformation serverInformation in client.serversInfo)
            {
                serversListBox.Items.Add(serverInformation.ServerName);
            }*/
        }

        private void connectButton_Click(object sender, System.EventArgs e)
        {
            if((nicknameTextBox.Text != "") && (serversListBox.SelectedItems.Count == 1))
            {
                ServerInformation server = (ServerInformation)serversListBox.Items[serversListBox.SelectedIndex];
                client.ConnectToServer(server.ServerIP, server.ServerPort, nicknameTextBox.Text);
                client.Nickname = nicknameTextBox.Text;
            }
            else
            {
                MessageBox.Show("Введите никнейм и выберите сервер для подключения!");
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (attachedFilesListBox.Items.Count == 0)
            {
                client.SendCommonMessage(messageTextBox.Text);
            }
            else
            {
                client.SendCommonFileMessage(messageTextBox.Text, FileTransferClient.filesToSendDictionary);
                FileTransferClient.totalFilesToLoadSize = 0;
                FileTransferClient.filesToSendDictionary.Clear();
                attachedFilesListBox.Items.Clear();
            }
            messageTextBox.Clear();
        }

       private void sendPrivateMessageButton_Click(object sender, EventArgs e)
        {
            if (attachedFilesListBox.Items.Count == 0)
            {
                ChatPartisipant recipient = (ChatPartisipant)dialogsListBox.Items[dialogsListBox.SelectedIndex];
                client.SendPrivateMessage(messageTextBox.Text, recipient.id);
                messageTextBox.Clear();
            }
            else
            {
                ChatPartisipant recipient = (ChatPartisipant)dialogsListBox.Items[dialogsListBox.SelectedIndex];
                client.SendPrivateFileMessage(messageTextBox.Text, recipient.id, FileTransferClient.filesToSendDictionary);
                FileTransferClient.totalFilesToLoadSize = 0;
                FileTransferClient.filesToSendDictionary.Clear();
                attachedFilesListBox.Items.Clear();
            }
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

        private async void addFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    await FileTransferClient.SendFile(filePath, FileSharingServerUrl);//добавить класс клиента файл трансфера
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message);
            }
        }

        private async void deleteFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedFileIndex = attachedFilesListBox.SelectedIndex;
                if (selectedFileIndex > -1 && selectedFileIndex < attachedFilesListBox.Items.Count)
                {
                    var fileInfo = attachedFilesListBox.Items[selectedFileIndex].ToString();
                    var fileId = FileTransferClient.GetFileIdByInfoInFilesToLoadList(fileInfo);
                    if (fileId != -1)
                    {
                        await FileTransferClient.DeleteFile(fileId, FileSharingServerUrl);
                    }
                    else
                    {
                        MessageBox.Show("Id файла с таким названием не найдено!", "Error!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message);
            }
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedFileIndex = messageFileListBox.SelectedIndex;
                if (selectedFileIndex > -1 && selectedFileIndex < messageFileListBox.Items.Count)
                {
                    var fileInfo = messageFileListBox.Items[selectedFileIndex].ToString();
                    var fileId = GetFileIdByFileInfo(fileInfo);
                    if (fileId != -1)
                    {
                        var downloadFile = await FileTransferClient.DownloadFile(fileId, FileSharingServerUrl);
                        if (downloadFile != null)
                        {
                            var saveFileDialog = new SaveFileDialog();
                            saveFileDialog.FileName = downloadFile.FileName;
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                var filePath = saveFileDialog.FileName;
                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    fileStream.Write(downloadFile.FileBytes, 0, downloadFile.FileBytes.Length);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Id файла с таким названием не найдено!", "Error!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message);
            }
        }

        private int GetFileIdByFileInfo(string fileInfo)
        {
            var files = GetFilesByMessageIndex();
            foreach (var file in files)
            {
                if (fileInfo == file.Value)
                {
                    return file.Key;
                }
            }
            return -1;
        }

        private Dictionary<int, string> GetFilesByMessageIndex()
        {
            try
            {
                Message message = (Message)messagesListBox.SelectedItem;

                if (message is FileCommonMessage)
                {
                    return (((FileCommonMessage)message).Files);
                }
                if (message is FilePrivateMessage)
                {
                    return (((FilePrivateMessage)message).Files);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        private void messagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var files = GetFilesByMessageIndex();
            if (files != null)
            {
                ShowFiles(files);
            }
        }

        private void ShowFiles(Dictionary<int, string> files)
        {
            messageFileListBox.Items.Clear();
            foreach (var file in files)
            {
                messageFileListBox.Items.Add(file.Value);
            }
        }
    }
}
