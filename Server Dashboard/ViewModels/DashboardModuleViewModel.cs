using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Server_Dashboard {
    class DashboardModuleViewModel : BaseViewModel {
        public ObservableCollection<DashboardModule> Modules = new ObservableCollection<DashboardModule>();
        public DashboardModuleViewModel() {

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