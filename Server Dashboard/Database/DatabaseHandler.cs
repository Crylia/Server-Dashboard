using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Server_Dashboard {
    public static class DatabaseHandler {

        public static DataTable GetServerInformation() {

            return null;
        }

        public static bool CheckLogin(string uname, string passwd) {
            string valid = "False";
            ConnectToDatabase(con => {
                string query = "EXEC ValidateUserLogin @Username = @uname, @Password = @passwd, @Valid = @valid OUTPUT";
                using (SqlCommand com = new SqlCommand(query, con)) {
                    com.Parameters.AddWithValue("@uname", uname);
                    com.Parameters.AddWithValue("@passwd", passwd);
                    com.Parameters.Add("@valid", SqlDbType.NVarChar, 250);
                    com.Parameters["@valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();
                    valid = Convert.ToString(com.Parameters["@Valid"].Value);
                }
            });
            return Convert.ToBoolean(valid);
        }

        #region Private methods
        /// <summary>
        /// Opens a database connection
        /// </summary>
        /// <param name="callback">Callback type SqlConnection</param>
        /// <returns></returns>
        private static SqlConnection ConnectToDatabase(Action<SqlConnection> callback) {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString)) {
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
