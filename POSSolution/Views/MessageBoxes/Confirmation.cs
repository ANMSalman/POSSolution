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
    public partial class Confirmation : Form
    {
        public Confirmation(string action)
        {
            InitializeComponent();

            if (action == "Restore")
                lblMessage.Text = "Restore selected record?";

        }
    }
}
