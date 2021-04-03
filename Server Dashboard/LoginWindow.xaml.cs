using System;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace Server_Dashboard {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IHavePassword {
        public LoginWindow() {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        public SecureString SecurePassword => Password.SecurePassword;

    }
}
