using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.Staff.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;

namespace POSSolution.Views.Staff.UserControllers
{
    public partial class StaffDetailsUC : UserControl
    {
        StaffController control = new StaffController();

        public StaffDetailsUC()
        {
            InitializeComponent();
            cmbSearchBy.SelectedIndex = 0;
        }

        private void Search()
        {
            dgvStaffs.Rows.Clear();

            IEnumerable<Models.OnlineModels.Staff> staffs = control.Search(cmbSearchBy.SelectedItem.ToString(), txtSearch.Text, ckDeleted.Checked);

            if (staffs != null)
            {
                foreach (Models.OnlineModels.Staff staff in staffs)
                {
                    dgvStaffs.Rows.Add(staff.Id, staff.Name, staff.Phone, staff.NIC,staff.Address,staff.Status);
                }
            }
        }

        private void GetAll()
        {
            dgvStaffs.Rows.Clear();

            IEnumerable<Models.OnlineModels.Staff> staffs = control.GetAll(ckDeleted.Checked);

            foreach (Models.OnlineModels.Staff staff in staffs)
            {
                dgvStaffs.Rows.Add(staff.Id, staff.Name, staff.Phone, staff.NIC, staff.Address, staff.Status);
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
            if (dgvStaffs.SelectedRows.Count > 0)
            {
                if (dgvStaffs.SelectedRows[0].Cells[0].Value != null)
                {
                    Models.OnlineModels.Staff staff = control.Find(int.Parse(dgvStaffs.SelectedRows[0].Cells[0].Value.ToString()));

                    AddEditFrm frm = new AddEditFrm(staff);
                    frm.ShowDialog();

                    RefreshDGV();
                }
            }
        }

        private void DeleteRecord()
        {
            if (dgvStaffs.SelectedRows.Count > 0)
            {
                if (dgvStaffs.SelectedRows[0].Cells[0].Value != null && dgvStaffs.SelectedRows[0].Cells[3].Value.ToString() != "DEACTIVE")
                {

                    DialogResult action = new Confirmation("Delete").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Delete(int.Parse(dgvStaffs.SelectedRows[0].Cells[0].Value.ToString()));

                        if (result)
                        {
                            new ShowMessage("Success", "Delete").ShowDialog();
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
            if (dgvStaffs.SelectedRows.Count > 0)
            {
                if (dgvStaffs.SelectedRows[0].Cells[0].Value != null && dgvStaffs.SelectedRows[0].Cells[3].Value.ToString() != "ACTIVE")
                {

                    DialogResult action = new Confirmation("Restore").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Restore(int.Parse(dgvStaffs.SelectedRows[0].Cells[0].Value.ToString()));

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
                dgvStaffs.Rows.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRecord();
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
