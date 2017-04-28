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
    public partial class frmAccountsTable : Form {

        public frmAccountsTable() {
            InitializeComponent();
        }

        private void frmAccountsTable_Load(object sender, EventArgs e) {
            SQLFunctions.Refresh(this.dataGridView1);
            SQLFunctions.UpdateComboBox(this.cmbId);
            SQLFunctions.UpdateComboBox(this.cmbIdDelete);
        }

        private void label2_Click(object sender, EventArgs e) {
            new frmRegister().Show();
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            SQLFunctions.UpdateForm(this.cmbId, this.txtFname, this.txtLname, this.txtUsername, this.txtPassword);
            SQLFunctions.UpdateForm(this.cmbId, this.txtFname, this.txtLname, this.txtUsername, this.txtPassword);


        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            

        }

        private void btnDelete_Click(object sender, EventArgs e) {
            SQLFunctions.DeleteRecord(this.cmbIdDelete);
        }
    }
}
