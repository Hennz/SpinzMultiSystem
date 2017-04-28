using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace SpinzUI {
    static class SQLFunctions {

        const string CONNECTION_STRING = "datasource = localhost; port = 3306; username = root; password = admin";

        static private MySqlConnection connection = new MySqlConnection(CONNECTION_STRING);

        static public void Refresh(DataGridView _dataGridView) {
            string query = "SELECT * FROM `database`.Account";

            using (connection)
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, connection)) {
                DataTable dt = new DataTable();
                da.Fill(dt);
                _dataGridView.DataSource = dt;
            }
        }

        static public void CheckAccount(string txtUsername, string txtPassword) {
            string query = "SELECT Username, Password from `database`.Account WHERE Username = '" + txtUsername + "' AND " +
                " Password = '" + txtPassword + "'";

            using (connection)
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, connection)) {
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0) {
                    MessageBox.Show("USER ACCEPTED");
                }
                else {
                    MessageBox.Show("NO RECORD OF USER DETECTED");
                }
            }
        }

        static public void InsertAccount(string txtUsername, int id, string fname, string lname, string username, string password) {
            string query = "INSERT INTO `database`.Account VALUES (@id,@FirstName, @LastName, @UserName, @Password)";
            string checkquery = "SELECT Username, Password FROM `database`.Account WHERE Username ='" + txtUsername + "'";

            using (connection)
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataAdapter da = new MySqlDataAdapter(checkquery, connection)) {

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0) {
                    MessageBox.Show("USERNAME TAKEN");
                }
                else {
                    MessageBox.Show("USER ADDED");
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.Parameters.Add("@FirstName", MySqlDbType.VarChar).Value = fname;
                    command.Parameters.Add("@LastName", MySqlDbType.VarChar).Value = lname;
                    command.Parameters.Add("@Username", MySqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = password;
                }

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static public void UpdateComboBox(ComboBox cb) {
            string queryid = "SELECT id From `database`.Account";

            using (connection) {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = queryid;
                MySqlDataReader myId = command.ExecuteReader();
                while (myId.Read()) {
                    cb.Items.Add(myId["id"]);
                }
            }
        }

        static public void UpdateForm(ComboBox cb, TextBox fname, TextBox lname, TextBox username, TextBox password) {
            string queryid = "SELECT FirstName, LastName, Username, Password From `database`.Account WHERE id = '" + (cb.SelectedIndex+2) + "'";

            using (connection) {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = queryid;
                MySqlDataReader myId = command.ExecuteReader();
                while (myId.Read()) {
                    fname.Text = myId["FirstName"].ToString();
                    lname.Text = myId["LastName"].ToString();
                    username.Text = myId["Username"].ToString();
                    password.Text = myId["Password"].ToString();
                }
            }
        }

        static  public void DeleteRecord(ComboBox cb) {
            string deleteQuery = "DELETE FROM `database`.Account WHERE id = '" + (cb.SelectedIndex + 1) + "'";

            using (connection)
            using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
            using (MySqlDataAdapter da = new MySqlDataAdapter(deleteQuery, connection)) {

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}
