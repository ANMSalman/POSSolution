namespace POSSolution.Views.Item.UserControllers
{
    partial class ItemDetailsUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDetailsUC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel7.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
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
            this.panel8.Controls.Add(this.dgvItems);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 57);
            this.panel8.Margin = new System.Windows.Forms.Padding(10);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(10);
            this.panel8.Size = new System.Drawing.Size(1024, 504);
            this.panel8.TabIndex = 1;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeight = 35;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(10, 10);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(10);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItems.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dgvItems.RowTemplate.Height = 35;
            this.dgvItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1004, 484);
            this.dgvItems.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.btnAll);
            this.panel7.Controls.Add(this.txtSearch);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1024, 57);
            this.panel7.TabIndex = 0;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.SystemColors.Control;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAll.Location = new System.Drawing.Point(887, 11);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(127, 32);
            this.btnAll.TabIndex = 6;
            this.btnAll.Text = "VIEW ALL";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Location = new System.Drawing.Point(120, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(265, 29);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "SEARCH TEXT:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanel1.Controls.Add(this.btnRefresh);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
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
            this.btnNew.Location = new System.Drawing.Point(887, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(127, 43);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "NEW ITEMS";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "SEARCH ITEMS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label1.Text = "ITEM DETAILS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "ITEM NAME";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "ITEM CATEGORY";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // ItemDetailsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ItemDetailsUC";
            this.Size = new System.Drawing.Size(1024, 710);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
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
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
