using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;
using System.Text.RegularExpressions;

namespace POSSolution.Views.Customer.Forms
{
    public partial class AddEditFrm : Form
    {
        CustomerController control = new CustomerController();
        Models.OnlineModels.Customer customer;
        string action;

        public AddEditFrm()
        {
            InitializeComponent();

            customer = new Models.OnlineModels.Customer();
            action = "New";
        }

        public AddEditFrm(Models.OnlineModels.Customer customer)
        {
            InitializeComponent();

            this.customer = customer;
            action = "Edit";

            lblTitle.Text = "EDIT CUSTOMER";
            btnSave.BackColor = Color.Gold;

            txtName.Text = customer.Name;
            txtPhone.Text = customer.Phone;
            txtNic.Text = customer.NIC;
            txtAddress.Text = customer.Address;
            txtBalance.Text = customer.InitialBalance.ToString();

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateFields()
        {
            if (txtName.Text != "" )
            {
                l1.Visible = false;

                if(Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
                {
                    l2.Visible = false;
                    if (Regex.IsMatch(txtNic.Text, @"^\d{9}(x|v|X|V)$") || Regex.IsMatch(txtNic.Text,@"^\d{12}$"))
                    {
                        l3.Visible = false;
                        return true;
                    }
                    else
                    {
                        l3.Text = "Invalid NIC number";
                        l3.Visible = true;

                        return false;
                    }
                }
                else
                {
                    l2.Text = "*Invalid Number";
                    l2.Visible = true;

                    return false;
                }
            }
            else
            {
                l1.Visible = true;

                return false;
            }
        }

        private void Save()
        {
            if (ValidateFields())
            {
                customer.Name = txtName.Text.ToUpper();
                customer.Phone = txtPhone.Text;
                customer.NIC = txtNic.Text;
                customer.Address = txtAddress.Text.ToUpper();

                if (txtBalance.Text == "")
                    customer.InitialBalance = 0;
                else
                    customer.InitialBalance = double.Parse(txtBalance.Text);

                customer.AddedBy = POSSolution.Controllers.Common.Session.Instance.Id;

                if (action == "New")
                {
                    if (control.Add(customer))
                    {
                        new ShowMessage("Success", "SUCCESS", "Record created successfully.\nCustomer ID: " + customer.Id).ShowDialog();

                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        new ShowMessage("Failed", "New").ShowDialog();
                    }
                }
                else
                {
                    if (control.Update(customer))
                    {
                        new ShowMessage("Success", "Update").ShowDialog();

                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        new ShowMessage("Failed", "Update").ShowDialog();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
