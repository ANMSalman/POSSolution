using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.Collection.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;

namespace POSSolution.Views.Collection.UserControllers
{
    public partial class CollectionDetailsUC : UserControl
    {
        CollectionController control = new CollectionController();

        private int page = 0, maxPages;

        public CollectionDetailsUC()
        {
            InitializeComponent();
            cmbSearchBy.SelectedIndex = 0;

            IEnumerable<POSSolution.Models.OnlineModels.Customer> customers = control.GetCustomers();
            foreach (POSSolution.Models.OnlineModels.Customer customer in customers)
            {
                cmbCustomer.Items.Add(customer.Id + " : " + customer.Name + " : " + customer.Address);
            }

            cmbCustomer.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            dgvCollections.Rows.Clear();
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

                if (cmbSearchBy.SelectedItem.ToString() == "CUSTOMER")
                    searchText = cmbCustomer.SelectedItem.ToString().Split(' ').First();
                else
                    searchText = txtSearch.Text;

                count = control.GetCount(cmbSearchBy.SelectedItem.ToString(), searchText,cmbType.SelectedItem.ToString());
                sum = control.GetSum(cmbSearchBy.SelectedItem.ToString(), searchText,cmbType.SelectedItem.ToString());

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

            lblSummary.Text = "COLLECTION COUNT:   " + count + "       TOTAL SUM:   " + sum.ToString("N2");
        }

        private void Search()
        {
            dgvCollections.Rows.Clear();

            PaginateSearch();

            IEnumerable<Models.OnlineModels.Collection> collections;

            if (cmbSearchBy.SelectedItem.ToString() == "ADDED DATE")
            {
                collections = control.Search(page,dtpDate.Value.Date);
            }
            else
            {
                string searchText = "";

                if (cmbSearchBy.SelectedItem.ToString() == "CUSTOMER")
                    searchText = cmbCustomer.SelectedItem.ToString().Split(' ').First();
                else
                    searchText = txtSearch.Text;

                collections = control.Search(page,cmbSearchBy.SelectedItem.ToString(),
                    searchText,
                    ckAscending.Checked,
                    cmbType.SelectedItem.ToString());
            }

            if (collections != null)
            {
                foreach (Models.OnlineModels.Collection collection in collections)
                {
                    dgvCollections.Rows.Add(collection.Id,
                        collection.Date.ToString("yyyy-MM-dd"),
                        collection.Customer.Id + " : " + collection.Customer.Name + " : " + collection.Customer.Address,
                        collection.Type,
                        collection.Cash.ToString("N2"),
                        collection.Cheque.ToString("N2"),
                        collection.Total.ToString("N2"),
                        collection.ReturnBillId);
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
            if (dgvCollections.SelectedRows.Count > 0)
            {
                if (dgvCollections.SelectedRows[0].Cells[0].Value != null)
                {
                    Models.OnlineModels.Collection collection = control.Find(int.Parse(dgvCollections.SelectedRows[0].Cells[0].Value.ToString()));

                    AddEditFrm frm = new AddEditFrm(collection);
                    frm.ShowDialog();

                    RefreshDGV();
                }
            }
        }

        

        private void DeleteRecord()
        {
            if (dgvCollections.SelectedRows.Count > 0)
            {
                if (dgvCollections.SelectedRows[0].Cells[0].Value != null)
                {

                    DialogResult action = new Confirmation("Delete").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Delete(int.Parse(dgvCollections.SelectedRows[0].Cells[0].Value.ToString()));

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
            if(cmbSearchBy.SelectedItem.ToString()== "CUSTOMER")
            {
                txtSearch.Visible = false;
                dtpDate.Visible = false;
                cmbCustomer.Visible = true;
                btnGo.Visible = true;
                ckAscending.Enabled = true;
            }
            else if(cmbSearchBy.SelectedItem.ToString() == "ADDED DATE")
            {
                txtSearch.Visible = false;
                dtpDate.Visible = true;
                cmbCustomer.Visible = false;
                btnGo.Visible = true;
                ckAscending.Enabled = false;
            }
            else
            {
                txtSearch.Visible = true;
                dtpDate.Visible = false;
                cmbCustomer.Visible = false;
                btnGo.Visible = false;
                ckAscending.Enabled = true;
            }

            dgvCollections.Rows.Clear();
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
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            page = 0;
            if (txtSearch.Text != "")
                Search();
            else
                dgvCollections.Rows.Clear();
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
