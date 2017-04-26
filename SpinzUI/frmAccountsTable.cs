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
    public partial class frmAccountsTable : Form {

        String connectionString;
        MySqlConnection conn;

        public frmAccountsTable() {
            InitializeComponent();
            connectionString = "datasource = localhost; port = 3306; username = root; password = admin";
        }

        private void frmAccountsTable_Load(object sender, EventArgs e) {
            string query = "SELECT * FROM `database`.Account";

            using (conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn)) {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void label2_Click(object sender, EventArgs e) {
            new frmRegister().Show();
            this.Dispose();
        }
    }
}
