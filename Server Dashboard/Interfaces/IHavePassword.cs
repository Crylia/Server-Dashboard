using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Server_Dashboard {
    public interface IHavePassword {
        SecureString SecurePassword { get; }
    }
}
