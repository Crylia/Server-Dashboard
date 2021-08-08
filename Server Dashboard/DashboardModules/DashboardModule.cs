using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Server_Dashboard {

    /// <summary>
    /// Dashboard Module class that holds all the information that gets displayed
    /// </summary>
    internal class DashboardModule {

        //The name the user gives the module
        public string ModuleName { get; set; }

        //The user who created it
        public string Creator { get; set; }

        //All the information that the server had
        public ServerInformation ServerInfo { get; set; }

        //The status indicator
        public string StatusIndicator { get; set; }

        //The background color of the status indicator
        public string StatusIndicatorBG { get; set; }

        //If the server is avaibale or not
        public bool ServerAvailable { get; set; }

        //The Module icon the user give the server, defaults to a generic server symbol
        public BitmapImage ModuleIcon { get; set; }

        //Creation date with System.DateTime.Now
        public string CreationDate { get; set; }

        /// <summary>
        /// This will set the Module status indicator red or green if the server is available or not
        /// </summary>
        /// <param name="serverAvailable"></param>
        public DashboardModule(bool serverAvailable) {
            ServerAvailable = serverAvailable;
            StatusIndicator = ServerAvailable ? "#20c657" : "#e53935";
            StatusIndicatorBG = ServerAvailable ? "#94eeb0" : "#ef9a9a";
        }
    }
}