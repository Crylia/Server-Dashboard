using System;
using System.Collections.Generic;
using System.Text;

namespace Server_Dashboard {
    class DashboardModule {
        public string Name { get; set; }
        public string Creator { get; set; }
        public DateTime Uptime { get; set; }
        public ModuleItem ModuleItem { get; set; }
        public DashboardModule() {
            ModuleItem = new ModuleItem();
        }
    }
}
