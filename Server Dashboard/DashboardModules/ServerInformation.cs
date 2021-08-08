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

        //The ServerName
        public string ServerName { get; set; }

        //The unix or windows username
        public string OSUserName { get; set; }

        //Cpu Temp in C
        public string CpuTemp { get; set; }

        //Gpu Temp in C
        public string GpuTemp { get; set; }

        //Server uptime
        public string Uptime { get; set; }

        //When the server was first deployed
        public string DeployDate { get; set; }

        //Public IPv4 Adress
        public string PublicIpAdress { get; set; }

        //Private IP adress from the servers network
        public string PrivateIpAdress { get; set; }

        //GPU usage in %
        public string GpuUsage { get; set; }

        //CPU usage in %
        public string CpuUsage { get; set; }
    }
}