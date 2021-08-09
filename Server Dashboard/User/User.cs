using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Server_Dashboard {

    /// <summary>
    /// User class to store user informations
    /// </summary>
    internal class User {
        public int UID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public User(DataTable userData) {
            foreach (DataRow row in userData.Rows) {
                UID = (int)row[0];
                UserName = (string)row[1];
                Email = (string)row[2];
                RegistrationDate = (DateTime)row[3];
            }
        }
    }
}