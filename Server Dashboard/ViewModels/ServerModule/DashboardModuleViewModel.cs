using Server_Dashboard.Views.DashboardPages.ModuleCRUD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Server_Dashboard {
    class DashboardModuleViewModel : BaseViewModel {
        public string ModuleName { get; set; }
        public string StatusIndicator { get; set; }
        public string StatusIndicatorBG { get; set; }
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