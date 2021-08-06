using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Server_Dashboard {
    /// <summary>
    /// Secure string helper class to unsecure the Password b4 it goes to the database
    /// </summary>
    public static class SecureStringHelpers {
        //Unsecures a given password
        public static string Unsecure(this SecureString secureString) {
            //If empty return nothing
            if (secureString == null)
                return string.Empty;
            //New zero pointer
            var unmanagedString = IntPtr.Zero;

            //Try to unsecure the string
            try {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            } finally {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
