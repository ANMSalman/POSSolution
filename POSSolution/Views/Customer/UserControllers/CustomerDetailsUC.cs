using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.Customer.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;

namespace POSSolution.Views.Customer.UserControllers
{
    public partial class CustomerDetailsUC : UserControl
    {
        CustomerController control = new CustomerController();

        public CustomerDetailsUC()
        {
            InitializeComponent();
            cmbSearchBy.SelectedIndex = 0;
        }

        private void Search()
        {
            dgvCustomers.Rows.Clear();

            IEnumerable<Models.OnlineModels.Customer> customers = control.Search(cmbSearchBy.SelectedItem.ToString(), txtSearch.Text);

            if (customers != null)
            {
                foreach (Models.OnlineModels.Customer customer in customers)
                {
                    dgvCustomers.Rows.Add(customer.Id, customer.Name, customer.Phone, customer.NIC,customer.Address,customer.User.Id+" : "+customer.User.Name,customer.CreatedOn.ToString("yyyy-MM-dd"));
                }
            }
        }

        private void GetAll()
        {
            dgvCustomers.Rows.Clear();

            IEnumerable<Models.OnlineModels.Customer> customers = control.GetAll();

            foreach (Models.OnlineModels.Customer customer in customers)
            {
                dgvCustomers.Rows.Add(customer.Id, customer.Name, customer.Phone, customer.NIC, customer.Address, customer.User.Id + " : " + customer.User.Name, customer.CreatedOn.ToString("yyyy-MM-dd"));
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
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                if (dgvCustomers.SelectedRows[0].Cells[0].Value != null)
                {
                    Models.OnlineModels.Customer customer = control.Find(int.Parse(dgvCustomers.SelectedRows[0].Cells[0].Value.ToString()));

                    AddEditFrm frm = new AddEditFrm(customer);
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
                dgvCustomers.Rows.Clear();
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
