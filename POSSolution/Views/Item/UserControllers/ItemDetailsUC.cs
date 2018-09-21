using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSSolution.Views.Item.Forms;
using POSSolution.Views.MessageBoxes;
using POSSolution.Controllers.OnlineModels;

namespace POSSolution.Views.Item.UserControllers
{
    public partial class ItemDetailsUC : UserControl
    {
        ItemController control = new ItemController();

        public ItemDetailsUC()
        {
            InitializeComponent();

        }

        private void Search()
        {
            dgvItems.Rows.Clear();

            IEnumerable<Models.OnlineModels.Item> Items = control.Search(txtSearch.Text, ckDeleted.Checked);

            if (Items != null)
            {
                foreach (Models.OnlineModels.Item Item in Items)
                {
                    dgvItems.Rows.Add(Item.Name, Item.Category, Item.Status);
                }
            }
        }

        private void GetAll()
        {
            dgvItems.Rows.Clear();

            IEnumerable<Models.OnlineModels.Item> Items = control.GetAll(ckDeleted.Checked);

            foreach (Models.OnlineModels.Item Item in Items)
            {
                dgvItems.Rows.Add(Item.Name, Item.Category, Item.Status);
            }
        }

        private void RefreshDGV()
        {
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
            if (dgvItems.SelectedRows.Count > 0)
            {
                if (dgvItems.SelectedRows[0].Cells[0].Value != null)
                {
                    Models.OnlineModels.Item Item = control.Find(dgvItems.SelectedRows[0].Cells[0].Value.ToString());

                    AddEditFrm frm = new AddEditFrm(Item);
                    frm.ShowDialog();

                    RefreshDGV();
                }
            }
        }

        private void DeleteRecord()
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                if (dgvItems.SelectedRows[0].Cells[0].Value != null && dgvItems.SelectedRows[0].Cells[2].Value.ToString() != "DEACTIVE")
                {
                    
                    DialogResult action = new Confirmation("Delete").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Delete(dgvItems.SelectedRows[0].Cells[0].Value.ToString());

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

        private void RestoreRecord()
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                if (dgvItems.SelectedRows[0].Cells[0].Value != null && dgvItems.SelectedRows[0].Cells[2].Value.ToString() != "ACTIVE")
                {

                    DialogResult action = new Confirmation("Restore").ShowDialog();

                    if (action == DialogResult.Yes)
                    {
                        bool result = control.Restore(dgvItems.SelectedRows[0].Cells[0].Value.ToString());

                        if (result)
                        {
                            new ShowMessage("Success", "Restore").ShowDialog();
                            RefreshDGV();
                        }
                        else
                        {
                            new ShowMessage("Failed", "Restore").ShowDialog();
                        }
                    }


                }
            }
        }

        
        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                Search();
            else
                dgvItems.Rows.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            RestoreRecord();
        }
    }
}
