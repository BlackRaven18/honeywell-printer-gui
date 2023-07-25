using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIVEVMSLabels
{
    public class EthernetSettings
    {
        public EthernetSettings() { }
        public EthernetSettings(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public string ip { get; set; }
        public int port { get; set; }
    }
}
