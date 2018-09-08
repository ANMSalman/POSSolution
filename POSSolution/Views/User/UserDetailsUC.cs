using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSSolution.Views.User
{
    public partial class UserDetailsUC : UserControl
    {
        public UserDetailsUC()
        {
            InitializeComponent();

            dataGridView1.Rows.Add(
                "aa",
                "USER NAME",
                "cc",
                "dd"
                );
            dataGridView1.Rows.Add(
                "aa",
                "bb",
                "cc",
                "dd"
                );
            dataGridView1.Rows.Add(
                "aa",
                "bb",
                "cc",
                "dd"
                );
            dataGridView1.Rows.Add(
                "aa",
                "bb",
                "cc",
                "dd"
                );

            panel8.Padding = new Padding(10);
        }
    }
}
