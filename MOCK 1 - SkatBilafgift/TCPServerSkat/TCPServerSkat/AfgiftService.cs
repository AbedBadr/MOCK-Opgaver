using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Skat;

namespace TCPServerSkat
{
    class AfgiftService
    {
        private TcpClient _connectionSocket;

        public AfgiftService(TcpClient connection)
        {
            _connectionSocket = connection;
        }

        public void AfgiftBeregning()
        {
            Stream ns = _connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            while (true)
            {
                string message = sr.ReadLine();
                Console.WriteLine("Client: " + message);


                string[] data = message.Split(' ');
                string bilType = data[0];
                int pris = Convert.ToInt32(data[1]);

                sw.WriteLine(BilAfgift(bilType, pris));
            }
        }

        public string BilAfgift(string bilType, int pris)
        {
            int bilAfgift = 0;

            if (bilType == "Personbil" || bilType == "personbil")
            {
                bilAfgift = Afgift.BilAfgift(pris);
            }

            else if (bilType == "Elbil" || bilType == "elbil")
            {
                bilAfgift = Afgift.ElBilAfgift(pris);
            }

            string answer = "Registreringsafgiften er: " + bilAfgift.ToString();
            return answer;
        }
    }
}
