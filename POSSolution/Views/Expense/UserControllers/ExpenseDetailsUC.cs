using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.Expense.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;

namespace POSSolution.Views.Expense.UserControllers
{
    public partial class ExpenseDetailsUC : UserControl
    {
        ExpenseController control = new ExpenseController();

        public ExpenseDetailsUC()
        {
            InitializeComponent();

        }

        private void Search()
        {
            dgvExpenses.Rows.Clear();

            IEnumerable<Models.OnlineModels.Expense> expenses;

            if (rbOn.Checked == true)
            {
               expenses = control.Search(dtpOn.Value.Date);
            }
            else
            {
                expenses = control.Search(dtpFrom.Value,dtpTo.Value);
            }

            if (expenses != null)
            {
                double total = 0;
                foreach (Models.OnlineModels.Expense expense in expenses)
                {
                    dgvExpenses.Rows.Add(expense.Id, expense.Date.ToString("dd-MM-yyyy"),expense.Description,expense.Amount.ToString("N2"), expense.User.Id+" : "+expense.User.Name);
                    total += expense.Amount;
                }
                lblTotal.Text = "TOTAL: " + total.ToString("N2");
            }
            else
            {
                lblTotal.Text = "TOTAL: 0";
            }
        }
        

        private void RefreshDGV()
        {
            Search();
        }

        private void NewRecord()
        {
            AddEditFrm frm = new AddEditFrm();
            frm.ShowDialog();

            RefreshDGV();
        }

        private void EditRecord()
        {
            if (dgvExpenses.SelectedRows.Count > 0)
            {
                if (dgvExpenses.SelectedRows[0].Cells[0].Value != null)
                {
                    Models.OnlineModels.Expense expense = control.Find(int.Parse(dgvExpenses.SelectedRows[0].Cells[0].Value.ToString()));

                    AddEditFrm frm = new AddEditFrm(expense);
                    frm.ShowDialog();

                    RefreshDGV();
                }
            }
        }

        private void DeleteRecord()
        {
            if (dgvExpenses.SelectedRows.Count > 0)
            {
                if (dgvExpenses.SelectedRows[0].Cells[0].Value != null)
                {
                    
                    DialogResult action = new Confirmation("Delete").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Delete(int.Parse(dgvExpenses.SelectedRows[0].Cells[0].Value.ToString()));

                        if (result)
                        {
                            new ShowMessage("Success","Delete").ShowDialog();
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
        

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
