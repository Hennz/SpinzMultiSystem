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
    public partial class frmLogin : Form {
        MySqlConnection conn; 
        string connectionString;

        public frmLogin() {
            InitializeComponent();
            connectionString = "datasource=localhost; port=3306;username=root;password=admin";

        }

        private void lblRegister_Click(object sender, EventArgs e) {
            frmRegister regForm = new frmRegister();
            regForm.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e) {
            string query = "SELECT Username, Password from `database`.Account WHERE Username = '" + txtUsername.Text + "' AND " +
                " Password = '" + txtPassword.Text + "'";

            using (conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn)) 
            using (MySqlDataAdapter da = new MySqlDataAdapter(query,conn)){
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
