using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Server_Dashboard {
    class DashboardModuleViewModel : BaseViewModel {
        public ObservableCollection<DashboardModule> ModuleList { get; set; }
        public DashboardModuleViewModel() {
            ModuleList = new ObservableCollection<DashboardModule>();
            for (int i = 0; i < 10; i++) {
                ModuleList.Add(new DashboardModule(false) {
                    ModulName = "TestModule",
                    Creator = "Username",
                    ModuleIcon = "../../Assets/Images/PlaceHolderModuleLight.png",
                    ServerInfo = new ServerInformation() {
                        CpuTemp = "88.88",
                        DeployDate = DateTime.Now.ToString(),
                        GpuTemp = "69.69",
                        HostName = "crylia",
                        OSHostName = "Ubuntu",
                        PrivateIpAdress = "192.168.1.1",
                        PublicIpAdress = "85.69.102.58",
                        Uptime = DateTime.Now.ToString()
                    }
                });
            }
        }
    }
}
