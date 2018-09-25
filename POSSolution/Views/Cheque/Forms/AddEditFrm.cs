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

namespace POSSolution.Views.Cheque.Forms
{
    public partial class AddEditFrm : Form
    {
        ChequeController control = new ChequeController();
        Models.OnlineModels.Cheque cheque;
        string action;

        public AddEditFrm()
        {
            InitializeComponent();

            cheque = new Models.OnlineModels.Cheque();
            action = "New";

            txtBank.AutoCompleteCustomSource.AddRange(control.GetBanks().ToArray());
            txtBranch.AutoCompleteCustomSource.AddRange(control.GetBranches().ToArray());

            IEnumerable<POSSolution.Models.OnlineModels.Customer> customers = control.GetCustomers();
            foreach(POSSolution.Models.OnlineModels.Customer customer in customers)
            {
                cmbCustomer.Items.Add(customer.Id + " : " + customer.Name + " : " + customer.Address);
            }
            cmbCustomer.SelectedIndex = 0;
        }

        public AddEditFrm(Models.OnlineModels.Cheque cheque)
        {
            InitializeComponent();

            this.cheque = cheque;
            action = "Edit";

            lblTitle.Text = "EDIT CHEQUE";
            btnSave.BackColor = Color.Gold;

            txtBank.AutoCompleteCustomSource.AddRange(control.GetBanks().ToArray());
            txtBranch.AutoCompleteCustomSource.AddRange(control.GetBranches().ToArray());

            IEnumerable<POSSolution.Models.OnlineModels.Customer> customers = control.GetCustomers();
            foreach (POSSolution.Models.OnlineModels.Customer customer in customers)
            {
                cmbCustomer.Items.Add(customer.Id + " : " + customer.Name + " : " + customer.Address);
            }
            
            txtNumber.Text = cheque.Number;
            txtBank.Text = cheque.Bank;
            txtBranch.Text = cheque.Branch;
            txtAmount.Text = cheque.Amount.ToString();
            dtpDate.Value = cheque.Date;
            cmbCustomer.SelectedItem = cheque.Customer.Id + " : " + cheque.Customer.Name + " : " + cheque.Customer.Address;
            txtDescription.Text = cheque.Description;

        }


        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateFields()
        {
            if (txtNumber.Text != "" && txtBank.Text!="" && txtBranch.Text != "" && txtAmount.Text != "")
            {
                l1.Visible = false;
                l2.Visible = false;
                l3.Visible = false;
                l4.Visible = false;
                l5.Visible = false;
                l6.Visible = false;

                return true;
            }
            else
            {
                l1.Visible = true;
                l2.Visible = true;
                l3.Visible = true;
                l4.Visible = true;
                l5.Visible = true;
                l6.Visible = true;

                return false;
            }
        }

        private void Save()
        {
            if (ValidateFields())
            {
                cheque.Number = txtNumber.Text;
                cheque.Bank = txtBank.Text.ToUpper();
                cheque.Branch = txtBranch.Text.ToUpper();
                cheque.Amount = double.Parse(txtAmount.Text);
                cheque.Date = dtpDate.Value;
                cheque.CustomerId = int.Parse(cmbCustomer.SelectedItem.ToString().Split(' ').First());
                cheque.Description = txtDescription.Text.ToUpper();
                cheque.Status = "PENDING";
                

                if (action == "New")
                {
                    cheque.AddedDate = DateTime.Now;

                    if (control.Add(cheque))
                    {
                        

                        new ShowMessage("Success", "SUCCESS", "Record created successfully.\nCHEQUE ID: " + cheque.Id).ShowDialog();

                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        new ShowMessage("Failed", "New").ShowDialog();
                    }
                }
                else
                {
                    if (control.Update(cheque))
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

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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
