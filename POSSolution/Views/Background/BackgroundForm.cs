using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSSolution.Views.Background
{
    public partial class BackgroundForm : Form
    {
        public BackgroundForm()
        {
            InitializeComponent();
            POSSolution.Views.Staff.UserControllers.StaffDetailsUC uc = new Staff.UserControllers.StaffDetailsUC();
            panel4.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;

            
        }
    }
}
