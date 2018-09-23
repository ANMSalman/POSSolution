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

namespace POSSolution.Views.Supplier.Forms
{
    public partial class AddEditFrm : Form
    {
        SupplierController control = new SupplierController();
        Models.OnlineModels.Supplier supplier;
        string action;

        public AddEditFrm()
        {
            InitializeComponent();

            supplier = new Models.OnlineModels.Supplier();
            action = "New";
        }

        public AddEditFrm(Models.OnlineModels.Supplier supplier)
        {
            InitializeComponent();

            this.supplier = supplier;
            action = "Edit";

            lblTitle.Text = "EDIT SUPPLIER";
            btnSave.BackColor = Color.Gold;

            txtName.Text = supplier.Name;
            txtPhone.Text = supplier.Phone;
            txtAddress.Text = supplier.Address;
            txtAccountNo.Text = supplier.AccountNo;
            txtAccountName.Text = supplier.AccountName;
            txtBank.Text = supplier.Bank;
            txtBranch.Text = supplier.Branch;
            txtBalance.Text = supplier.InitialBalance.ToString();

        }


        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateFields()
        {
            if (txtName.Text != "" && txtAddress.Text!="" )
            {
                l1.Visible = false;
                l3.Visible = false;

                if(Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
                {
                    l2.Visible = false;

                    return true;
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
                l3.Visible = true;

                return false;
            }
        }

        private void Save()
        {
            if (ValidateFields())
            {
                supplier.Name = txtName.Text.ToUpper();
                supplier.Phone = txtPhone.Text;
                supplier.Address = txtAddress.Text.ToUpper();
                supplier.AccountNo = txtAccountNo.Text;
                supplier.AccountName = txtAccountName.Text.ToUpper();
                supplier.Bank = txtBank.Text.ToUpper();
                supplier.Branch = txtBranch.Text.ToUpper();

                if (txtBalance.Text == "")
                    supplier.InitialBalance = 0;
                else
                    supplier.InitialBalance = double.Parse(txtBalance.Text);

                if (action == "New")
                {
                    supplier.CreatedOn = DateTime.Today;

                    if (control.Add(supplier))
                    {
                        new ShowMessage("Success", "SUCCESS", "Record created successfully.\nSupplier ID: " + supplier.Id).ShowDialog();

                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        new ShowMessage("Failed", "New").ShowDialog();
                    }
                }
                else
                {
                    if (control.Update(supplier))
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
