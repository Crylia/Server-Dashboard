using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Server_Dashboard {

    internal class ModuleData {

        //The name the user gives the module
        public string ModuleName { get; set; }

        //The user who created it
        public string Creator { get; set; }

        //The status indicator
        public string StatusIndicator { get; set; }

        //The background color of the status indicator
        public string StatusIndicatorBG { get; set; }

        //If the server is avaibale or not
        public bool ServerAvailable { get; set; }

        //The Module icon the user give the server, defaults to a generic server symbol
        public BitmapImage ModuleIcon { get; set; }

        //Creation date with System.DateTime.Now
        public DateTime CreationDate { get; set; }

        //List that contains all the serverinformation over a period of time(lifespan of the module)
        public ServerInformation ServerInformation { get; set; }

        /// <summary>
        /// This will set the Module status indicator red or green if the server is available or not
        /// </summary>
        /// <param name="serverAvailable"></param>
        public ModuleData(bool serverAvailable) {
            ServerAvailable = serverAvailable;
            StatusIndicator = ServerAvailable ? "#20c657" : "#e53935";
            StatusIndicatorBG = ServerAvailable ? "#94eeb0" : "#ef9a9a";
        }
    }
}