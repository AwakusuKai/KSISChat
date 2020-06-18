using System;
using ChatLibrary;
using FileTransferLibrary;

namespace ChatServer
{
    class Program
    {
        private const string FileSharingServerUrl = "http://localhost:8888/";
        static void Main(string[] args)
        {
            Server server = new Server(new BinaryMessageSerializer());  
            server.Start();
            FileTransferServer fileTransferServer = new FileTransferServer(FileSharingServerUrl);
            fileTransferServer.Start();
        }
    }
}
