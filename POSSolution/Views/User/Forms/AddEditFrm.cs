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

namespace POSSolution.Views.User.Forms
{
    public partial class AddEditFrm : Form
    {
        UserController control = new UserController();
        Models.OnlineModels.User user;
        string action;

        public AddEditFrm()
        {
            InitializeComponent();

            user = new Models.OnlineModels.User();
            action = "New";
            cmbType.SelectedIndex = 0;
        }

        public AddEditFrm(Models.OnlineModels.User user)
        {
            InitializeComponent();

            this.user = user;
            action = "Edit";

            lblTitle.Text = "EDIT USER";
            btnSave.BackColor = Color.Gold;

            txtName.Text = user.Name;
            cmbType.SelectedItem = user.Type;
            txtPassword.Text = user.Password;

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateFields()
        {
            if (txtName.Text != "" && txtPassword.Text != "")
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
                user.Name = txtName.Text.ToUpper();
                user.Type = cmbType.SelectedItem.ToString();
                user.Password = txtPassword.Text;

                if (action=="New")
                {
                    user.Status = "ACTIVE";
                    if(control.Add(user))
                    {
                        new ShowMessage("Success", "SUCCESS", "Record created successfully.\nUser ID: " + user.Id).ShowDialog();

                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        new ShowMessage("Failed", "New").ShowDialog();
                    }
                }
                else
                {
                    if (control.Update(user))
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
