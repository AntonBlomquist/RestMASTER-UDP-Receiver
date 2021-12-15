using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace UDP_Receiver {
    class Program {
        private const int Port = 7000;
        static void Main() {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
            using (UdpClient socket = new UdpClient(ipEndPoint)) {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);
                HttpClient rest = new HttpClient();
                while (true) {
                    Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                    byte[] datagramReceived = socket.Receive(ref remoteEndPoint);
                    string receivedData = Encoding.UTF8.GetString(datagramReceived);
                    string[] splitData = receivedData.Split(' ');
                    string Classroom = "D3.06";
                    if(receivedData != null) {
                        Measure measure = new Measure(Classroom, double.Parse(splitData[0], new CultureInfo("en-UK")), Int16.Parse(splitData[1], new CultureInfo("en-UK")));
                        StringContent content = new StringContent(JsonSerializer.Serialize(measure), Encoding.UTF8, "application/json");
                        rest.PostAsync($"https://restmasterairflow.azurewebsites.net/api/Measure/{Classroom}/{splitData[0]}/{splitData[1]}", content);
                        Console.WriteLine(measure);
                    }
                }
            }
        }
    }
}