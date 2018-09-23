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

namespace POSSolution.Views.Expense.Forms
{
    public partial class AddEditFrm : Form
    {
        ExpenseController control = new ExpenseController();
        Models.OnlineModels.Expense expense;
        string action;

        public AddEditFrm()
        {
            InitializeComponent();

            expense = new Models.OnlineModels.Expense();
            action = "New";
        }

        public AddEditFrm(Models.OnlineModels.Expense expense)
        {
            InitializeComponent();

            this.expense = expense;
            action = "Edit";

            lblTitle.Text = "EDIT USER";
            btnSave.BackColor = Color.Gold;

            dtpDate.Value = expense.Date;
            txtDescription.Text = expense.Description;
            txtAmount.Text = expense.Amount.ToString();

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateFields()
        {
            if (txtAmount.Text != "" && txtDescription.Text != "" )
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
            if(ValidateFields())
            {
                expense.Date = dtpDate.Value;
                expense.Description = txtDescription.Text.ToUpper();
                expense.Amount = double.Parse(txtAmount.Text);

                if (action=="New")
                {
                    expense.AddedBy = Controllers.Common.Session.Instance.Id;

                    if(control.Add(expense))
                    {
                        new ShowMessage("Success", "New").ShowDialog();

                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        new ShowMessage("Failed", "New").ShowDialog();
                    }
                }
                else
                {
                    if (control.Update(expense))
                    {
                        new ShowMessage("Success","Update").ShowDialog();

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
