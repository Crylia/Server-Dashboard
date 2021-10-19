using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Server_Dashboard {

    /// <summary>
    /// Interface that makes a SecurePassword go one way
    /// </summary>
    public interface IHavePassword {
        SecureString SecurePassword { get; }
    }
}