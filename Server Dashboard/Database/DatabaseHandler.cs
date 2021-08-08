using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace Server_Dashboard {

    /// <summary>
    /// Database class to access the database
    /// </summary>
    public static class DatabaseHandler {

        #region Public Methods

        /// <summary>
        /// Checks the user credentials
        /// </summary>
        /// <param name="uname">The username</param>
        /// <param name="passwd">The plain text password</param>
        /// <returns>[0] is false, [1] is true, [2] connection error</returns>
        public static int CheckLogin(string uname, string passwd) {
            //Creates the database connection
            using SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString);
            try {
                //Open the connection
                con.Open();
                //SQL Query
                string query = "EXEC ValidateUserLogin @Username = @uname, @Password = @passwd, @Valid = @valid OUTPUT";
                //Creates a new command
                using SqlCommand com = new SqlCommand(query, con);//For security reasons the values are added with this function
                //this will avoid SQL Injections
                com.Parameters.AddWithValue("@uname", uname);
                com.Parameters.AddWithValue("@passwd", passwd);
                com.Parameters.Add("@valid", SqlDbType.NVarChar, 250);
                com.Parameters["@valid"].Direction = ParameterDirection.Output;
                //Execute query and return number of rows affected
                int sqlResponse = com.ExecuteNonQuery();
                //Checks if there are any rows successful
                //If the query returns 0 the query wasn't successful
                //if its any number above 0 it was successfull
                if (Convert.ToInt32(com.Parameters["@Valid"].Value) == 0) {
                    //Error, not successful
                    return 1;
                } else {
                    //Successful
                    return 0;
                }
                //Catch any error
            } catch (SqlException ex) {
                return ex.Number;
            } finally {
                //Always close the connection
                con.Close();
            }
        }

        public static DataTable GetUserData(string username) {
            //Creates the database connection
            using SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString);
            try {
                //Open the connection
                con.Open();
                //SQL Query
                string query = "SELECT UserID, Username, Email, CreationTime, ModuleName, MI.Image FROM UserData LEFT JOIN ModuleData MD on UserData.ID = MD.UserID LEFT JOIN ModuleIcon MI on MD.ID = MI.Module WHERE Username = @username";
                //Creates a new command
                using SqlCommand com = new SqlCommand(query, con);//For security reasons the values are added with this function
                //this will avoid SQL Injections
                com.Parameters.AddWithValue("@username", username);
                //Execute query and return number of rows affected
                DataTable resultTable = new DataTable();
                using SqlDataAdapter sda = new SqlDataAdapter(com);
                sda.Fill(resultTable);
                return resultTable;
                //Checks if there are any rows successful
                //If the query returns 0 the query wasn't successful
                //if its any number above 0 it was successfull
                //Catch any error
            } catch (SqlException ex) {
                return null;
            } finally {
                //Always close the connection
                con.Close();
            }
        }

        /// <summary>
        /// Creates a new Module for the current user
        /// </summary>
        /// <param name="ipAdress">Server IP Address</param>
        /// <param name="moduleName">Module name, default is Module</param>
        /// <param name="serverName">Server name, default is Server</param>
        /// <param name="username">Username of the current user</param>
        /// <param name="moduleIcon">module icon as byte[]</param>
        /// <param name="port">port, defalt ist 22</param>
        /// <returns></returns>
        public static int CreateNewModule(string ipAdress, string moduleName, string serverName, string username, byte[] moduleIcon, string port = "22") {
            //Creates the database connection
            using SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString);
            try {
                //Open the connection
                con.Open();
                //SQL Query
                string query = "EXEC AddNewModuleToUser @UserName = @username, @DateTime = @time, @ModuleName = @moduleName, @ServerName = @serverName, @ModuleIcon = @moduleIcon, @IPAddress = @ipAdress, @Port = @port";
                //Creates a new command
                using SqlCommand com = new SqlCommand(query, con);
                //For security reasons the values are added with this function
                //this will avoid SQL Injections
                com.Parameters.AddWithValue("@username", username);
                com.Parameters.AddWithValue("@time", DateTime.Now);
                com.Parameters.AddWithValue("@moduleName", moduleName);
                com.Parameters.AddWithValue("@serverName", serverName);
                com.Parameters.Add("@moduleIcon", SqlDbType.VarBinary, int.MaxValue).Value = moduleIcon;
                com.Parameters.AddWithValue("@ipAdress", ipAdress);
                com.Parameters.AddWithValue("@port", port);
                //Execute query and return number of rows affected
                int sqlResponse = com.ExecuteNonQuery();
                //Checks if there are any rows successful
                //If the query returns 0 the query wasn't successful
                //if its any number above 0 it was successfull
                if (sqlResponse == 0) {
                    //Error, not successful
                    return 1;
                } else {
                    //Successful
                    return 0;
                }
                //Catch any error
            } catch (SqlException ex) {
                return ex.Number;
            } finally {
                //Always close the connection
                con.Close();
            }
        }

        /// <summary>
        /// Currently obscolete, would check the Username and Cookie
        /// </summary>
        /// <param name="cookie">Locally stored user cookie</param>
        /// <param name="username">Locally stored username</param>
        /// <returns>[0] is false, [1] is true, [2] connection error</returns>
        public static int CheckCookie(string cookie, string username) {
            //Creates the database connection
            using SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString);
            try {
                //Open the connection
                con.Open();
                //SQL Query
                string query = "EXEC CheckUserCookie @Cookie = @cookie, @UserName = @username, @Valid = @valid OUTPUT";
                //Creates a new command
                using SqlCommand com = new SqlCommand(query, con);
                //For security reasons the values are added with this function
                //this will avoid SQL Injections
                com.Parameters.AddWithValue("@cookie", cookie);
                com.Parameters.AddWithValue("@username", username);
                com.Parameters.Add("@valid", SqlDbType.Bit);
                com.Parameters["@valid"].Direction = ParameterDirection.Output;
                //Execute query and return number of rows affected
                int sqlResponse = com.ExecuteNonQuery();
                //Checks if there are any rows successful
                //If the query returns 0 the query wasn't successful
                //if its any number above 0 it was successfull
                if ((int)com.Parameters["@Valid"].Value == 0) {
                    //Error, not successful
                    return 1;
                } else {
                    //Successful
                    return 0;
                }
                //Catch any error
            } catch (SqlException ex) {
                return ex.Number;
            } finally {
                //Always close the connection
                con.Close();
            }
        }

        /// <summary>
        /// Deletes a the cookie from the given user
        /// </summary>
        /// <param name="username">User who doesnt deserve any delicious cookies :3</param>
        public static int DeleteCookie(string username) {
            //Creates the database connection
            using SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString);
            try {
                //Open the connection
                con.Open();
                //SQL Query
                string query = "EXEC DeleteUserCookie @Username = @username";
                //Creates a new command
                using SqlCommand com = new SqlCommand(query, con);
                //For security reasons the values are added with this function
                //this will avoid SQL Injections
                com.Parameters.AddWithValue("@username", username);
                //Execute query and return number of rows affected
                int sqlResponse = com.ExecuteNonQuery();
                //Checks if there are any rows successful
                //If the query returns 0 the query wasn't successful
                //if its any number above 0 it was successfull
                if (sqlResponse == 0) {
                    //Error, not successful
                    return 1;
                } else {
                    //Successful
                    return 0;
                }
                //Catch any error
            } catch (SqlException ex) {
                return ex.Number;
            } finally {
                //Always close the connection
                con.Close();
            }
        }

        /// <summary>
        /// Adds a new Cookie to a user
        /// </summary>
        /// <param name="cookie">The delicious locally stored cookie</param>
        /// <param name="username">The User who deserves a cookie :3</param>
        /// <returns>[0] is false, [1] is true, [2] connection error</returns>
        public static int AddCookie(string cookie, string username) {
            //Creates the database connection
            using SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString);
            try {
                //Open the connection
                con.Open();
                //SQL Query
                string query = "EXEC AddCookieToUser @Cookie = @cookie, @UserName = @username";
                //Creates a new command
                using SqlCommand com = new SqlCommand(query, con);
                //For security reasons the values are added with this function
                //this will avoid SQL Injections
                com.Parameters.AddWithValue("@cookie", cookie);
                com.Parameters.AddWithValue("@username", username);
                //Execute query and return number of rows affected
                int sqlResponse = com.ExecuteNonQuery();
                //Checks if there are any rows successful
                //If the query returns 0 the query wasn't successful
                //if its any number above 0 it was successfull
                if (sqlResponse == 0) {
                    //Error, not successful
                    return 1;
                } else {
                    //Successful
                    return 0;
                }
                //Catch any error
            } catch (SqlException ex) {
                return ex.Number;
            } finally {
                //Always close the connection
                con.Close();
            }

            #endregion Public Methods
        }
    }
}