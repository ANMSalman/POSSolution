using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.Cheque.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;

namespace POSSolution.Views.Cheque.UserControllers
{
    public partial class ChequeDetailsUC : UserControl
    {
        ChequeController control = new ChequeController();

        private int page = 0, maxPages;

        public ChequeDetailsUC()
        {
            InitializeComponent();
            cmbSearchBy.SelectedIndex = 0;

            IEnumerable<POSSolution.Models.OnlineModels.Customer> customers = control.GetCustomers();
            foreach (POSSolution.Models.OnlineModels.Customer customer in customers)
            {
                cmbCustomer.Items.Add(customer.Id + " : " + customer.Name + " : " + customer.Address);
            }

            cmbCustomer.SelectedIndex = 0;
            dgvCheques.Rows.Clear();
        }

        private void PaginateSearch()
        {
            /**pagination*/

            if (cmbSearchBy.SelectedItem.ToString() == "ADDED DATE" || cmbSearchBy.SelectedItem.ToString() == "CHEQUE DATE")
            {
                maxPages = (int)Math.Ceiling((double)control.GetCount(cmbSearchBy.SelectedItem.ToString(), dtpDate.Value.Date, ckReturned.Checked) / 50) - 1;    //-1 because pages are called using index not position
            }
            else
            {
                string searchText = "";

                if (cmbSearchBy.SelectedItem.ToString() == "CUSTOMER")
                    searchText = cmbCustomer.SelectedItem.ToString().Split(' ').First();
                else
                    searchText = txtSearch.Text;

                maxPages = (int)Math.Ceiling((double)control.GetCount(cmbSearchBy.SelectedItem.ToString(), searchText, ckReturned.Checked) / 50) - 1;
            }

            if (maxPages > page)
                btnNext.Enabled = true;
            else
                btnNext.Enabled = false;

            if (page > 0)
                btnPrevious.Enabled = true;
            else
                btnPrevious.Enabled = false;
        }

        private void Search()
        {
            dgvCheques.Rows.Clear();

            PaginateSearch();

            IEnumerable<Models.OnlineModels.Cheque> cheques;

            if (cmbSearchBy.SelectedItem.ToString() == "ADDED DATE" || cmbSearchBy.SelectedItem.ToString() == "CHEQUE DATE")
            {
                cheques = control.Search(cmbSearchBy.SelectedItem.ToString(),
                    dtpDate.Value.Date,
                    ckReturned.Checked,
                    ckAscending.Checked);
            }
            else
            {
                string searchText = "";

                if (cmbSearchBy.SelectedItem.ToString() == "CUSTOMER")
                    searchText = cmbCustomer.SelectedItem.ToString().Split(' ').First();
                else
                    searchText = txtSearch.Text;

                cheques = control.Search(cmbSearchBy.SelectedItem.ToString(),
                    searchText,
                    ckReturned.Checked,
                    ckAscending.Checked);
            }

            if (cheques != null)
            {
                int row = 0;
                foreach (Models.OnlineModels.Cheque cheque in cheques)
                {
                    dgvCheques.Rows.Add(cheque.Id,
                        cheque.AddedDate.ToString("yyyy-MM-dd"),
                        cheque.Number,
                        cheque.Bank,
                        cheque.Branch,
                        cheque.Amount,
                        cheque.Date.ToString("yyyy-MM-dd"),
                        cheque.Customer.Id+" : "+cheque.Customer.Name+" : "+cheque.Customer.Address,
                        cheque.Description,
                        cheque.PaymentId,
                        cheque.Status);

                    if(cheque.Status=="RETURNED")
                        dgvCheques.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                    else if(cheque.Status == "PASSED")
                        dgvCheques.Rows[row].DefaultCellStyle.BackColor = Color.DodgerBlue;

                    row += 1;
                }
            }
        }

        private void PaginateAll()
        {
            /**pagination*/

            maxPages = (int)Math.Ceiling((double)control.GetCount(ckReturned.Checked) / 50) - 1;    //-1 because pages are called using index not position

            if (maxPages > page)
                btnNext.Enabled = true;
            else
                btnNext.Enabled = false;

            if (page > 0)
                btnPrevious.Enabled = true;
            else
                btnPrevious.Enabled = false;
        }

