using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Server_Dashboard {
    public static class SecureStringHelpers {
        public static string Unsecure(this SecureString secureString) {
            if (secureString == null)
                return string.Empty;
            var unmanagedString = IntPtr.Zero;

            try {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            } finally {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
