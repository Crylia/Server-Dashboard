using Server_Dashboard.Views;
using Server_Dashboard.Properties;
using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Server_Dashboard_Socket;

namespace Server_Dashboard {

    /// <summary>
    /// View Model for the Login Window
    /// </summary>
    internal class LoginViewModel : BaseViewModel, IWindowHelper {

        #region Properties

        //Username Property
        private string username;

        public string Username {
            get { return username; }
            set {
                if (username != value)
                    username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        //Error Text displays an error to help the user to fill the form
        private string errorText;

        public string ErrorText {
            get { return errorText; }
            set {
                if (errorText != value)
                    errorText = value;
                OnPropertyChanged(nameof(errorText));
            }
        }

        //Remember me button
        private bool rememberUser;

        public bool RememberUser {
            get { return rememberUser; }
            set {
                if (value != rememberUser)
                    rememberUser = value;
                OnPropertyChanged(nameof(rememberUser));
            }
        }

        //Loading circle, gets hidden and shown when logging in
        private string loading;

        public string Loading {
            get { return loading; }
            set {
                if (value != loading)
                    loading = value;
                OnPropertyChanged(nameof(loading));
            }
        }

        #endregion Properties

        #region Public Values

        //Close action for the Window to close properly
        public Action Close { get; set; }

        #endregion Public Values

        #region Constructor

        public LoginViewModel() {
            //SocketClient sc = new SocketClient();
            //Loading circle is hidden on startup
            Loading = "Hidden";
            //Command inits
            LoginCommand = new RelayCommand(LoginAsync);
            //Checks if the Username and Cookie is saved in the Settings.settings
            if (!String.IsNullOrEmpty(Settings.Default.Username) && !String.IsNullOrEmpty(Settings.Default.Cookies)) {
                //Takes the saved Username and Remember me button status and prefills the username and checks the Remember me button
                Username = Settings.Default.Username;
                RememberUser = Settings.Default.RememberMe;
            }
            //TODO: Autologin
            //AutoLoginAsync();
        }

        #endregion Constructor

        #region ICommands

        public ICommand LoginCommand { get; set; }

        #endregion ICommands

        #region Commands

        /// <summary>
        /// Async login
        /// </summary>
        /// <param name="parameter">Secure password string</param>
        private async void LoginAsync(object parameter) {
            //Checks if the Username and Password field has content
            if (!String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace((parameter as IHavePassword).SecurePassword.Unsecure())) {
                //Sets loading to true to show the loading icon
                Loading = "Visible";
                //Sends the Username and Password to the database and saved the result, 1 successfull, 0 wrong username or password
                int result = await Task.Run(() => DatabaseHandler.CheckLogin(Username, (parameter as IHavePassword).SecurePassword.Unsecure()));
                //hides the loading again
                Loading = "Hidden";
                /*result can be:
                0 for Wrong username or password
                1 for true username or password
                2 for network or database unreachable
                default error for everything else
                 */
                switch (result) {
                    case 0:
                        //Sets the error text and exits function
                        ErrorText = "Username or password is wrong.";
                        return;

                    case 1:
                        /*No idea why this is here, gonna let it be till the remember me and autologin is 100% done
                        if (RememberUser && !String.IsNullOrEmpty(Settings.Default.Cookies)) {
                            DatabaseHandler.CheckCookie(Settings.Default.Cookies, Username);
                        }*/
                        //If the remember me is not checked and a cookie exists the local storage gets cleared
                        if (!RememberUser && !String.IsNullOrEmpty(Settings.Default.Cookies)) {
                            Settings.Default.Cookies = null;
                            Settings.Default.Username = "";
                            Settings.Default.RememberMe = false;
                            Settings.Default.Password = "";
                            Settings.Default.Save();
                            //Also deletes the cookie from the database
                            DatabaseHandler.DeleteCookie(Username);
                        }
                        //If the remember user option is checked and the cookie is not set save everything locally
                        if (RememberUser && Settings.Default.Username != Username) {
                            //Creates a new GUID with the username at the end, this is the cookie
                            var cookie = $"{Guid.NewGuid().ToString()}+user:{Username}";
                            //Saves cookie, Username Remember me option to the local storage (Settings.settings)
                            Settings.Default.Cookies = cookie;
                            Settings.Default.Username = Username;
                            Settings.Default.RememberMe = true;
                            Settings.Default.Save();
                            //Saves the cookie in the database
                            DatabaseHandler.AddCookie(Username, cookie);
                        }
                        //Creates a new Dashboard window and shows it
                        DashboardWindow window = new DashboardWindow() {
                            DataContext = new DashboardViewModel(Username)
                        };
                        window.Show();
                        //Close window when dashboard is shown
                        Close?.Invoke();
                        return;

                    case 2:
                        //Sets the error text
                        ErrorText = "Server unreachable, connection timeout.";
                        return;

                    default:
                        //Sets the error text
                        ErrorText = "An unknown error has occured";
                        return;
                }
                //If the Username and password is blank
                //All these IF's could be one but i made multiple for the different errors so the user knows whats wrong
            } else if (String.IsNullOrWhiteSpace(Username) && String.IsNullOrWhiteSpace((parameter as IHavePassword).SecurePassword.Unsecure())) {
                //Sets the error text
                ErrorText = "Please provide a username and password";
                return;
            }
            //Only if the Username is empty
            if (String.IsNullOrWhiteSpace(Username)) {
                //Sets the error text
                ErrorText = "Username cannot be empty.";
                return;
            }
            //Only if the password is empty
            if (String.IsNullOrWhiteSpace((parameter as IHavePassword).SecurePassword.Unsecure())) {
                //Sets the error text
                ErrorText = "Password cannot be empty.";
                return;
            }
            //If there is no error, clear the error text
            ErrorText = "";
        }

        #endregion Commands

        #region private functions

        //TODO: Add autologin function that locks the UI untill the user hits the abort button or the login completes
        /*private async void AutoLoginAsync() {
            if (Settings.Default.RememberMe && !String.IsNullOrEmpty(Settings.Default.Username) && !String.IsNullOrEmpty(Settings.Default.Cookies)) {
                Loading = "Visible";
                int result = await Task.Run(() => DatabaseHandler.CheckCookie(Settings.Default.Cookies, Username));
                Loading = "Hidden";
                if (result == 1) {
                    DashboardWindow window = new DashboardWindow();
                    window.Show();
                    Close?.Invoke();
                    return;
                }
            }
        }*/

        #endregion private functions
    }
}