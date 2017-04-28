using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpinzUI {
    public partial class frmRegister : Form {
        
        public frmRegister() {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            SQLFunctions.InsertAccount(txtUsername.Text, Convert.ToInt32(txtId.Text), txtFname.Text, txtLname.Text, txtUsername.Text, txtPassword.Text);

        }

        private void label6_Click(object sender, EventArgs e) {
            frmAccountsTable acct = new frmAccountsTable();
            acct.Show();
            this.Dispose();
        }
    }
}
