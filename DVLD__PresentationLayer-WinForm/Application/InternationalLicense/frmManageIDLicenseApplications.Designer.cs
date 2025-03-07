﻿namespace DVLD__PresentationLayer_WinForm
{
    partial class frmManageIDLicenseApplications
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
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.CbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.CmsManageIDLGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.issureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.cbisActive = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.CmsManageIDLGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.DefaultText = "";
            this.txtFilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.DisabledState.Parent = this.txtFilterValue;
            this.txtFilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.FocusedState.Parent = this.txtFilterValue;
            this.txtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.HoverState.Parent = this.txtFilterValue;
            this.txtFilterValue.Location = new System.Drawing.Point(389, 244);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PasswordChar = '\0';
            this.txtFilterValue.PlaceholderText = "";
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.ShadowDecoration.Parent = this.txtFilterValue;
            this.txtFilterValue.Size = new System.Drawing.Size(195, 36);
            this.txtFilterValue.TabIndex = 26;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
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
            "International License ID",
            "Application ID",
            "Driver ID",
            "Local License ID",
            "Is Active"});
            this.CbFilter.ItemsAppearance.Parent = this.CbFilter;
            this.CbFilter.Location = new System.Drawing.Point(110, 244);
            this.CbFilter.Name = "CbFilter";
            this.CbFilter.ShadowDecoration.Parent = this.CbFilter;
            this.CbFilter.Size = new System.Drawing.Size(254, 36);
            this.CbFilter.TabIndex = 25;
            this.CbFilter.SelectedIndexChanged += new System.EventHandler(this.CbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 36);
            this.label2.TabIndex = 24;
            this.label2.Text = "Filter by :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblRecordsCount.Location = new System.Drawing.Point(7, 648);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(195, 34);
            this.lblRecordsCount.TabIndex = 22;
            this.lblRecordsCount.Text = "All Records = ???";
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AllowUserToResizeColumns = false;
            this.dgvInternationalLicenses.AllowUserToResizeRows = false;
            this.dgvInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvInternationalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.CmsManageIDLGrid;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(13, 296);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.RowHeadersWidth = 51;
            this.dgvInternationalLicenses.RowTemplate.Height = 24;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1398, 346);
            this.dgvInternationalLicenses.TabIndex = 21;
            // 
            // CmsManageIDLGrid
            // 
            this.CmsManageIDLGrid.BackColor = System.Drawing.Color.White;
            this.CmsManageIDLGrid.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmsManageIDLGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CmsManageIDLGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issureToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.CmsManageIDLGrid.Name = "CmsPersonGrid";
            this.CmsManageIDLGrid.Size = new System.Drawing.Size(307, 82);
            // 
            // issureToolStripMenuItem
            // 
            this.issureToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issureToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.issureToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.person_boy;
            this.issureToolStripMenuItem.Name = "issureToolStripMenuItem";
            this.issureToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.issureToolStripMenuItem.Text = "Show Person Details";
            this.issureToolStripMenuItem.Click += new System.EventHandler(this.issureToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLicenseToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.showLicenseToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.driving_license;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License Details";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPersonLicenseHistoryToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.releaseCard;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(476, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 34);
            this.label1.TabIndex = 20;
            this.label1.Text = "Manage International Driving License Application\r\n";
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
            this.BtnClose.Location = new System.Drawing.Point(1260, 648);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.ShadowDecoration.Parent = this.BtnClose;
            this.BtnClose.Size = new System.Drawing.Size(153, 45);
            this.BtnClose.TabIndex = 23;
            this.BtnClose.Text = "Close";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.passport;
            this.pictureBox1.Location = new System.Drawing.Point(614, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderColor = System.Drawing.Color.DimGray;
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.addApplication;
            this.guna2Button2.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button2.Location = new System.Drawing.Point(1338, 230);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(70, 60);
            this.guna2Button2.TabIndex = 27;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // cbisActive
            // 
            this.cbisActive.BackColor = System.Drawing.Color.Transparent;
            this.cbisActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbisActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbisActive.FocusedColor = System.Drawing.Color.Empty;
            this.cbisActive.FocusedState.Parent = this.cbisActive;
            this.cbisActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbisActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbisActive.FormattingEnabled = true;
            this.cbisActive.HoverState.Parent = this.cbisActive;
            this.cbisActive.ItemHeight = 30;
            this.cbisActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbisActive.ItemsAppearance.Parent = this.cbisActive;
            this.cbisActive.Location = new System.Drawing.Point(389, 244);
            this.cbisActive.Name = "cbisActive";
            this.cbisActive.ShadowDecoration.Parent = this.cbisActive;
            this.cbisActive.Size = new System.Drawing.Size(195, 36);
            this.cbisActive.TabIndex = 28;
            this.cbisActive.SelectedIndexChanged += new System.EventHandler(this.cbisActive_SelectedIndexChanged);
            // 
            // frmManageIDLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1420, 703);
            this.Controls.Add(this.cbisActive);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.CbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.dgvInternationalLicenses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageIDLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage International Licenses Applications";
            this.Load += new System.EventHandler(this.frmManageIDLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.CmsManageIDLGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2ComboBox CbFilter;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button BtnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip CmsManageIDLGrid;
        private System.Windows.Forms.ToolStripMenuItem issureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2ComboBox cbisActive;
    }
}