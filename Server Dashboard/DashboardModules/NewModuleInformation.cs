using System;
using System.Collections.Generic;
using System.Text;

namespace Server_Dashboard.DashboardModules {
    /// <summary>
    /// The Information the user puts into the CreateNewModule form
    /// </summary>
    class NewModuleInformation {
        //The Name of the Module
        public string ModuleName { get; set; }
        //The Name of the Server
        public string ServerName { get; set; }
        //The Username
        public string Username { get; set; }
        //IPv4 Adress
        public string IPAdress { get; set; }
        //Port, defaults to 22
        public int Port { get; set; }
    }
}
