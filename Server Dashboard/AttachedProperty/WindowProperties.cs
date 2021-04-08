using System.Windows;

namespace Server_Dashboard {
    public class CloseProperty : BaseAttachedProperty<CloseProperty, bool> {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is Window window) {
                window.Loaded += (s, e) => {
                    if (window.DataContext is IWindowHelper wh) {
                        wh.Close += () => {
                            window.Close();
                        };
                    }
                };
            }
        }
    }
}
