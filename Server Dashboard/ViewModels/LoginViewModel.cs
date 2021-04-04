using Server_Dashboard.Views;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Windows.Input;

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
        public Action Close { get ; set; }

        public LoginViewModel() {
            LoginCommand = new RelayCommand(Login);
        }

        public ICommand LoginCommand { get; set; }

        private void Login(object parameter) {
            if (!String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace((parameter as IHavePassword).SecurePassword.Unsecure())) {
                if (DatabaseHandler.CheckLogin(Username, (parameter as IHavePassword).SecurePassword.Unsecure())) {
                    DashboardWindow window = new DashboardWindow();
                    window.DataContext = new DashboardViewModel();
                    window.Show();
                    Close?.Invoke();
                } else {
                    ErrorText = "Username or password is wrong.";
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
