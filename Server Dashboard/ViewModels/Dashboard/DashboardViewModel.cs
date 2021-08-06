using Server_Dashboard.Views.DashboardPages.ModuleCRUD;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Server_Dashboard_Socket;
using System;

namespace Server_Dashboard {
    /// <summary>
    /// View Model for the Dashboard
    /// </summary>
    class DashboardViewModel : BaseViewModel {
        #region Private Values
        private readonly DashboardModuleViewModel dmvm = new DashboardModuleViewModel();
        #endregion

        #region Properties

        private string serverName;
        public string ServerName {
            get { return serverName; }
            set {
                if(serverName != value)
                    serverName = value;
                OnPropertyChanged(nameof(serverName));
            }
        }

        private string moduleName;
        public string ModuleName {
            get { return moduleName; }
            set {
                if (moduleName != value)
                    moduleName = value;
                OnPropertyChanged(nameof(moduleName));
            }
        }

        private string ipAdress;
        public string IPAdress {
            get { return ipAdress; }
            set {
                if (ipAdress != value)
                    ipAdress = value;
                OnPropertyChanged(nameof(ipAdress));
            }
        }

        private string port;
        public string Port {
            get { return port; }
            set {
                if (port != value)
                    port = value;
                OnPropertyChanged(nameof(port));
            }
        }

        //The Username displayed defaults to Username
        private string userName = "Username";
        public string UserName {
            get { return userName; }
            set { 
                if(userName != value)
                    userName = value;
                OnPropertyChanged(nameof(userName));
            }
        }

        //List that contains every Module
        private ObservableCollection<DashboardModule> modules;
        public ObservableCollection<DashboardModule> Modules {
            get { return modules; }
            set {
                if(value != modules)
                    modules = value;
                OnPropertyChanged(nameof(modules));
            }
        }
        #endregion

        #region Constructor
        public DashboardViewModel() {
            //Creates a new echo server, remove b4 release
            EchoServer echoServer = new EchoServer();
            echoServer.Start();
            //Command inits
            OpenLinkCommand = new RelayCommand(OpenLink);
            OpenNewModuleWindowCommand = new RelayCommand(OpenNewModuleWindow);
            CreateModuleCommand = new RelayCommand(CreateModule);
            //Sets the local module to the dashboardviewmodule modules
            Modules = dmvm.Modules;
        }
        #endregion

        #region ICommands
        public ICommand OpenLinkCommand { get; set; }
        public ICommand OpenNewModuleWindowCommand { get; set; }
        public ICommand CreateModuleCommand { get; set; }
        #endregion

        #region Commands
        /// <summary>
        /// Opens a given link in the default browser
        /// </summary>
        /// <param name="param">The Link to be opened e.g. https://github.com/Crylia/Server-Dashboard </param>
        private void OpenLink(object param) {
            Process.Start(new ProcessStartInfo((string)param) { UseShellExecute = true });
        }
        
        /// <summary>
        /// Creates a new window to create a new Module
        /// </summary>
        /// <param name="param">Nothing</param>
        private void OpenNewModuleWindow(object param) {
            //Creates a new CreateModulePopup and sets this view model as datacontext
            CreateModulePopup cmp = new CreateModulePopup {
                DataContext = this
            };
            //Opens it in the middle of the screen, setting the parent window as owner causes the 
            //application to crash when NOT in debug mode(???)
            cmp.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cmp.ShowDialog();
        }

        /// <summary>
        /// No function yes
        /// </summary>
        /// <param name="param">Nothing</param>
        private void CreateModule(object param) {
            if (!String.IsNullOrWhiteSpace(IPAdress)) {
                
            } else {
                //error
            }
        }
        #endregion
    }
}
