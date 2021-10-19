using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Server_Dashboard {

    /// <summary>
    /// Server information class, this will probably scale pretty big later on
    /// This will hold all the information the socket will gather
    /// </summary>
    internal class ServerInformation {
        public string ServerName { get; set; }
        public string OsUserName { get; set; }
        public double CpuTemp { get; set; }
        public double GpuTemp { get; set; }
        public TimeSpan Uptime { get; set; }
        public DateTime DeployDate { get; set; }
        public string PublicIpAddress { get; set; }
        public string PrivateIpAddress { get; set; }
        public int GpuUsage { get; set; }
        public int CpuUsage { get; set; }
        public double NetworkUP { get; set; }
        public double NetworkDown { get; set; }
    }
}