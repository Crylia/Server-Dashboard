using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace Server_Dashboard {

    /// <summary>
    /// View Model for the modules
    /// </summary>
    internal class DashboardModuleViewModel : BaseViewModel {

        //List with all Modules inside
        public ObservableCollection<DashboardModule> Modules { get; set; }

        //Creates Default Modules, remove before release and when implementing the actual data comming from the socket
        public DashboardModuleViewModel(DataTable userdata) {
            GetModules(userdata);
        }

        public void GetModules(DataTable userdata) {
            Modules = new ObservableCollection<DashboardModule>();
            foreach (DataRow row in userdata.Rows) {
                BitmapImage moduleIcon = null;
                if (row[5] != DBNull.Value) {
                    using MemoryStream ms = new MemoryStream((byte[])row[5]);
                    moduleIcon = new BitmapImage();
                    moduleIcon.BeginInit();
                    moduleIcon.StreamSource = ms;
                    moduleIcon.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    moduleIcon.CacheOption = BitmapCacheOption.OnLoad;
                    moduleIcon.EndInit();
                    moduleIcon.Freeze();
                }
                Modules.Add(new DashboardModule(true) {
                    ModuleName = (string)row[4],
                    Creator = (string)row[1],
                    ModuleIcon = moduleIcon,
                    CreationDate = DateTime.Now.ToString(),
                    ServerInfo = new ServerInformation() {
                        GpuUsage = "20",
                        CpuUsage = "20",
                        CpuTemp = "88.88",
                        DeployDate = DateTime.Now.ToString(),
                        GpuTemp = "69.69",
                        ServerName = "Ubuntu",
                        OSUserName = "crylia ",
                        PrivateIpAdress = "192.168.1.1",
                        PublicIpAdress = "85.69.102.58",
                        Uptime = DateTime.Now.ToString()
                    }
                });
            }
        }
    }
}