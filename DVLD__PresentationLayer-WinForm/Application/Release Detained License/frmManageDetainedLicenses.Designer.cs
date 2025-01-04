namespace DVLD__PresentationLayer_WinForm
{
    partial class frmManageDetainedLicenses
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtFilterText = new Guna.UI2.WinForms.Guna2TextBox();
            this.CbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.dgvDetainLicenses = new System.Windows.Forms.DataGridView();
            this.CmsManageDLGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ReleaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbReleasedStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnDetain = new Guna.UI2.WinForms.Guna2Button();
            this.btnRelease = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainLicenses)).BeginInit();
            this.CmsManageDLGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterText
            // 
            this.txtFilterText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterText.DefaultText = "";
            this.txtFilterText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilterText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilterText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterText.DisabledState.Parent = this.txtFilterText;
            this.txtFilterText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterText.FocusedState.Parent = this.txtFilterText;
            this.txtFilterText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterText.HoverState.Parent = this.txtFilterText;
            this.txtFilterText.Location = new System.Drawing.Point(372, 214);
            this.txtFilterText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.PasswordChar = '\0';
            this.txtFilterText.PlaceholderText = "";
            this.txtFilterText.SelectedText = "";
            this.txtFilterText.ShadowDecoration.Parent = this.txtFilterText;
            this.txtFilterText.Size = new System.Drawing.Size(254, 36);
            this.txtFilterText.TabIndex = 34;
            this.txtFilterText.TextChanged += new System.EventHandler(this.txtFilterText_TextChanged);
            this.txtFilterText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterText_KeyPress);
            // 
            // CbFilter
            // 
            this.CbFilter.BackColor = System.Drawing.Color.Transparent;
            this.CbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFilter.FocusedColor = System.Drawing.Color.Empty;
            this.CbFilter.FocusedState.Parent = this.CbFilter;
            this.CbFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CbFilter.FormattingEnabled = true;
            this.CbFilter.HoverState.Parent = this.CbFilter;
            this.CbFilter.ItemHeight = 30;
            this.CbFilter.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No",
            "Full Name ",
            "Release Application ID"});
            this.CbFilter.ItemsAppearance.Parent = this.CbFilter;
            this.CbFilter.Location = new System.Drawing.Point(111, 214);
            this.CbFilter.Name = "CbFilter";
            this.CbFilter.ShadowDecoration.Parent = this.CbFilter;
            this.CbFilter.Size = new System.Drawing.Size(254, 36);
            this.CbFilter.TabIndex = 33;
            this.CbFilter.SelectedIndexChanged += new System.EventHandler(this.CbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 36);
            this.label2.TabIndex = 32;
            this.label2.Text = "Filter by :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblRecordsCount.Location = new System.Drawing.Point(12, 618);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(195, 34);
            this.lblRecordsCount.TabIndex = 30;
            this.lblRecordsCount.Text = "All Records = ???";
            // 
            // dgvDetainLicenses
            // 
            this.dgvDetainLicenses.AllowUserToAddRows = false;
            this.dgvDetainLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainLicenses.AllowUserToResizeColumns = false;
            this.dgvDetainLicenses.AllowUserToResizeRows = false;
            this.dgvDetainLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetainLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvDetainLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetainLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainLicenses.ContextMenuStrip = this.CmsManageDLGrid;
            this.dgvDetainLicenses.Location = new System.Drawing.Point(14, 266);
            this.dgvDetainLicenses.Name = "dgvDetainLicenses";
            this.dgvDetainLicenses.ReadOnly = true;
            this.dgvDetainLicenses.RowHeadersWidth = 51;
            this.dgvDetainLicenses.RowTemplate.Height = 24;
            this.dgvDetainLicenses.Size = new System.Drawing.Size(1398, 346);
            this.dgvDetainLicenses.TabIndex = 29;
            // 
            // CmsManageDLGrid
            // 
            this.CmsManageDLGrid.BackColor = System.Drawing.Color.White;
            this.CmsManageDLGrid.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmsManageDLGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CmsManageDLGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.ReleaseToolStripMenuItem});
            this.CmsManageDLGrid.Name = "CmsPersonGrid";
            this.CmsManageDLGrid.Size = new System.Drawing.Size(319, 162);
            this.CmsManageDLGrid.Opening += new System.ComponentModel.CancelEventHandler(this.CmsManageDLGrid_Opening);
            // 
            // showPersonToolStripMenuItem
            // 
            this.showPersonToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.showPersonToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.Person;
            this.showPersonToolStripMenuItem.Name = "showPersonToolStripMenuItem";
            this.showPersonToolStripMenuItem.Size = new System.Drawing.Size(318, 38);
            this.showPersonToolStripMenuItem.Text = "Show Person Details";
            this.showPersonToolStripMenuItem.Click += new System.EventHandler(this.showPersonToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.driving_license;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(318, 38);
            this.showLicenseDetailsToolStripMenuItem.Text = " Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem2.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.releaseCard;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(318, 38);
            this.toolStripMenuItem2.Text = "Show Person License History";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(315, 6);
            // 
            // ReleaseToolStripMenuItem
            // 
            this.ReleaseToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReleaseToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.ReleaseToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.credit__1_;
            this.ReleaseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ReleaseToolStripMenuItem.Name = "ReleaseToolStripMenuItem";
            this.ReleaseToolStripMenuItem.Size = new System.Drawing.Size(318, 38);
            this.ReleaseToolStripMenuItem.Text = "Release License";
            this.ReleaseToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(607, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 34);
            this.label1.TabIndex = 28;
            this.label1.Text = "Detained Licenses";
            // 
            // BtnClose
            // 
            this.BtnClose.BorderColor = System.Drawing.Color.DimGray;
            this.BtnClose.BorderRadius = 10;
            this.BtnClose.BorderThickness = 2;
            this.BtnClose.CheckedState.Parent = this.BtnClose;
            this.BtnClose.CustomImages.Parent = this.BtnClose;
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.FillColor = System.Drawing.Color.White;
            this.BtnClose.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.Black;
            this.BtnClose.HoverState.Parent = this.BtnClose;
            this.BtnClose.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.close;
            this.BtnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnClose.Location = new System.Drawing.Point(1259, 618);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.ShadowDecoration.Parent = this.BtnClose;
            this.BtnClose.Size = new System.Drawing.Size(153, 45);
            this.BtnClose.TabIndex = 31;
            this.BtnClose.Text = "Close";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.DetainCard;
            this.pictureBox1.Location = new System.Drawing.Point(593, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // cbReleasedStatus
            // 
            this.cbReleasedStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbReleasedStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbReleasedStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReleasedStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cbReleasedStatus.FocusedState.Parent = this.cbReleasedStatus;
            this.cbReleasedStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbReleasedStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbReleasedStatus.FormattingEnabled = true;
            this.cbReleasedStatus.HoverState.Parent = this.cbReleasedStatus;
            this.cbReleasedStatus.ItemHeight = 30;
            this.cbReleasedStatus.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbReleasedStatus.ItemsAppearance.Parent = this.cbReleasedStatus;
            this.cbReleasedStatus.Location = new System.Drawing.Point(372, 214);
            this.cbReleasedStatus.Name = "cbReleasedStatus";
            this.cbReleasedStatus.ShadowDecoration.Parent = this.cbReleasedStatus;
            this.cbReleasedStatus.Size = new System.Drawing.Size(254, 36);
            this.cbReleasedStatus.TabIndex = 35;
            this.cbReleasedStatus.SelectedIndexChanged += new System.EventHandler(this.cbReleasedStatus_SelectedIndexChanged);
            // 
            // btnDetain
            // 
            this.btnDetain.BorderColor = System.Drawing.Color.DimGray;
            this.btnDetain.BorderRadius = 10;
            this.btnDetain.BorderThickness = 2;
            this.btnDetain.CheckedState.Parent = this.btnDetain;
            this.btnDetain.CustomImages.Parent = this.btnDetain;
            this.btnDetain.FillColor = System.Drawing.Color.White;
            this.btnDetain.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.ForeColor = System.Drawing.Color.Black;
            this.btnDetain.HoverState.Parent = this.btnDetain;
            this.btnDetain.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.DetainCard;
            this.btnDetain.ImageSize = new System.Drawing.Size(32, 32);
            this.btnDetain.Location = new System.Drawing.Point(1353, 211);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.ShadowDecoration.Parent = this.btnDetain;
            this.btnDetain.Size = new System.Drawing.Size(59, 49);
            this.btnDetain.TabIndex = 36;
            this.btnDetain.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.BorderColor = System.Drawing.Color.DimGray;
            this.btnRelease.BorderRadius = 10;
            this.btnRelease.BorderThickness = 2;
            this.btnRelease.CheckedState.Parent = this.btnRelease;
            this.btnRelease.CustomImages.Parent = this.btnRelease;
            this.btnRelease.FillColor = System.Drawing.Color.White;
            this.btnRelease.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.ForeColor = System.Drawing.Color.Black;
            this.btnRelease.HoverState.Parent = this.btnRelease;
            this.btnRelease.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.credit__1_;
            this.btnRelease.ImageSize = new System.Drawing.Size(32, 32);
            this.btnRelease.Location = new System.Drawing.Point(1288, 211);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.ShadowDecoration.Parent = this.btnRelease;
            this.btnRelease.Size = new System.Drawing.Size(59, 49);
            this.btnRelease.TabIndex = 37;
            this.btnRelease.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // frmManageDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1424, 671);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.cbReleasedStatus);
            this.Controls.Add(this.txtFilterText);
            this.Controls.Add(this.CbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.dgvDetainLicenses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Detained Licenses";
            this.Load += new System.EventHandler(this.frmManageDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainLicenses)).EndInit();
            this.CmsManageDLGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtFilterText;
        private Guna.UI2.WinForms.Guna2ComboBox CbFilter;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button BtnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.DataGridView dgvDetainLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbReleasedStatus;
        private Guna.UI2.WinForms.Guna2Button btnDetain;
        private Guna.UI2.WinForms.Guna2Button btnRelease;
        private System.Windows.Forms.ContextMenuStrip CmsManageDLGrid;
        private System.Windows.Forms.ToolStripMenuItem ReleaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}