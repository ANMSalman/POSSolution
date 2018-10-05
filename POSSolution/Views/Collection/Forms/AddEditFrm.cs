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

namespace POSSolution.Views.Collection.Forms
{
    public partial class AddEditFrm : Form
    {
        CollectionController control = new CollectionController();
        Models.OnlineModels.Collection collection;
        string action;

        public AddEditFrm()
        {
            InitializeComponent();

            collection = new Models.OnlineModels.Collection();
            action = "New";
            

            IEnumerable<POSSolution.Models.OnlineModels.Customer> customers = control.GetCustomers();
            foreach(POSSolution.Models.OnlineModels.Customer customer in customers)
            {
                cmbCustomer.Items.Add(customer.Id + " : " + customer.Name + " : " + customer.Address);
            }
            cmbCustomer.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
        }

        public AddEditFrm(Models.OnlineModels.Collection collection)
        {
            InitializeComponent();

            this.collection = collection;
            action = "Edit";

            lblTitle.Text = "EDIT COLLECTION";
            btnSave.BackColor = Color.Gold;
            

            IEnumerable<POSSolution.Models.OnlineModels.Customer> customers = control.GetCustomers();
            foreach (POSSolution.Models.OnlineModels.Customer customer in customers)
            {
                cmbCustomer.Items.Add(customer.Id + " : " + customer.Name + " : " + customer.Address);
            }

            dtpDate.Value = collection.Date;
            cmbCustomer.SelectedItem = collection.Customer.Id + " : " + collection.Customer.Name + " : " + collection.Customer.Address;
            cmbType.SelectedItem = collection.Type;
            txtCash.Text = collection.Cash.ToString();
            txtCheque.Text = collection.Cheque.ToString();
            txtTotal.Text = collection.Total.ToString();

        }


        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateFields()
        {
            if (cmbType.SelectedItem.ToString() == "CASH")
            {
                if(txtCash.Text!="" && txtCash.Text != "0")
                {
                    l4.Visible = false;
                    return true;
                }
                else
                {
                    l4.Visible = true;
                    return false;
                }
            }
            else if (cmbType.SelectedItem.ToString() == "CHEQUE")
            {
                if (txtCheque.Text != "" && txtCheque.Text != "0")
                {
                    l5.Visible = false;
                    return true;
                }
                else
                {
                    l5.Visible = true;
                    return false;
                }
            }
            else if (cmbType.SelectedItem.ToString() == "CASH AND CHEQUE")
            {
                if ((txtCash.Text != "" && txtCash.Text != "0") && (txtCheque.Text != "" && txtCheque.Text != "0"))
                {
                    l4.Visible = false;
                    l5.Visible = false;
                    return true;
                }
                else
                {
                    l4.Visible = true;
                    l5.Visible = true;
                    return false;
                }
            }
            else
            {
                if ((txtCash.Text != "" && txtCash.Text != "0") || (txtCheque.Text != "" && txtCheque.Text != "0"))
                {
                    l4.Visible = false;
                    return true;
                }
                else
                {
                    l4.Visible = true;
                    return false;
                }
            }

            
        }

        private void Save()
        {
            if (ValidateFields())
            {
                collection.Date = dtpDate.Value;
                collection.CustomerId = int.Parse(cmbCustomer.SelectedItem.ToString().Split(' ').First());
                collection.Type = cmbType.SelectedItem.ToString();
                collection.Cash = (txtCash.Text == "") ? 0 : double.Parse(txtCash.Text);
                collection.Cheque= (txtCheque.Text == "") ? 0 : double.Parse(txtCheque.Text);
                collection.Total = double.Parse(txtTotal.Text);


                if (action == "New")
                {
                    if (control.Add(collection))
                    {
                        new ShowMessage("Success", "SUCCESS", "Record created successfully.\nCOLLECTION ID: " + collection.Id).ShowDialog();

                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        new ShowMessage("Failed", "New").ShowDialog();
                    }
                }
                else
                {
                    if (control.Update(collection))
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

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbType.SelectedItem.ToString()=="CASH")
            {
                txtCash.Enabled = true;
                txtCheque.Enabled = false;
                txtCheque.Text = "";
            }
            else if (cmbType.SelectedItem.ToString() == "CHEQUE")
            {
                txtCash.Enabled = false;
                txtCheque.Enabled = true;
                txtCash.Text = "";
            }
            else
            {
                txtCash.Enabled = true;
                txtCheque.Enabled = true;
            }

            l1.Visible = false;
            l2.Visible = false;
            l3.Visible = false;
            l4.Visible = false;
            l5.Visible = false;
            l6.Visible = false;
            
        }

        private void txtCash_txtCheque_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (((txtCash.Text != "") ? double.Parse(txtCash.Text) : 0) + ((txtCheque.Text != "") ? double.Parse(txtCheque.Text) : 0)).ToString();
        }

    }
}
