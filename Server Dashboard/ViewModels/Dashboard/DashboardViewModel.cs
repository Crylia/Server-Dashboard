using Server_Dashboard.Views.DashboardPages.ModuleCRUD;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Server_Dashboard_Socket;
using System;
using System.Data;

namespace Server_Dashboard {

    /// <summary>
    /// View Model for the Dashboard
    /// </summary>
    internal class DashboardViewModel : BaseViewModel {

        #region Private Values

        private readonly DashboardModuleViewModel dmvm;

        #endregion Private Values

        #region Properties

        //The Username displayed defaults to Username
        private string userName;

        public string UserName {
            get { return userName; }
            set {
                if (userName != value)
                    userName = value;
                OnPropertyChanged(nameof(userName));
            }
        }

        //List that contains every Module
        private ObservableCollection<DashboardModule> modules;

        public ObservableCollection<DashboardModule> Modules {
            get { return modules; }
            set {
                if (value != modules)
                    modules = value;
                OnPropertyChanged(nameof(modules));
            }
        }

        #endregion Properties

        #region Constructor

        public DashboardViewModel(string username) {
            UserName = username;
            //Command inits
            OpenLinkCommand = new RelayCommand(OpenLink);
            OpenNewModuleWindowCommand = new RelayCommand(OpenNewModuleWindow);

            DataTable Userdata = DatabaseHandler.GetUserData(username);
            dmvm = new DashboardModuleViewModel(Userdata);
            //Sets the local module to the dashboardviewmodule modules
            Modules = dmvm.Modules;
        }

        #endregion Constructor

        #region ICommands

        public ICommand OpenLinkCommand { get; set; }
        public ICommand OpenNewModuleWindowCommand { get; set; }

        #endregion ICommands

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
                DataContext = new CreateModuleViewModel(UserName)
            };
            //Opens it in the middle of the screen, setting the parent window as owner causes the
            //application to crash when NOT in debug mode(???)
            cmp.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cmp.ShowDialog();
        }

        #endregion Commands
    }
}