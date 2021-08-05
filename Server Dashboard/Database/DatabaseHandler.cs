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

        public static int CheckLogin(string uname, string passwd) {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString)) {
                try {
                    con.Open();
                    string query = "EXEC ValidateUserLogin @Username = @uname, @Password = @passwd, @Valid = @valid OUTPUT";
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        com.Parameters.AddWithValue("@uname", uname);
                        com.Parameters.AddWithValue("@passwd", passwd);
                        com.Parameters.Add("@valid", SqlDbType.NVarChar, 250);
                        com.Parameters["@valid"].Direction = ParameterDirection.Output;
                        com.ExecuteNonQuery();
                        return Convert.ToInt32(com.Parameters["@Valid"].Value);
                    }
                } catch (SqlException ex) {
                    return ex.Number;
                } finally {
                    con.Close();
                }
            }
        }

        public static int CheckCookie(string cookie, string username) {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString)) {
                try {
                    con.Open();
                    string query = "EXEC CheckUserCookie @Cookie = @cookie, @UserName = @username, @Valid = @valid OUTPUT";
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        com.Parameters.AddWithValue("@cookie", cookie);
                        com.Parameters.AddWithValue("@username", username);
                        com.Parameters.Add("@valid", SqlDbType.Bit);
                        com.Parameters["@valid"].Direction = ParameterDirection.Output;
                        com.ExecuteNonQuery();
                        return Convert.ToInt32(com.Parameters["@Valid"].Value);
                    }
                } catch (SqlException ex) {
                    return ex.Number;
                } finally {
                    con.Close();
                }
            }
        }

        public static void DeleteCookie(string username) {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString)) {
                try {
                    con.Open();
                    string query = "EXEC DeleteUserCookie @Username = @username, @ResponseMessage = @response OUTPUT";
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        com.Parameters.AddWithValue("@username", username);
                        com.Parameters.Add("@response", SqlDbType.NVarChar, 250);
                        com.Parameters["@response"].Direction = ParameterDirection.Output;
                        com.ExecuteNonQuery();
                    }
                } catch (SqlException ex) {
                } finally {
                    con.Close();
                }
            }
        }

        public static int AddCookie(string cookie, string username) {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerDashboardDB"].ConnectionString)) {
                try {
                    con.Open();
                    string query = "EXEC AddCookieToUser @Cookie = @cookie, @UserName = @username, @ResponseMessage = @response OUTPUT";
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        com.Parameters.AddWithValue("@cookie", cookie);
                        com.Parameters.AddWithValue("@username", username);
                        com.Parameters.Add("@response", SqlDbType.NVarChar, 250);
                        com.Parameters["@response"].Direction = ParameterDirection.Output;
                        com.ExecuteNonQuery();
                        return Convert.ToInt32(com.Parameters["@ResponseMessage"].Value);
                    }
                } catch (SqlException ex) {
                    return ex.Number;
                } finally {
                    con.Close();
                }
            }
        }
    }
}
