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
            POSSolution.Controllers.Common.Session.Instance.Id = 100;

            InitializeComponent();
            POSSolution.Views.Collection.UserControllers.CollectionDetailsUC uc = new Collection.UserControllers.CollectionDetailsUC();
            panel4.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;

            
        }
    }
}
