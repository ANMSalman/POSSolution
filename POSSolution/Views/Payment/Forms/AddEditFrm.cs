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

namespace POSSolution.Views.Payment.Forms
{
    public partial class AddEditFrm : Form
    {
        PaymentController control = new PaymentController();
        Models.OnlineModels.Payment payment;
        string action;
        List<Models.OnlineModels.Cheque> OldCheques = new List<Models.OnlineModels.Cheque>();
        List<Models.OnlineModels.Cheque> NewCheques = new List<Models.OnlineModels.Cheque>();

        public AddEditFrm()
        {
            InitializeComponent();

            payment = new Models.OnlineModels.Payment();
            action = "New";
            

            IEnumerable<POSSolution.Models.OnlineModels.Supplier> suppliers = control.GetSuppliers();
            foreach(POSSolution.Models.OnlineModels.Supplier supplier in suppliers)
            {
                cmbSupplier.Items.Add(supplier.Id + " : " + supplier.Name + " : " + supplier.Address);
            }
            cmbSupplier.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
        }

        public AddEditFrm(Models.OnlineModels.Payment payment)
        {
            InitializeComponent();

            this.payment = payment;
            action = "Edit";

            lblTitle.Text = "EDIT PAYMENT";
            btnSave.BackColor = Color.Gold;
            

            IEnumerable<POSSolution.Models.OnlineModels.Supplier> suppliers = control.GetSuppliers();
            foreach (POSSolution.Models.OnlineModels.Supplier supplier in suppliers)
            {
                cmbSupplier.Items.Add(supplier.Id + " : " + supplier.Name + " : " + supplier.Address);
            }

            dtpDate.Value = payment.Date;
            cmbSupplier.SelectedItem = payment.Supplier.Id + " : " + payment.Supplier.Name + " : " + payment.Supplier.Address;
            cmbType.SelectedItem = payment.Type;
            txtCash.Text = payment.Cash.ToString();
            txtCheque.Text = payment.Cheque.ToString();
            txtTotal.Text = payment.Total.ToString();

            OldCheques = control.GetCheques(payment.Id);

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

        private void AddCheques()
        {
            AddCheques addCheques;
            if (action == "New")
            {
                if(NewCheques.Count>0)
                    addCheques = new AddCheques(NewCheques);
                else
                    addCheques = new AddCheques();
            }
            else
            {
                addCheques = new AddCheques(OldCheques);
            }

            addCheques.ShowDialog();

            txtCheque.Text = addCheques.GetSum().ToString();
            NewCheques = addCheques.GetCheques();
        }

        private void Save()
        {
            if (ValidateFields())
            {
                payment.Date = dtpDate.Value;
                payment.SupplierId = int.Parse(cmbSupplier.SelectedItem.ToString().Split(' ').First());
                payment.Type = cmbType.SelectedItem.ToString();
                payment.Cash = (txtCash.Text == "") ? 0 : double.Parse(txtCash.Text);
                payment.Cheque = (txtCheque.Text == "") ? 0 : double.Parse(txtCheque.Text);
                payment.Total = double.Parse(txtTotal.Text);


                if (action == "New")
                {
                    if (control.Add(payment))
                    {
                        if (NewCheques.Count > 0)
                        {
                            NewCheques.ForEach(cheque => cheque.PaymentId = payment.Id);

                            if (control.UpdateCheques(NewCheques))
                            {
                                new ShowMessage("Success", "SUCCESS", "Record created successfully.\nPAYMENT ID: " + payment.Id).ShowDialog();

                                this.DialogResult = DialogResult.Cancel;
                            }
                            else
                            {
                                new ShowMessage("Failed", "New").ShowDialog();
                            }
                        }
                        else
                        {
                            new ShowMessage("Success", "SUCCESS", "Record created successfully.\nPAYMENT ID: " + payment.Id).ShowDialog();

                            this.DialogResult = DialogResult.Cancel;
                        }
                    }
                    else
                    {
                        new ShowMessage("Failed", "New").ShowDialog();
                    }
                }
                else
                {

                    if (control.Update(payment))
                    {
                        NewCheques.ForEach(cheque => cheque.PaymentId = payment.Id);

                        if (control.MakeChequeNull(OldCheques))
                        {
                            if (NewCheques.Count > 0)
                            {
                                if (control.UpdateCheques(NewCheques))
                                {
                                    new ShowMessage("Success", "Update").ShowDialog();

                                    this.DialogResult = DialogResult.Cancel;
                                }
                                else
                                {
                                    new ShowMessage("Failed", "Update").ShowDialog();
                                }
                            }
                            else
                            {
                                new ShowMessage("Success", "Update").ShowDialog();

                                this.DialogResult = DialogResult.Cancel;
                            }
                        }
                        else
                        {
                            new ShowMessage("Failed", "Update").ShowDialog();
                        }
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
                btnAdd.Enabled = false;
                txtCheque.Text = "";
            }
            else if (cmbType.SelectedItem.ToString() == "CHEQUE")
            {
                txtCash.Enabled = false;
                btnAdd.Enabled = true;
                txtCash.Text = "";
            }
            else
            {
                txtCash.Enabled = true;
                btnAdd.Enabled = true;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCheques();
        }
    }
}
