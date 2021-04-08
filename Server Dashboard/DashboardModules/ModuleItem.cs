using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Server_Dashboard {
    class ModuleItem {
        public string[] HostName { get; set; } = new string[2];
        public string[] CpuTemp { get; set; } = new string[2];
        public string[] GpuTemp { get; set; } = new string[2];
        public string[] Uptime { get; set; } = new string[2];
        public string[] DeployDate { get; set; } = new string[2];
        public string[] PublicIpAdress { get; set; } = new string[2];
        public string[] PrivateIpAdress { get; set; } = new string[2];
        public string[] OSHostName { get; set; } = new string[2];

        public ModuleItem(bool isServerUp, double gpu, double cpu, DateTime uptime, string hostname, string osname, string privateip, string publicip) {
            
        }
    }
}
