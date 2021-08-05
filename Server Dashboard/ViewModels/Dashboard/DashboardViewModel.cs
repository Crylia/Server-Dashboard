using Server_Dashboard.Views.DashboardPages.ModuleCRUD;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Server_Dashboard_Socket;

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
            EchoServer echoServer = new EchoServer();
            echoServer.Start();
            OpenLinkCommand = new RelayCommand(OpenLink);
            OpenNewModuleWindowCommand = new RelayCommand(OpenNewModuleWindow);
            CreateModuleCommand = new RelayCommand(CreateModule);
            Modules = dmvm.Modules;
        }

        public ICommand OpenLinkCommand { get; set; }
        public ICommand OpenNewModuleWindowCommand { get; set; }
        public ICommand CreateModuleCommand { get; set; }
        private void OpenLink(object param) {
            Process.Start(new ProcessStartInfo((string)param) { UseShellExecute = true });
        }

        private void OpenNewModuleWindow(object param) {
            CreateModulePopup cmp = new CreateModulePopup {
                DataContext = this
            };
            cmp.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cmp.ShowDialog();
        }
        private void CreateModule(object param) {
            
        }
    }
}
