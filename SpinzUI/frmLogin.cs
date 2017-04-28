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
    public partial class frmLogin : Form {

        public frmLogin() {
            InitializeComponent();
        }

        private void lblRegister_Click(object sender, EventArgs e) {
            frmRegister regForm = new frmRegister();
            regForm.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e) {
            SQLFunctions.CheckAccount(this.txtUsername.Text, this.txtPassword.Text);
        }
    }
}
