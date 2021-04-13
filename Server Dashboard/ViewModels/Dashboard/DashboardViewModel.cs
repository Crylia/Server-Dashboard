using System.Diagnostics;
using System.Windows.Input;

namespace Server_Dashboard {
    class DashboardViewModel : BaseViewModel {
        private string userName = "Username";

        public string UserName {
            get { return userName; }
            set { 
                if(userName != value)
                    userName = value;
                OnPropertyChanged(nameof(userName));
            }
        }

        public DashboardViewModel() {
            OpenLinkCommand = new RelayCommand(OpenLink);
        }

        public ICommand OpenLinkCommand { get; set; }

        private void OpenLink(object param) {
            Process.Start(new ProcessStartInfo((string)param) { UseShellExecute = true });
        }
    }
}
