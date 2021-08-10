using Server_Dashboard.Views.DashboardPages.ModuleCRUD;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Server_Dashboard {

    /// <summary>
    /// View Model for the Dashboard
    /// </summary>
    internal class DashboardViewModel : BaseViewModel {

        #region Private Values

        private DashboardModuleViewModel dmvm;

        #endregion Private Values

        #region Properties

        //The Username displayed defaults to Username
        private User user;

        public User User {
            get { return user; }
            set {
                if (user != value)
                    user = value;
                OnPropertyChanged(nameof(user));
            }
        }

        //List that contains every Module
        private ObservableCollection<ModuleData> modules;

        public ObservableCollection<ModuleData> Modules {
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
            //Command init
            OpenLinkCommand = new RelayCommand(OpenLink);
            OpenNewModuleWindowCommand = new RelayCommand(OpenNewModuleWindow);

            DataTable userData = DatabaseHandler.GetUserData(username);
            User = new User(userData);
            GetModules();
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
        private static void OpenLink(object param) => Process.Start(new ProcessStartInfo((string)param) { UseShellExecute = true });

        /// <summary>
        /// Creates a new window to create a new Module
        /// </summary>
        /// <param name="param">Nothing</param>
        private void OpenNewModuleWindow(object param) {
            //Creates a new CreateModulePopup and sets this view model as data context
            CreateModulePopup cmp = new CreateModulePopup {
                DataContext = new CreateModuleViewModel(User.UserName)
            };
            //Opens it in the middle of the screen, setting the parent window as owner causes the
            //application to crash when NOT in debug mode(???)
            cmp.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cmp.ShowDialog();
            GetModules();
        }

        private void GetModules() {
            dmvm = new DashboardModuleViewModel(DatabaseHandler.GetUserModuleData(User.UID));
            //Sets the local module to the dashboard view module modules
            Modules = dmvm.Modules;
        }

        #endregion Commands
    }
}