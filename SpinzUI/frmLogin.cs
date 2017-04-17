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
    public partial class frmLogin : Form {
        SqlConnection conn; 
        string connectionString;

        public frmLogin() {
            InitializeComponent();
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ian\documents\visual studio 2015\Projects\SpinzMultiSystem\SpinzUI\SpinzAccounts.mdf;Integrated Security=True";

        }

        private void lblRegister_Click(object sender, EventArgs e) {
            frmRegister regForm = new frmRegister();
            regForm.Show();

        }

        private void btnEnter_Click(object sender, EventArgs e) {
            string query = "SELECT Username, Password from Account WHERE Username = '" + txtUsername.Text + "' AND " +
                " Password = '" + txtPassword.Text + "'";

            using (conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn)) 
            using (SqlDataAdapter da = new SqlDataAdapter(query,conn)){
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count > 0) {
                    MessageBox.Show("USER ACCEPTED");
                }
                else {
                    MessageBox.Show("NO RECORD OF USER DETECTED");
                }

            }
        }
    }
}
