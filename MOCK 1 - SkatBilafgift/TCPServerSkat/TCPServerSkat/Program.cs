using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPServerSkat
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(ip, 6789);
            serverSocket.Start();
            Console.WriteLine("Server started");

            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated");

                 AfgiftService afgiftService = new AfgiftService(connectionSocket);
                 
                 Thread myThread = new Thread(afgiftService.AfgiftBeregning);
                 
                 myThread.Start();
            }
        }
    }
}
