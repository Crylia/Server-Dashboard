using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Server_Dashboard {

    internal class CreateModuleViewModel : BaseViewModel, IWindowHelper {
        private readonly string username;

        private string serverName;

        public string ServerName {
            get { return serverName; }
            set {
                if (serverName != value)
                    serverName = value;
                OnPropertyChanged(nameof(serverName));
            }
        }

        private string moduleName;

        public string ModuleName {
            get { return moduleName; }
            set {
                if (moduleName != value)
                    moduleName = value;
                OnPropertyChanged(nameof(moduleName));
            }
        }

        private string ipAdress;

        public string IPAdress {
            get { return ipAdress; }
            set {
                if (ipAdress != value)
                    ipAdress = value;
                OnPropertyChanged(nameof(ipAdress));
            }
        }

        private string port;

        public string Port {
            get { return port; }
            set {
                if (port != value)
                    port = value;
                OnPropertyChanged(nameof(port));
            }
        }

        private BitmapImage moduleIcon;

        public BitmapImage ModuleIcon {
            get { return moduleIcon; }
            set {
                if (moduleIcon != value)
                    moduleIcon = value;
                OnPropertyChanged(nameof(moduleIcon));
            }
        }

        private string userInformationMessage;

        public string UserInformationMessage {
            get { return userInformationMessage; }
            set {
                if (userInformationMessage != value)
                    userInformationMessage = value;
                OnPropertyChanged(nameof(userInformationMessage));
            }
        }

        public CreateModuleViewModel(string username) {
            this.username = username;
            CreateModuleCommand = new RelayCommand(CreateModuleAsync);
            SelectIconCommand = new RelayCommand(SelectIcon);
            RemoveIconCommand = new RelayCommand(RemoveIcon);
            TestConnectionCommand = new RelayCommand(TestConnection);
        }

        public ICommand RemoveIconCommand { get; set; }
        public ICommand SelectIconCommand { get; set; }
        public ICommand CreateModuleCommand { get; set; }
        public ICommand TestConnectionCommand { get; set; }

        public Action Close { get; set; }

        //private readonly Regex moduleNameFilter = new Regex(@"^[A-Z][a-z][0-9]{0-20}$");
        //private readonly Regex serverNameFilter = new Regex(@"^[A-Z][a-z][0-9]{0-20}$");
        private readonly Regex ipFilter = new Regex(@"^(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])$");

        /// <summary>
        /// First checks if the IP address and the other credentials are valid
        /// than asynchronously sends the data to the database where the module will be saved
        /// this also triggers a reload of all modules to make sure the newly created module
        /// will be shown without an application restart
        /// </summary>
        /// <param name="param">Nothing</param>
        private async void CreateModuleAsync(object param) {
            //Checks if the IP field is not empty and valid
            if (!String.IsNullOrWhiteSpace(ipAdress) && ipFilter.IsMatch(ipAdress)) {
                //Gives the Module a default name if the user doesnt name it
                if (String.IsNullOrWhiteSpace(moduleName))
                    moduleName = "Module";
                //Gives the Server a default name is the user doesnt name it
                if (String.IsNullOrWhiteSpace(serverName))
                    serverName = "Server";
                //Makes sure the name isnt any longer than characters
                if (moduleName.Length >= 20) {
                    UserInformationMessage = "The Module Name is too long";
                    return;
                }
                //Makes sure the name isnt any longer than characters
                if (serverName.Length >= 20) {
                    UserInformationMessage = "The Server Name is too long";
                    return;
                }
                //Clears the error message if there isnt any error
                UserInformationMessage = "";
                byte[] moduleIconStream = null;
                if (moduleIcon != null) {
                    try {
                        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(moduleIcon));
                        using MemoryStream ms = new MemoryStream();
                        encoder.Save(ms);
                        moduleIconStream = ms.ToArray();
                    } catch { }
                }
                if (await Task.Run(() => DatabaseHandler.CreateNewModule(ipAdress, moduleName, serverName, username, moduleIconStream, port)) == 0) {
                    Close?.Invoke();
                } else {
                    UserInformationMessage = "Unknown error occured, please try again later";
                }
            } else {
                UserInformationMessage = "The IP Address is invalid";
            }
        }

        /// <summary>
        /// Opens a file dialog and lets the user select a .jpg, .jpeg or .png file as icon
        /// </summary>
        /// <param name="param"></param>
        private void SelectIcon(object param) {
            OpenFileDialog ofd = new OpenFileDialog {
                Title = "Choose an Image",
                Filter = "Supported format|*.jpg;*.jpeg;*.png"
            };
            if ((bool)ofd.ShowDialog()) {
                ModuleIcon = new BitmapImage(new Uri(ofd.FileName));
            }
        }

        /// <summary>
        /// Removes the selected ModuleIcon
        /// </summary>
        /// <param name="param"></param>
        private void RemoveIcon(object param) => ModuleIcon = null;

        /// <summary>
        /// Tests the socket connection
        /// </summary>
        /// <param name="param"></param>
        private void TestConnection(object param) {
            //TODO: Test connection to the socket server
        }
    }
}