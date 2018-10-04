using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.Purchase.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;

namespace POSSolution.Views.Purchase.UserControllers
{
    public partial class PurchaseDetailsUC : UserControl
    {
        PurchaseController control = new PurchaseController();

        private int page = 0, maxPages;

        public PurchaseDetailsUC()
        {
            InitializeComponent();
            cmbSearchBy.SelectedIndex = 0;

            IEnumerable<POSSolution.Models.OnlineModels.Supplier> suppliers = control.GetSuppliers();
            foreach (POSSolution.Models.OnlineModels.Supplier supplier in suppliers)
            {
                cmbSupplier.Items.Add(supplier.Id + " : " + supplier.Name + " : " + supplier.Address);
            }

            cmbSupplier.SelectedIndex = 0;
            dgvPurchases.Rows.Clear();
            lblSummary.Text = "";
        }

        private void PaginateSearch()
        {
            /**pagination*/

            int count = 0;
            double sum = 0;

            if (cmbSearchBy.SelectedItem.ToString() == "ADDED DATE")
            {
                count = control.GetCount(dtpDate.Value.Date);
                sum = control.GetSum(dtpDate.Value.Date);

                maxPages = (int)Math.Ceiling((double) count/ 50) - 1;    //-1 because pages are called using index not position
            }
            else
            {
                string searchText = "";

                if (cmbSearchBy.SelectedItem.ToString() == "SUPPLIER")
                    searchText = cmbSupplier.SelectedItem.ToString().Split(' ').First();
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

            lblSummary.Text = "PURCHASE COUNT:   " + count + "       TOTAL SUM:   " + sum.ToString("N2");
        }

        private void Search()
        {
            dgvPurchases.Rows.Clear();

            PaginateSearch();

            IEnumerable<Models.OnlineModels.Purchase> purchases;

            if (cmbSearchBy.SelectedItem.ToString() == "ADDED DATE")
            {
                purchases = control.Search(page,dtpDate.Value.Date);
            }
            else
            {
                string searchText = "";

                if (cmbSearchBy.SelectedItem.ToString() == "SUPPLIER")
                    searchText = cmbSupplier.SelectedItem.ToString().Split(' ').First();
                else
                    searchText = txtSearch.Text;

                purchases = control.Search(page,cmbSearchBy.SelectedItem.ToString(),
                    searchText,
                    ckAscending.Checked);
            }

            if (purchases != null)
            {
                foreach (Models.OnlineModels.Purchase purchase in purchases)
                {
                    dgvPurchases.Rows.Add(purchase.Id,
                        purchase.Date.ToString("yyyy-MM-dd"),
                        purchase.Supplier.Id + " : " + purchase.Supplier.Name + " : " + purchase.Supplier.Address,
                        purchase.Amount.ToString("N2"));
                }
            }
        }

        

        private void RefreshDGV()
        {
            page = 0;
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
            if (dgvPurchases.SelectedRows.Count > 0)
            {
                if (dgvPurchases.SelectedRows[0].Cells[0].Value != null)
                {
                    Models.OnlineModels.Purchase purchase = control.Find(int.Parse(dgvPurchases.SelectedRows[0].Cells[0].Value.ToString()));

                    AddEditFrm frm = new AddEditFrm(purchase);
                    frm.ShowDialog();

                    RefreshDGV();
                }
            }
        }

        

        private void DeleteRecord()
        {
            if (dgvPurchases.SelectedRows.Count > 0)
            {
                if (dgvPurchases.SelectedRows[0].Cells[0].Value != null)
                {

                    DialogResult action = new Confirmation("Delete").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Delete(int.Parse(dgvPurchases.SelectedRows[0].Cells[0].Value.ToString()));

                        if (result)
                        {
                            new ShowMessage("Success", "SUCCESS", "Record deleted successfullly").ShowDialog();
                            RefreshDGV();
                        }
                        else
                        {
                            new ShowMessage("Failed", "FAILED", "Record deletion failed.").ShowDialog();
                        }
                    }


                }
            }
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            page = 0;
            if(cmbSearchBy.SelectedItem.ToString()== "SUPPLIER")
            {
                txtSearch.Visible = false;
                dtpDate.Visible = false;
                cmbSupplier.Visible = true;
                btnGo.Visible = true;
                ckAscending.Enabled = true;
            }
            else if(cmbSearchBy.SelectedItem.ToString() == "ADDED DATE")
            {
                txtSearch.Visible = false;
                dtpDate.Visible = true;
                cmbSupplier.Visible = false;
                btnGo.Visible = true;
                ckAscending.Enabled = false;
            }
            else
            {
                txtSearch.Visible = true;
                dtpDate.Visible = false;
                cmbSupplier.Visible = false;
                btnGo.Visible = false;
                ckAscending.Enabled = true;
            }

            dgvPurchases.Rows.Clear();
            lblSummary.Text = "";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbSearchBy.SelectedItem.ToString() == "ID")
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
                dgvPurchases.Rows.Clear();
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