        private void GetAll()
        {
            dgvCheques.Rows.Clear();

            PaginateAll();

            /*Gets all records*/
            IEnumerable<Models.OnlineModels.Cheque> cheques = control.GetAll(page, ckReturned.Checked, ckAscending.Checked);

            if (cheques != null)
            {
                int row = 0;
                foreach (Models.OnlineModels.Cheque cheque in cheques)
                {
                    dgvCheques.Rows.Add(cheque.Id,
                        cheque.AddedDate.ToString("yyyy-MM-dd"),
                        cheque.Number,
                        cheque.Bank,
                        cheque.Branch,
                        cheque.Amount,
                        cheque.Date.ToString("yyyy-MM-dd"),
                        cheque.Customer.Id + " : " + cheque.Customer.Name + " : " + cheque.Customer.Address,
                        cheque.Description,
                        cheque.PaymentId,
                        cheque.Status);

                    if (cheque.Status == "RETURNED")
                        dgvCheques.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                    else if (cheque.Status == "PASSED")
                        dgvCheques.Rows[row].DefaultCellStyle.BackColor = Color.DodgerBlue;

                    row += 1;
                }
            }

        }

        private void RefreshDGV()
        {
            page = 0;
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
            if (dgvCheques.SelectedRows.Count > 0)
            {
                if (dgvCheques.SelectedRows[0].Cells[0].Value != null)
                {
                    Models.OnlineModels.Cheque cheque = control.Find(int.Parse(dgvCheques.SelectedRows[0].Cells[0].Value.ToString()));

                    AddEditFrm frm = new AddEditFrm(cheque);
                    frm.ShowDialog();

                    RefreshDGV();
                }
            }
        }

        private void MarkReturned()
        {
            if (dgvCheques.SelectedRows.Count > 0)
            {
                if (dgvCheques.SelectedRows[0].Cells[0].Value != null && dgvCheques.SelectedRows[0].Cells[10].Value.ToString() !="RETURNED")
                {

                    DialogResult action = new Confirmation("MarkReturned").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Returned(int.Parse(dgvCheques.SelectedRows[0].Cells[0].Value.ToString()));

                        if (result)
                        {
                            new ShowMessage("Success","SUCCESS","Cheque marked as Returned").ShowDialog();
                            RefreshDGV();
                        }
                        else
                        {
                            new ShowMessage("Failed", "FAILED","Marking selected cheque as Returned failed.").ShowDialog();
                        }
                    }


                }
            }
        }

        private void MarkPassed()
        {
            if (dgvCheques.SelectedRows.Count > 0)
            {
                if (dgvCheques.SelectedRows[0].Cells[0].Value != null && dgvCheques.SelectedRows[0].Cells[10].Value.ToString() != "PASSED")
                {

                    DialogResult action = new Confirmation("MarkPassed").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Passed(int.Parse(dgvCheques.SelectedRows[0].Cells[0].Value.ToString()));

                        if (result)
                        {
                            new ShowMessage("Success", "SUCCESS", "Cheque marked as Passed").ShowDialog();
                            RefreshDGV();
                        }
                        else
                        {
                            new ShowMessage("Failed", "FAILED", "Marking selected cheque as Passed failed.").ShowDialog();
                        }
                    }


                }
            }
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            page = 0;
            if(cmbSearchBy.SelectedItem.ToString()== "CUSTOMER")
            {
                txtSearch.Visible = false;
                dtpDate.Visible = false;
                cmbCustomer.Visible = true;
                btnGo.Visible = true;
            }
            else if(cmbSearchBy.SelectedItem.ToString() == "ADDED DATE" || cmbSearchBy.SelectedItem.ToString() == "CHEQUE DATE")
            {
                txtSearch.Visible = false;
                dtpDate.Visible = true;
                cmbCustomer.Visible = false;
                btnGo.Visible = true;
            }
            else
            {
                txtSearch.Visible = true;
                dtpDate.Visible = false;
                cmbCustomer.Visible = false;
                btnGo.Visible = false;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbSearchBy.SelectedItem.ToString() == "ID" || cmbSearchBy.SelectedItem.ToString() == "NUMBER")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if (cmbSearchBy.SelectedItem.ToString() == "AMOUNT")
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            page = 0;
            if (txtSearch.Text != "")
                Search();
            else
                dgvCheques.Rows.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            page = 0;
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

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (maxPages > page)
            {
                page += 1;
                GetAll();
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            MarkPassed();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            MarkReturned();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (page > 0)
            {
                page -= 1;
                GetAll();
            }
            
        }
    }
}
