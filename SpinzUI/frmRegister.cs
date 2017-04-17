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

namespace SpinzUI {
    public partial class frmRegister : Form {
        SqlConnection connection;
        string connectionString;


        public frmRegister() {
            InitializeComponent();
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ian\documents\GitHub\SpinzMultiSystem\SpinzUI\SpinzAccounts.mdf;Integrated Security=True";
        }

        private void label5_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            string query = "INSERT INTO Account VALUES (@Name, @Username, @Password)";
            string checkquery = "SELECT Username, Password FROM Account WHERE Username ='" + txtUsername.Text + "'";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(checkquery, connection)) {
                connection.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0) {
                    MessageBox.Show("USERNAME TAKEN");
                }
                else {
                    MessageBox.Show("USER ADDED");
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Username", txtUsername.Text);
                    command.Parameters.AddWithValue("@Password", txtPassword.Text);
                    
                    command.ExecuteScalar();
                }
                
            }
        }

        private void label6_Click(object sender, EventArgs e) {
            frmAccountsTable acct = new frmAccountsTable();
            acct.Show();
            this.Dispose();
        }
    }
}
