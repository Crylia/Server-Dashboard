using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace Server_Dashboard {
    class DatabaseHandler {
        #region Private methods
        /// <summary>
        /// Opens a database connection
        /// </summary>
        /// <param name="callback">Callback type SqlConnection</param>
        /// <returns></returns>
        private SqlConnection ConnectToDatabase(Action<SqlConnection> callback) {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Co2AuswertungDB"].ConnectionString)) {
                try {
                    con.Open();
                    callback(con);
                    con.Close();
                } catch { return null; }
            }
            return null;
        }
        #endregion
    }
}
