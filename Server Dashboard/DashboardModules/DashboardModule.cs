using System;
using System.Collections.Generic;
using System.Text;

namespace Server_Dashboard {
    class DashboardModule {
        public string ModulName { get; set; }
        public string Creator { get; set; }
        public ModuleItem ServerInfo { get; set; }
        public string StatusIndicator { get; set; }
        public string StatusIndicatorBG { get; set; }

        public DashboardModule() {
            StatusIndicator = true ? "#20c657" : "#e53935";
            StatusIndicatorBG = true ? "#94eeb0" : "#ef9a9a";
            ServerInfo = new ModuleItem(true, 88.88, 69.69, DateTime.Now, "sudo", "Archlinux", "192.168.1.100", "84.102.25.96");
        }
    }
}
