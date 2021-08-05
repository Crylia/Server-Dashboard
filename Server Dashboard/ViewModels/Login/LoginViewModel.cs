using Server_Dashboard.Views;
using Server_Dashboard.Properties;
using System;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Server_Dashboard {
    class LoginViewModel : BaseViewModel, IWindowHelper {

        private string username;

        public string Username {
            get { return username; }
            set {
                if (username != value)
                    username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        private string errorText;

        public string ErrorText {
            get { return errorText; }
            set {
                if (errorText != value)
                    errorText = value;
                OnPropertyChanged(nameof(errorText));
            }
        }

        private bool rememberUser;

        public bool RememberUser {
            get { return rememberUser; }
            set {
                if(value != rememberUser)
                    rememberUser = value;
                OnPropertyChanged(nameof(rememberUser));
            }
        }

        private string loading;

        public string Loading {
            get { return loading; }
            set {
                if (value != loading)
                    loading = value;
                OnPropertyChanged(nameof(loading));
            }
        }

        public Action Close { get ; set; }

        public LoginViewModel() {
            Loading = "Hidden";
            LoginCommand = new RelayCommand(LoginAsync);
            if (!String.IsNullOrEmpty(Settings.Default.Username)) {
                Username = Settings.Default.Username;
                RememberUser = Settings.Default.RememberMe;
            }
        }

        public ICommand LoginCommand { get; set; }

        private async void LoginAsync(object parameter) {
            if (!String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace((parameter as IHavePassword).SecurePassword.Unsecure())) {
                int result = 0;
                if (RememberUser && !String.IsNullOrEmpty(Settings.Default.Username) && !String.IsNullOrEmpty(Settings.Default.Cookies) && Settings.Default.Password.Length == 6) {
                    result = await Task.Run(() => DatabaseHandler.CheckCookie(Settings.Default.Cookies, Username));
                }
                Loading = "Visible";
                result = await Task.Run(() => DatabaseHandler.CheckLogin(Username, (parameter as IHavePassword).SecurePassword.Unsecure()));
                Loading = "Hidden";
                switch (result) {
                    case 0:
                        ErrorText = "Username or password is wrong.";
                        return;
                    case 1:
                        if (RememberUser && !String.IsNullOrEmpty(Settings.Default.Cookies)) {
                            DatabaseHandler.CheckCookie(Settings.Default.Cookies, Username);
                        }
                        if (!RememberUser && !String.IsNullOrEmpty(Settings.Default.Cookies)) {
                            Settings.Default.Cookies = null;
                            Settings.Default.Username = "";
                            Settings.Default.RememberMe = false;
                            Settings.Default.Password = "";
                            Settings.Default.Save();
                            DatabaseHandler.DeleteCookie(Username);
                        }
                        if (RememberUser && String.IsNullOrEmpty(Settings.Default.Cookies)) {
                            var guid = new Guid().ToString() + Username;
                            Settings.Default.Cookies = guid;
                            Settings.Default.Username = Username;
                            Settings.Default.RememberMe = true;
                            Settings.Default.Password = "*****";
                            Settings.Default.Save();
                            DatabaseHandler.AddCookie(Username, guid);
                        }
                        DashboardWindow window = new DashboardWindow();
                        window.Show();
                        Close?.Invoke();
                        return;
                    case 2:
                        ErrorText = "Server unreachable, connection timeout.";
                        return;
                    default:
                        ErrorText = "An unknown error has occured";
                        return;
                }
            } else if (String.IsNullOrWhiteSpace(Username) && String.IsNullOrWhiteSpace((parameter as IHavePassword).SecurePassword.Unsecure())) {
                ErrorText = "Please provide a username and password";
                return;
            }
            if (String.IsNullOrWhiteSpace(Username)) {
                ErrorText = "Username cannot be empty.";
                return;
            }
            if (String.IsNullOrWhiteSpace((parameter as IHavePassword).SecurePassword.Unsecure())) {
                ErrorText = "Password cannot be empty.";
                return;
            }
            ErrorText = "";
        }
    }
}
