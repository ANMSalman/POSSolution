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

namespace POSSolution.Views.Purchase.Forms
{
    public partial class AddEditFrm : Form
    {
        PurchaseController control = new PurchaseController();
        Models.OnlineModels.Purchase purchase;
        string action;

        public AddEditFrm()
        {
            InitializeComponent();

            purchase = new Models.OnlineModels.Purchase();
            action = "New";
            

            IEnumerable<POSSolution.Models.OnlineModels.Supplier> suppliers = control.GetSuppliers();
            foreach(POSSolution.Models.OnlineModels.Supplier supplier in suppliers)
            {
                cmbSupplier.Items.Add(supplier.Id + " : " + supplier.Name + " : " + supplier.Address);
            }
            cmbSupplier.SelectedIndex = 0;
        }

        public AddEditFrm(Models.OnlineModels.Purchase purchase)
        {
            InitializeComponent();

            this.purchase = purchase;
            action = "Edit";

            lblTitle.Text = "EDIT CHEQUE";
            btnSave.BackColor = Color.Gold;
            

            IEnumerable<POSSolution.Models.OnlineModels.Supplier> suppliers = control.GetSuppliers();
            foreach (POSSolution.Models.OnlineModels.Supplier supplier in suppliers)
            {
                cmbSupplier.Items.Add(supplier.Id + " : " + supplier.Name + " : " + supplier.Address);
            }
            
            txtAmount.Text = purchase.Amount.ToString();
            dtpDate.Value = purchase.Date;
            cmbSupplier.SelectedItem = purchase.Supplier.Id + " : " + purchase.Supplier.Name + " : " + purchase.Supplier.Address;

        }


        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateFields()
        {
            if (txtAmount.Text != "")
            {
                l1.Visible = false;
                l2.Visible = false;
                l3.Visible = false;

                return true;
            }
            else
            {
                l1.Visible = true;
                l2.Visible = true;
                l3.Visible = true;

                return false;
            }
        }

        private void Save()
        {
            if (ValidateFields())
            {
                purchase.Amount = double.Parse(txtAmount.Text);
                purchase.Date = dtpDate.Value;
                purchase.SupplierId = int.Parse(cmbSupplier.SelectedItem.ToString().Split(' ').First());
                

                if (action == "New")
                {
                    if (control.Add(purchase))
                    {
                        new ShowMessage("Success", "SUCCESS", "Record created successfully.\nPURCHASE ID: " + purchase.Id).ShowDialog();

                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        new ShowMessage("Failed", "New").ShowDialog();
                    }
                }
                else
                {
                    if (control.Update(purchase))
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
    }
}
