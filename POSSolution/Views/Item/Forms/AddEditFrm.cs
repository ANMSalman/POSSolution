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

namespace POSSolution.Views.Item.Forms
{
    public partial class AddEditFrm : Form
    {
        ItemController control = new ItemController();
        Models.OnlineModels.Item item;
        string action;

        public AddEditFrm()
        {
            InitializeComponent();
            
            item = new Models.OnlineModels.Item();
            action = "New";
            cmbCategory.SelectedIndex = 0;
        }

        public AddEditFrm(Models.OnlineModels.Item item)
        {
            InitializeComponent();

            this.item = item;
            action = "Edit";

            lblTitle.Text = "EDIT ITEM";
            btnSave.BackColor = Color.Gold;

            txtName.Text = item.Name;
            cmbCategory.SelectedItem = item.Category;

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateFields()
        {
            if (txtName.Text != "")
            {
                l1.Visible = false;
                l2.Visible = false;

                return true;
            }
            else
            {
                l1.Visible = true;
                l2.Visible = true;

                return false;
            }
        }

        private void Save()
        {
            if(ValidateFields())
            {
                item.Name = txtName.Text.ToUpper();
                item.Category = cmbCategory.SelectedItem.ToString();

                if (action=="New")
                {
                    item.Status = "ACTIVE";
                    if(control.Add(item))
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
                    if (control.Update(item))
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
    }
}
