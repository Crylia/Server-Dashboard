using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Server_Dashboard {
    class DashboardModuleViewModel : BaseViewModel {
        public ObservableCollection<DashboardModule> Modules { get; set; }
        private int gpuUsage;

        public int GPUUsage {
            get { return gpuUsage; }
            set {
                if(value != gpuUsage)
                    gpuUsage = value;
                OnPropertyChanged(nameof(gpuUsage));
            }
        }

        public DashboardModuleViewModel() {
            Modules = new ObservableCollection<DashboardModule>();
            for (int i = 0; i < 10; i++) {
                Modules.Add(new DashboardModule(true) {
                    ModuleName = "TestModule",
                    Creator = "Username",
                    ModuleIcon = "../../Assets/Images/PlaceHolderModuleLight.png",
                    CreationDate = DateTime.Now.ToString(),
                    ServerInfo = new ServerInformation() {
                        GpuUsage = "20",
                        CpuUsage = "20",
                        CpuTemp = "88.88",
                        DeployDate = DateTime.Now.ToString(),
                        GpuTemp = "69.69",
                        ServerName = "Ubuntu",
                        OSUserName = "crylia " + i,
                        PrivateIpAdress = "192.168.1.1",
                        PublicIpAdress = "85.69.102.58",
                        Uptime = DateTime.Now.ToString()
                    }
                });
            }
        }
    }
}
