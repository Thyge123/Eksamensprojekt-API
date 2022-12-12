using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Eksamensprojekt_API.Model
{
    public class UDPReceiver
    {
        public static readonly List<TrashCan> Data = new List<TrashCan>();

        // https://msdn.microsoft.com/en-us/library/tst0kwb1(v=vs.110).aspx
        // IMPORTANT Windows firewall must be open on UDP port 7000
        // https://www.windowscentral.com/how-open-port-windows-firewall
        // Use the network MGV-xxx to capture from local IoT devices (fake or real)
        private const int Port = 12000;

        // private static readonly IPAddress IpAddress = IPAddress.Parse("192.168.24.151");

        // Listen for activity on all network interfaces
        // https://msdn.microsoft.com/en-us/library/system.net.ipaddress.ipv6any.aspx
        public static void Main()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
            using (UdpClient socket = new UdpClient(ipEndPoint))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);
                //while (true)
                //{
                Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

                string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
                    remoteEndPoint.Address, remoteEndPoint.Port, message);
                Parse(message);
                //}
            }
        }

        private static void Parse(string response)
        {
            string[] parts = response.Split(' ');
            //foreach (string part in parts)
            //{
            //    Console.WriteLine(part);
            //}

            // Console.WriteLine(response);

            TrashCan trashcan = JsonSerializer.Deserialize<TrashCan>(response);
            trashcan.Id = trashcan.Id++;
            Data.Add(trashcan);
        }
    }
}