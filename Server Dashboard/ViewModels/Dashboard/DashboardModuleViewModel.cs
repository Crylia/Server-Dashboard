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
        public ObservableCollection<ModuleData> Modules { get; set; }

        //Creates Default Modules, remove before release and when implementing the actual data coming from the socket
        public DashboardModuleViewModel(DataTable moduleData) {
            Modules = new ObservableCollection<ModuleData>();
            foreach (DataRow row in moduleData.Rows) {
                if (row[0] == null)
                    return;
                byte[] iconBytes = row[3] == DBNull.Value ? null : (byte[])row[3];
                DataTable serverData = DatabaseHandler.GetServerData((int)row[4]);
                ServerInformation serverInformation = null;
                if (serverData.Rows.Count != 0) {
                    DataRow serverRow = serverData.Rows[0];
                    serverInformation = new ServerInformation {
                        ServerName = (string)serverRow[4] ?? "",
                        PublicIpAddress = (string)serverRow[6] ?? "",
                        PrivateIpAddress = (string)serverRow[5] ?? "",
                        Uptime = (TimeSpan)serverRow[7],
                        OsUserName = (string)serverRow[3] ?? ""
                    };
                }
                Modules.Add(new ModuleData(false) {
                    ModuleName = (string)row[2] ?? "",
                    Creator = (string)row[0] ?? "",
                    ModuleIcon = ConvertByteToBitmapImage(iconBytes),
                    CreationDate = (DateTime)row[1],
                    ServerInformation = serverInformation
                });
            }
        }

        private static BitmapImage ConvertByteToBitmapImage(byte[] icon) {
            if (icon == null)
                return null;
            try {
                using MemoryStream ms = new MemoryStream(icon);
                BitmapImage moduleIcon = new BitmapImage();
                moduleIcon.BeginInit();
                moduleIcon.StreamSource = ms;
                moduleIcon.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                moduleIcon.CacheOption = BitmapCacheOption.OnLoad;
                moduleIcon.EndInit();
                moduleIcon.Freeze();
                return moduleIcon;
            } catch { }
            return null;
        }
    }
}