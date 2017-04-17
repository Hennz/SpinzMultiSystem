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
    public partial class frmAccountsTable : Form {

        String connectionString;
        SqlConnection conn;

        public frmAccountsTable() {
            InitializeComponent();
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ian\documents\GitHub\SpinzMultiSystem\SpinzUI\SpinzAccounts.mdf;Integrated Security=True";
        }

        private void frmAccountsTable_Load(object sender, EventArgs e) {
            string query = "SELECT Name,Username,Password FROM Account";

            using (conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn)) {
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
