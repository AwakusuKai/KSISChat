using System;
using ChatLibrary;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(new BinaryMessageSerializer());  //дописать конструктор для сервера с сериализацией
            server.Start();
            //while (true)
            //{
            //    string serverCommand = Console.ReadLine();
            //    if (serverCommand == "stop")
            //        server.Close();
            //}
        }
    }
}
