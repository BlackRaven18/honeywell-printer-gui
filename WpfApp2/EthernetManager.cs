using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VIVEVMSLabels
{
    class EthernetManager
    {
        public static void sendStringByEthernet(string ip, int port, string message)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(ip, port);

                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        stream.Write(data, 0, data.Length);
                        Debug.WriteLine("Wysłano na Ethernet");
                    }
                }
            } catch(Exception e) 
            {
                Debug.WriteLine("Zgłoszono wyjątek!: " +e.Message);
            }

        }
    }
}
