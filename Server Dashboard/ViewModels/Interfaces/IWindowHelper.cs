using System;
using System.Collections.Generic;
using System.Text;

namespace Server_Dashboard {
    interface IWindowHelper {
        Action Close { get; set; }
    }
}
