using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Server_Dashboard {
    class DashboardModuleViewModel : BaseViewModel {

        private ObservableCollection<DashboardModule> modules;

        public ObservableCollection<DashboardModule> Modules {
            get { return modules; }
            set {
                if (modules != value)
                    modules = value;
                OnPropertyChanged(nameof(modules));
            }
        }

        public DashboardModuleViewModel() {
            Modules = new ObservableCollection<DashboardModule>();
            for (int i = 0; i < 1; i++) {
                Modules.Add(new DashboardModule() {
                    Creator = "Ersteller TestUser",
                    ModulName = "TestName",
                    ModuleIcon = "../../Assets/Images/PlaceHolderModuleLight.png",
                    Width = new Random().Next(300, 400),
                    Height = new Random().Next(100, 400),
                });
            }
            var sort = Modules.OrderBy(h => h.Height).ThenBy(w => w.Width).ToList();
            Modules = new ObservableCollection<DashboardModule>(sort);
        }
        #region Dashboard CRUD
        private void CreateDashboard() {

        }
        private void UpdateDashboard() {

        }
        private void GetDashboardInformation() {

        }
        private void DeleteDashboard() {

        }
        #endregion
    }
}