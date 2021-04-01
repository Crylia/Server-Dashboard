using System;
using System.Collections.Generic;
using System.Text;

namespace Server_Dashboard {
    class ModuleItem {
        public string Name { get; set; }
        public double CpuTemp { get; set; }
        public double GpuTemp { get; set; }
        public DateTime Uptime { get; set; }
    }
}
