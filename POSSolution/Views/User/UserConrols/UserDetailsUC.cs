using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.User.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;

namespace POSSolution.Views.User
{
    public partial class UserDetailsUC : UserControl
    {
        UserController control = new UserController();

        public UserDetailsUC()
        {
            InitializeComponent();
            cmbSearchBy.SelectedIndex = 0;

        }

        private void Search()
        {
            dgvUsers.Rows.Clear();

            IEnumerable<Models.OnlineModels.User> users = control.Search(cmbSearchBy.SelectedItem.ToString(), txtSearch.Text, ckDeleted.Checked);

            if (users != null)
            {
                foreach (Models.OnlineModels.User user in users)
                {
                    dgvUsers.Rows.Add(user.Id, user.Name, user.Type, user.Status);
                }
            }
        }

        private void GetAll()
        {
            dgvUsers.Rows.Clear();

            IEnumerable<Models.OnlineModels.User> users = control.GetAll(ckDeleted.Checked);

            foreach (Models.OnlineModels.User user in users)
            {
                dgvUsers.Rows.Add(user.Id, user.Name, user.Type, user.Status);
            }
        }

        private void RefreshDGV()
        {
            if (txtSearch.Text != "")
                Search();
            else
                GetAll();
        }

        private void NewRecord()
        {
            AddEditFrm frm = new AddEditFrm();
            frm.ShowDialog();

            RefreshDGV();
        }

        private void EditRecord()
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                if (dgvUsers.SelectedRows[0].Cells[0].Value != null)
                {
                    Models.OnlineModels.User user = control.Find(int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString()));

                    AddEditFrm frm = new AddEditFrm(user);
                    frm.ShowDialog();

                    RefreshDGV();
                }
            }
        }

        private void DeleteRecord()
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                if (dgvUsers.SelectedRows[0].Cells[0].Value != null && dgvUsers.SelectedRows[0].Cells[3].Value.ToString() != "DEACTIVE")
                {
                    
                    DialogResult action = new Confirmation("Delete").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Delete(int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString()));

                        if (result)
                        {
                            new ShowMessage("Success","Delete").ShowDialog();
                            RefreshDGV();
                        }
                        else
                        {
                            new ShowMessage("Failed", "Delete").ShowDialog();
                        }
                    }

                    
                }
            }
        }

        private void RestoreRecord()
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                if (dgvUsers.SelectedRows[0].Cells[0].Value != null && dgvUsers.SelectedRows[0].Cells[3].Value.ToString() != "ACTIVE")
                {

                    DialogResult action = new Confirmation("Restore").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Restore(int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString()));

                        if (result)
                        {
                            new ShowMessage("Success", "Restore").ShowDialog();
                            RefreshDGV();
                        }
                        else
                        {
                            new ShowMessage("Failed", "Restore").ShowDialog();
                        }
                    }


                }
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRecord();
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbSearchBy.SelectedIndex == 0)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                Search();
            else
                dgvUsers.Rows.Clear();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            GetAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            RestoreRecord();
        }
    }
}
