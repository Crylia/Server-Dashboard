using Server_Dashboard.Views.DashboardPages.ModuleCRUD;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Server_Dashboard {
    class DashboardViewModel : BaseViewModel {
        private string userName = "Username";
        private DashboardModuleViewModel dmvm = new DashboardModuleViewModel();

        public string UserName {
            get { return userName; }
            set { 
                if(userName != value)
                    userName = value;
                OnPropertyChanged(nameof(userName));
            }
        }

        private ObservableCollection<DashboardModule> modules;

        public ObservableCollection<DashboardModule> Modules {
            get { return modules; }
            set {
                if(value != modules)
                    modules = value;
                OnPropertyChanged(nameof(modules));
            }
        }

        public DashboardViewModel() {
            OpenLinkCommand = new RelayCommand(OpenLink);
            CreateNewModuleCommand = new RelayCommand(CreateNewModule);
            Modules = dmvm.Modules;

        }

        public ICommand OpenLinkCommand { get; set; }
        public ICommand CreateNewModuleCommand { get; set; }

        private void OpenLink(object param) {
            Process.Start(new ProcessStartInfo((string)param) { UseShellExecute = true });
        }

        private void CreateNewModule(object param) {
            CreateModulePopup cmp = new CreateModulePopup {
                DataContext = this
            };
            cmp.Owner = Application.Current.MainWindow;
            cmp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            cmp.ShowDialog();
        }
    }
}
