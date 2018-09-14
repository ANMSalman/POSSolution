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

namespace POSSolution.Views.Staff.Forms
{
    public partial class AddEditFrm : Form
    {
        StaffController control = new StaffController();
        Models.OnlineModels.Staff staff;
        string action;

        public AddEditFrm()
        {
            InitializeComponent();

            staff = new Models.OnlineModels.Staff();
            action = "New";
        }

        public AddEditFrm(Models.OnlineModels.Staff staff)
        {
            InitializeComponent();

            this.staff = staff;
            action = "Edit";

            lblTitle.Text = "EDIT STAFF";
            btnSave.BackColor = Color.Gold;

            txtName.Text = staff.Name;
            txtPhone.Text = staff.Phone;
            txtNic.Text = staff.NIC;
            txtAddress.Text = staff.Address;

        }


        private void pbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateFields()
        {
            if (txtName.Text != "" )
            {
                l1.Visible = false;

                if(Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
                {
                    l2.Visible = false;
                    if (Regex.IsMatch(txtNic.Text, @"^\d{9}(x|v|X|V)$") || Regex.IsMatch(txtNic.Text,@"^\d{12}$"))
                    {
                        l3.Visible = false;
                        return true;
                    }
                    else
                    {
                        l3.Text = "Invalid NIC number";
                        l3.Visible = true;

                        return false;
                    }
                }
                else
                {
                    l2.Text = "*Invalid Number";
                    l2.Visible = true;

                    return false;
                }
            }
            else
            {
                l1.Visible = true;

                return false;
            }
        }

        private void Save()
        {
            if (ValidateFields())
            {
                staff.Name = txtName.Text.ToUpper();
                staff.Phone = txtPhone.Text;
                staff.NIC = txtNic.Text;
                staff.Address = txtAddress.Text.ToUpper();

                if (action == "New")
                {
                    staff.Status = "ACTIVE";
                    if (control.Add(staff))
                    {
                        new ShowMessage("Success", "SUCCESS", "Record created successfully.\nStaff ID: " + staff.Id).ShowDialog();

                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        new ShowMessage("Failed", "New").ShowDialog();
                    }
                }
                else
                {
                    if (control.Update(staff))
                    {
                        new ShowMessage("Success", "Update").ShowDialog();

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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
