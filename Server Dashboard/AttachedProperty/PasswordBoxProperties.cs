using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Server_Dashboard {
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool> {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            var passwordBox = sender as PasswordBox;
            if (passwordBox == null)
                return;
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool)e.NewValue) {
                HasTextProperty.SetValue(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
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
    public class CloseProperty : BaseAttachedProperty<CloseProperty, bool> {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if(sender is Window window) {
                window.Loaded += (s, e) => {
                    if(window.DataContext is IWindowHelper wh) {
                        wh.Close += () => {
                            window.Close();
                        };
                    }
                };
            }
        }
    }
}
