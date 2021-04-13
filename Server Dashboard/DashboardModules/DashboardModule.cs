using System;
using System.Collections.Generic;
using System.Text;

namespace Server_Dashboard {
    class DashboardModule {
        public string ModulName { get; set; }
        public string Creator { get; set; }
        public ServerInformation ServerInfo { get; set; }
        public string StatusIndicator { get; set; }
        public string StatusIndicatorBG { get; set; }
        public bool ActiveConnection { get; set; }
        public string ModuleIcon { get; set; }

        public DashboardModule(bool activeConnection) {
            ActiveConnection = activeConnection;
            StatusIndicator = ActiveConnection ? "#20c657" : "#e53935";
            StatusIndicatorBG = ActiveConnection ? "#94eeb0" : "#ef9a9a";
        }
    }
}
