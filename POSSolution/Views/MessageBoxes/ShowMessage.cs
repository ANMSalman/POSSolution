using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSSolution.Views.MessageBoxes
{
    public partial class ShowMessage : Form
    {
        public ShowMessage(string type)
        {
            InitializeComponent();

            if (type == "Success")
            {
                panel3.BackColor = Color.Lime;
                btnOk.BackColor = Color.Lime;
                lblTitle.Text = "SUCCESS";
                lblMessage.Text = "New record created successfully.";
            }
            else
            {
                panel3.BackColor = Color.Red;
                btnOk.BackColor = Color.Red;
                lblTitle.Text = "FAILED";
                lblMessage.Text = "Creating new record failed.";
            }
        }

        public ShowMessage(string type,string action)
        {
            InitializeComponent();

            if(type=="Success")
            {
                panel3.BackColor = Color.Lime;
                btnOk.BackColor = Color.Lime;
                lblTitle.Text = "SUCCESS";
                if(action=="New")
                    lblMessage.Text = "New record created successfully.";
                else if (action=="Update")
                    lblMessage.Text = "Record updated successfully.";
                else if (action == "Restore")
                    lblMessage.Text = "Record restored successfully.";
                else
                    lblMessage.Text = "Record Deleted successfully.";
            }
            else
            {
                panel3.BackColor = Color.Red;
                btnOk.BackColor = Color.Red;
                lblTitle.Text = "FAILED";
                if (action == "New")
                    lblMessage.Text = "Creating new record failed.";
                else if (action == "Update")
                    lblMessage.Text = "Updating record failed.";
                else if (action == "Restore")
                    lblMessage.Text = "Restoring record failed.";
                else
                    lblMessage.Text = "Deleting record failed.";
            }
        }

        public ShowMessage(string type,string title,string message)
        {
            InitializeComponent();

            if (type == "Success")
            {
                panel3.BackColor = Color.Lime;
                btnOk.BackColor = Color.Lime;
                lblTitle.Text = title;
                lblMessage.Text = message;
            }
            else
            {
                panel3.BackColor = Color.Red;
                btnOk.BackColor = Color.Red;
                lblTitle.Text = title;
                lblMessage.Text = message;
            }
        }
    }
}
