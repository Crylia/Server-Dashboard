using System;
using System.Collections.Generic;
using System.Text;

namespace Server_Dashboard {
    /// <summary>
    /// Interface to help close a window with a button
    /// </summary>
    interface IWindowHelper {
        Action Close { get; set; }
    }
}
