using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Server_Dashboard {
    class ServerInformation {
        public string ServerName { get; set; }
        public string HostName { get; set; }
        public string CpuTemp { get; set; }
        public string GpuTemp { get; set; }
        public string Uptime { get; set; }
        public string DeployDate { get; set; }
        public string PublicIpAdress { get; set; }
        public string PrivateIpAdress { get; set; }
        public string OSHostName { get; set; }
    }
}
