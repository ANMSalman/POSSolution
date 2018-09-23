namespace POSSolution.Views.Expense.UserControllers
{
    partial class ExpenseDetailsUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseDetailsUC));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.rbBetween = new System.Windows.Forms.RadioButton();
            this.dtpOn = new System.Windows.Forms.DateTimePicker();
            this.rbOn = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 710);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1024, 663);
            this.panel3.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 51);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1024, 561);
            this.panel6.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dgvExpenses);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 57);
            this.panel8.Margin = new System.Windows.Forms.Padding(10);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(10);
            this.panel8.Size = new System.Drawing.Size(1024, 504);
            this.panel8.TabIndex = 1;
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.AllowUserToAddRows = false;
            this.dgvExpenses.AllowUserToDeleteRows = false;
            this.dgvExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpenses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvExpenses.ColumnHeadersHeight = 35;
            this.dgvExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpenses.Location = new System.Drawing.Point(10, 10);
            this.dgvExpenses.Margin = new System.Windows.Forms.Padding(10);
            this.dgvExpenses.MultiSelect = false;
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.ReadOnly = true;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExpenses.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvExpenses.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dgvExpenses.RowTemplate.Height = 35;
            this.dgvExpenses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenses.Size = new System.Drawing.Size(1004, 484);
            this.dgvExpenses.TabIndex = 2;
            // 
            // Column1
            // 
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle20;
            this.Column1.HeaderText = "EXPENSE ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Column2.DefaultCellStyle = dataGridViewCellStyle21;
            this.Column2.HeaderText = "DATE";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Column3.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column3.HeaderText = "DESCRIPTION";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column4.HeaderText = "AMOUNT";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ADDED BY";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.groupBox1);
            this.panel7.Controls.Add(this.btnSearch);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1024, 57);
            this.panel7.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.rbBetween);
            this.groupBox1.Controls.Add(this.dtpOn);
            this.groupBox1.Controls.Add(this.rbOn);
            this.groupBox1.Location = new System.Drawing.Point(10, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 44);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(593, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "AND";
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpTo.CustomFormat = "dd-MM-yyyy";
            this.dtpTo.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(642, 11);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(209, 29);
            this.dtpTo.TabIndex = 4;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFrom.CustomFormat = "dd-MM-yyyy";
            this.dtpFrom.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(390, 11);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(197, 29);
            this.dtpFrom.TabIndex = 3;
            // 
            // rbBetween
            // 
            this.rbBetween.AutoSize = true;
            this.rbBetween.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbBetween.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbBetween.Location = new System.Drawing.Point(288, 11);
            this.rbBetween.Name = "rbBetween";
            this.rbBetween.Size = new System.Drawing.Size(96, 25);
            this.rbBetween.TabIndex = 2;
            this.rbBetween.Text = "BETWEEN";
            this.rbBetween.UseVisualStyleBackColor = true;
            // 
            // dtpOn
            // 
            this.dtpOn.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpOn.CustomFormat = "dd-MM-yyyy";
            this.dtpOn.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpOn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOn.Location = new System.Drawing.Point(66, 11);
            this.dtpOn.Name = "dtpOn";
            this.dtpOn.Size = new System.Drawing.Size(203, 29);
            this.dtpOn.TabIndex = 1;
            // 
            // rbOn
            // 
            this.rbOn.AutoSize = true;
            this.rbOn.Checked = true;
            this.rbOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbOn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbOn.Location = new System.Drawing.Point(8, 11);
            this.rbOn.Name = "rbOn";
            this.rbOn.Size = new System.Drawing.Size(52, 25);
            this.rbOn.TabIndex = 0;
            this.rbOn.TabStop = true;
            this.rbOn.Text = "ON";
            this.rbOn.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(876, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(138, 32);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanel1.Controls.Add(this.btnRefresh);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 612);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1024, 51);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(10, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(127, 46);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Gold;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Location = new System.Drawing.Point(143, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(127, 46);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(276, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(127, 46);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.btnNew);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1024, 51);
            this.panel4.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Lime;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNew.Location = new System.Drawing.Point(876, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(138, 43);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "NEW EXPENSE";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 43);
            this.label2.TabIndex = 0;
            this.label2.Text = "SEARCH EXPENSES";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.pbBack);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 47);
            this.panel2.TabIndex = 0;
            // 
            // pbBack
            // 
            this.pbBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(0, 0);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(63, 47);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 0;
            this.pbBack.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1024, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "EXPENSE DETAILS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTotal);
            this.panel5.Location = new System.Drawing.Point(409, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(605, 46);
            this.panel5.TabIndex = 7;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.Location = new System.Drawing.Point(391, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(211, 21);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "TOTAL: 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ExpenseDetailsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ExpenseDetailsUC";
            this.Size = new System.Drawing.Size(1024, 710);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.panel7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgvExpenses;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpOn;
        private System.Windows.Forms.RadioButton rbOn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.RadioButton rbBetween;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotal;
    }
}
