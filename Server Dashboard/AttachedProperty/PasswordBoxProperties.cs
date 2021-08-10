using System.Windows;
using System.Windows.Controls;

namespace Server_Dashboard {

    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool> {

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (!(sender is PasswordBox passwordBox))
                return;
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if (!(bool)e.NewValue)
                return;
            HasTextProperty.SetValue(passwordBox);
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e) {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool> {

        public static void SetValue(DependencyObject sender) {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length < 1);
        }
    }
}