using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

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
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString)) {
                try {
                    //Open the connection
                    con.Open();
                    //SQL Query
                    string query = "EXEC ValidateUserLogin @Username = @uname, @Password = @passwd, @Valid = @valid OUTPUT";
                    //Creates a new command
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        //For security reasons the values are added with this function
                        //this will avoid SQL Injections
                        com.Parameters.AddWithValue("@uname", uname);
                        com.Parameters.AddWithValue("@passwd", passwd);
                        com.Parameters.Add("@valid", SqlDbType.NVarChar, 250);
                        com.Parameters["@valid"].Direction = ParameterDirection.Output;
                        //Execute without a return value
                        com.ExecuteNonQuery();
                        //The Return value from the SQL Stored Procedure will have the answer to life
                        return Convert.ToInt32(com.Parameters["@Valid"].Value);
                    }
                    //Catch any error
                } catch (SqlException ex) {
                    return ex.Number;
                } finally {
                    //Always close the connection
                    con.Close();
                }
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
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString)) {
                try {
                    //Open the connection
                    con.Open();
                    //SQL Query
                    string query = "EXEC CheckUserCookie @Cookie = @cookie, @UserName = @username, @Valid = @valid OUTPUT";
                    //Creates a new command
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        //For security reasons the values are added with this function
                        //this will avoid SQL Injections
                        com.Parameters.AddWithValue("@cookie", cookie);
                        com.Parameters.AddWithValue("@username", username);
                        com.Parameters.Add("@valid", SqlDbType.Bit);
                        com.Parameters["@valid"].Direction = ParameterDirection.Output;
                        //Execute without a return value
                        com.ExecuteNonQuery();
                        //The Return value from the SQL Stored Procedure will have the answer to life
                        return Convert.ToInt32(com.Parameters["@Valid"].Value);
                    }
                    //Catch any error
                } catch (SqlException ex) {
                    return ex.Number;
                } finally {
                    //Always close the connection
                    con.Close();
                }
            }
        }
        /// <summary>
        /// Deletes a the cookie from the given user
        /// </summary>
        /// <param name="username">User who doesnt deserve any delicious cookies :3</param>
        public static void DeleteCookie(string username) {
            //Creates the database connection
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString)) {
                try {
                    //Open the connection
                    con.Open();
                    //SQL Query
                    string query = "EXEC DeleteUserCookie @Username = @username, @ResponseMessage = @response OUTPUT";
                    //Creates a new command
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        //For security reasons the values are added with this function
                        //this will avoid SQL Injections
                        com.Parameters.AddWithValue("@username", username);
                        com.Parameters.Add("@response", SqlDbType.NVarChar, 250);
                        com.Parameters["@response"].Direction = ParameterDirection.Output;
                        //Execute without a return value
                        com.ExecuteNonQuery();
                    }
                    //Catch any error, dont return them, why would you?
                } catch {
                } finally {
                    //Always close the connection
                    con.Close();
                }
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
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString)) {
                try {
                    //Open the connection
                    con.Open();
                    //SQL Query
                    string query = "EXEC AddCookieToUser @Cookie = @cookie, @UserName = @username, @ResponseMessage = @response OUTPUT";
                    //Creates a new command
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        //For security reasons the values are added with this function
                        //this will avoid SQL Injections
                        com.Parameters.AddWithValue("@cookie", cookie);
                        com.Parameters.AddWithValue("@username", username);
                        com.Parameters.Add("@response", SqlDbType.NVarChar, 250);
                        com.Parameters["@response"].Direction = ParameterDirection.Output;
                        //Execute without a return value
                        com.ExecuteNonQuery();
                        //The Return value from the SQL Stored Procedure will have the answer to life
                        return Convert.ToInt32(com.Parameters["@ResponseMessage"].Value);
                    }
                    //Catch any error
                } catch (SqlException ex) {
                    return ex.Number;
                } finally {
                    //Always close connection
                    con.Close();
                }
            }
        }
        #endregion
    }
}
