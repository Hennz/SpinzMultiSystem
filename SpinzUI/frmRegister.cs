using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace SpinzUI {
    public partial class frmRegister : Form {
        MySqlConnection connection;
        string connectionString;


        public frmRegister() {
            InitializeComponent();
            connectionString = "datasource = localhost; port = 3306; username = root; password = admin";
        }

        private void label5_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            string query = "INSERT INTO `database`.Account VALUES (@id,@FirstName, @LastName, @UserName, @Password)";
            string checkquery = "SELECT Username, Password FROM `database`.Account WHERE Username ='" + txtUsername.Text + "'";

            using (connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataAdapter da = new MySqlDataAdapter(checkquery, connection)) {
                
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0) {
                    MessageBox.Show("USERNAME TAKEN");
                }
                else {
                    MessageBox.Show("USER ADDED");
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = 3;
                    command.Parameters.Add("@FirstName", MySqlDbType.VarChar).Value = txtFname.Text;
                    command.Parameters.Add("@LastName", MySqlDbType.VarChar).Value = txtLname.Text;
                    command.Parameters.Add("@Username", MySqlDbType.VarChar).Value = txtUsername.Text;
                    command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = txtPassword.Text;

                    
                }
                connection.Open();

                
                command.ExecuteNonQuery();
                Console.Write("Error!");
                
                

            }
        }

        private void label6_Click(object sender, EventArgs e) {
            frmAccountsTable acct = new frmAccountsTable();
            acct.Show();
            this.Dispose();
        }
    }
}
