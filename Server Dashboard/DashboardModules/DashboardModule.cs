using System;
using System.Collections.Generic;
using System.Text;

namespace Server_Dashboard {
    class DashboardModule {
        public string ModuleName { get; set; }
        public string Creator { get; set; }
        public ServerInformation ServerInfo { get; set; }
        public string StatusIndicator { get; set; }
        public string StatusIndicatorBG { get; set; }
        public bool ServerAvailable { get; set; }
        public string ModuleIcon { get; set; }
        public string CreationDate { get; set; }

        public DashboardModule(bool serverAvailable) {
            ServerAvailable = serverAvailable;
            StatusIndicator = ServerAvailable ? "#20c657" : "#e53935";
            StatusIndicatorBG = ServerAvailable ? "#94eeb0" : "#ef9a9a";
        }
    }
}
