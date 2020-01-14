using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MeasurementUDPReceiver
{
    class UdpReceiver
    {
        static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(7001);

            IPAddress ip = IPAddress.Parse("255.255.255.255");
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 7001);

            try
            {
                Console.WriteLine("Server is blocked");
                while (true)
                {
                    Byte[] receiveBytes = udpServer.Receive(ref remoteIpEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    string[] data = receivedData.Split('\n');
                    string timeStampLine = data[0];
                    string humidityLine = data[1];
                    string pressureLine = data[2];
                    string temperatureLine = data[3];

                    string[] timeStampData = timeStampLine.Split('*');
                    string timeStampText = timeStampData[0];
                    DateTime timeStamp = Convert.ToDateTime(timeStampData[1]);

                    string[] humidityData = humidityLine.Split(':');
                    string humidityText = humidityData[0];
                    int humidity = Convert.ToInt32(humidityData[1]);

                    string[] pressureData = pressureLine.Split(':');
                    string pressureText = pressureData[0];
                    int pressure = Convert.ToInt32(pressureData[1]);

                    string[] temperatureData = temperatureLine.Split(':');
                    string temperatureText = temperatureData[0];
                    double temperature = Convert.ToDouble(temperatureData[1]);

                    Console.WriteLine("From broadcast: ");
                    Console.WriteLine(receivedData);

                    Console.WriteLine(timeStamp + "\n" +
                                      humidity + "\n" +
                                      pressure + "\n" +
                                      temperature + "\n");

                    /*Console.WriteLine("This message was sent from " +
                                      remoteIpEndPoint.Address.ToString() +
                                      " on their port number " +
                                      remoteIpEndPoint.Port.ToString() + "\n");*/
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
