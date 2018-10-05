using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.Cheque.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;


namespace POSSolution.Views.Payment.Forms
{
    public partial class AddCheques : Form
    {
        ChequeController control = new ChequeController();
        private int page = 0, maxPages;
        private double sum = 0;

        private List<int> selectedIds = new List<int>();

        public AddCheques()
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

        public AddCheques(List<Models.OnlineModels.Cheque> cheques)
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

            foreach (Models.OnlineModels.Cheque cheque in cheques)
            {

                dgvSelected.Rows.Add(cheque.Id,
                    cheque.AddedDate.ToString("yyyy-MM-dd"),
                    cheque.Number,
                    cheque.Bank,
                    cheque.Branch,
                    cheque.Amount,
                    cheque.Date.ToString("yyyy-MM-dd"),
                    cheque.Customer.Id + " : " + cheque.Customer.Name + " : " + cheque.Customer.Address,
                    cheque.Description,
                    cheque.Status);

                selectedIds.Add(cheque.Id);

            }

            Sum();

        }

        private void PaginateSearch()
        {
            /**pagination*/

            int count = 0;
            double sum = 0;

            if (cmbSearchBy.SelectedItem.ToString() == "ADDED DATE" || cmbSearchBy.SelectedItem.ToString() == "CHEQUE DATE")
            {
                count = control.GetCount(cmbSearchBy.SelectedItem.ToString(), dtpDate.Value.Date);
                sum = control.GetSum(cmbSearchBy.SelectedItem.ToString(), dtpDate.Value.Date);

                maxPages = (int)Math.Ceiling((double)count / 50) - 1;    //-1 because pages are called using index not position
            }
            else
            {
                string searchText = "";

                if (cmbSearchBy.SelectedItem.ToString() == "CUSTOMER")
                    searchText = cmbCustomer.SelectedItem.ToString().Split(' ').First();
                else
                    searchText = txtSearch.Text;

                count = control.GetCount(cmbSearchBy.SelectedItem.ToString(), searchText);
                sum = control.GetSum(cmbSearchBy.SelectedItem.ToString(), searchText);

                maxPages = (int)Math.Ceiling((double)count / 50) - 1;
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
                cheques = control.Search(page, cmbSearchBy.SelectedItem.ToString(),
                    dtpDate.Value.Date,
                    ckAscending.Checked);
            }
            else
            {
                string searchText = "";

                if (cmbSearchBy.SelectedItem.ToString() == "CUSTOMER")
                    searchText = cmbCustomer.SelectedItem.ToString().Split(' ').First();
                else
                    searchText = txtSearch.Text;

                cheques = control.Search(page, cmbSearchBy.SelectedItem.ToString(),
                    searchText,
                    ckAscending.Checked);
            }

            if (cheques != null)
            {
                int row = 0;
                foreach (Models.OnlineModels.Cheque cheque in cheques)
                {
                    if (!selectedIds.Contains(cheque.Id))
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
                        cheque.Status);

                        if (cheque.Status == "RETURNED")
                            dgvCheques.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                        else if (cheque.Status == "PASSED")
                            dgvCheques.Rows[row].DefaultCellStyle.BackColor = Color.DodgerBlue;

                        row += 1;
                    }
                }
            }
        }

        private void Add()
        {
            if (dgvCheques.SelectedRows.Count > 0)
            {
                if (dgvCheques.SelectedRows[0].Cells[0].Value != null)
                {
                    dgvSelected.Rows.Add(dgvCheques.SelectedRows[0].Cells[0].Value,
                        dgvCheques.SelectedRows[0].Cells[1].Value,
                        dgvCheques.SelectedRows[0].Cells[2].Value,
                        dgvCheques.SelectedRows[0].Cells[3].Value,
                        dgvCheques.SelectedRows[0].Cells[4].Value,
                        dgvCheques.SelectedRows[0].Cells[5].Value,
                        dgvCheques.SelectedRows[0].Cells[6].Value,
                        dgvCheques.SelectedRows[0].Cells[7].Value,
                        dgvCheques.SelectedRows[0].Cells[8].Value,
                        dgvCheques.SelectedRows[0].Cells[9].Value);

                    selectedIds.Add(int.Parse(dgvCheques.SelectedRows[0].Cells[0].Value.ToString()));

                    dgvCheques.Rows.Remove(dgvCheques.SelectedRows[0]);

                    Sum();
                }
            }
        }

        private void Remove()
        {
            if (dgvSelected.SelectedRows.Count > 0)
            {
                if (dgvSelected.SelectedRows[0].Cells[0].Value != null)
                {
                    selectedIds.Remove(int.Parse(dgvSelected.SelectedRows[0].Cells[0].Value.ToString()));
                    dgvSelected.Rows.Remove(dgvSelected.SelectedRows[0]);
                    Sum();
                }
            }
        }

        private void Sum()
        {
            sum = 0;

            foreach(DataGridViewRow row in dgvSelected.Rows)
            {
                sum+= double.Parse(row.Cells[5].Value.ToString().Replace(",", ""));
            }

            lblSummary.Text = "COUNT:   " + dgvSelected.Rows.Count + "       TOTAL:   " + sum.ToString("N2");
        }

        public double GetSum()
        {
            return sum;
        }

        public List<Models.OnlineModels.Cheque> GetCheques()
        {
            List<Models.OnlineModels.Cheque> cheques = new List<Models.OnlineModels.Cheque>();

            foreach (DataGridViewRow row in dgvSelected.Rows)
            {
                Models.OnlineModels.Cheque cheque = control.Find(int.Parse(row.Cells[0].Value.ToString()));
                cheques.Add(cheque);
            }

            return cheques;
        }

        private void RefreshDGV()
        {
            page = 0;
            Search();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            page = 0;
            if (cmbSearchBy.SelectedItem.ToString() == "CUSTOMER")
            {
                txtSearch.Visible = false;
                dtpDate.Visible = false;
                cmbCustomer.Visible = true;
                btnGo.Visible = true;
            }
            else if (cmbSearchBy.SelectedItem.ToString() == "ADDED DATE" || cmbSearchBy.SelectedItem.ToString() == "CHEQUE DATE")
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

            dgvCheques.Rows.Clear();
            lblSummary.Text = "";
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (maxPages > page)
            {
                page += 1;

                Search();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (page > 0)
            {
                page -= 1;

                Search();
            }
        }


    }
}
