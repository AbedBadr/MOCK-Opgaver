using System;
using System.IO;
using System.Net.Sockets;

namespace TCPClientSkat
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Client ready");

            Stream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            while (true)
            {
                Console.WriteLine("Indtast Personbil eller Elbil efterfulgt af prisen");

                string message = Console.ReadLine();
                sw.WriteLine(message);

                if (message == "STOP" || message == "stop") break;

                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer + "\n");
            }

            Console.WriteLine("No more from server. Press Enter");
            Console.ReadKey();

            ns.Close();
            clientSocket.Close();
        }
    }
}
