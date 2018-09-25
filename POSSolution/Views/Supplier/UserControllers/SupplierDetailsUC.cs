using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.Supplier.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;

namespace POSSolution.Views.Supplier.UserControllers
{
    public partial class SupplierDetailsUC : UserControl
    {
        SupplierController control = new SupplierController();

        public SupplierDetailsUC()
        {
            InitializeComponent();
            cmbSearchBy.SelectedIndex = 0;
        }

        private void Search()
        {
            dgvSupplier.Rows.Clear();

            IEnumerable<Models.OnlineModels.Supplier> suppliers = control.Search(cmbSearchBy.SelectedItem.ToString(), txtSearch.Text);

            if (suppliers != null)
            {
                foreach (Models.OnlineModels.Supplier supplier in suppliers)
                {
                    dgvSupplier.Rows.Add(supplier.Id, supplier.Name, supplier.Phone,supplier.Address,supplier.AccountNo,supplier.AccountName,supplier.Bank,supplier.Branch,supplier.CreatedOn.ToString("yyyy-MM-dd"));
                }
            }
        }

        private void GetAll()
        {
            dgvSupplier.Rows.Clear();

            IEnumerable<Models.OnlineModels.Supplier> suppliers = control.GetAll();

            foreach (Models.OnlineModels.Supplier supplier in suppliers)
            {
                dgvSupplier.Rows.Add(supplier.Id, supplier.Name, supplier.Phone, supplier.Address, supplier.AccountNo, supplier.AccountName, supplier.Bank, supplier.Branch,supplier.CreatedOn.ToString("yyyy-MM-dd"));
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
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                if (dgvSupplier.SelectedRows[0].Cells[0].Value != null)
                {
                    Models.OnlineModels.Supplier supplier = control.Find(int.Parse(dgvSupplier.SelectedRows[0].Cells[0].Value.ToString()));

                    AddEditFrm frm = new AddEditFrm(supplier);
                    frm.ShowDialog();

                    RefreshDGV();
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
                dgvSupplier.Rows.Clear();
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

       

    }
}
