using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSSolution.Views.Saff.Forms
{
    public partial class AddEditFrm : Form
    {
        public AddEditFrm()
        {
            InitializeComponent();
        }

        public AddEditFrm(String user)
        {
            InitializeComponent();
            editView();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void editView()
        {
            lblTitle.Text = "EDIT STAFF";
            btnSave.BackColor = Color.Gold;
        }
    }
}
