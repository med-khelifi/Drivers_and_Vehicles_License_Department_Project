namespace DVLD__PresentationLayer_WinForm
{
    partial class ucDriverLicenses
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
            this.components = new System.ComponentModel.Container();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.tabControlUser = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblAllLocalDrivingRecords = new System.Windows.Forms.Label();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.contextMenuShowLocalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblAllInternationalLSRecords = new System.Windows.Forms.Label();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.contextMenuStripShowInternationalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2GroupBox1.SuspendLayout();
            this.tabControlUser.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.contextMenuShowLocalLicense.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.contextMenuStripShowInternationalLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.tabControlUser);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(2);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(3, 3);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(1038, 293);
            this.guna2GroupBox1.TabIndex = 14;
            this.guna2GroupBox1.Text = "Driver Licenses :";
            // 
            // tabControlUser
            // 
            this.tabControlUser.Controls.Add(this.tabPage1);
            this.tabControlUser.Controls.Add(this.tabPage2);
            this.tabControlUser.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlUser.Location = new System.Drawing.Point(3, 38);
            this.tabControlUser.Name = "tabControlUser";
            this.tabControlUser.SelectedIndex = 0;
            this.tabControlUser.Size = new System.Drawing.Size(1032, 252);
            this.tabControlUser.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.lblAllLocalDrivingRecords);
            this.tabPage1.Controls.Add(this.dgvLocalLicenses);
            this.tabPage1.Font = new System.Drawing.Font("Bahnschrift SemiLight Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1024, 215);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            // 
            // lblAllLocalDrivingRecords
            // 
            this.lblAllLocalDrivingRecords.AutoSize = true;
            this.lblAllLocalDrivingRecords.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblAllLocalDrivingRecords.ForeColor = System.Drawing.Color.Black;
            this.lblAllLocalDrivingRecords.Location = new System.Drawing.Point(6, 184);
            this.lblAllLocalDrivingRecords.Name = "lblAllLocalDrivingRecords";
            this.lblAllLocalDrivingRecords.Size = new System.Drawing.Size(162, 28);
            this.lblAllLocalDrivingRecords.TabIndex = 32;
            this.lblAllLocalDrivingRecords.Text = "All Records = ???";
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AllowUserToResizeColumns = false;
            this.dgvLocalLicenses.AllowUserToResizeRows = false;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.ContextMenuStrip = this.contextMenuShowLocalLicense;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(11, 6);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.RowHeadersWidth = 51;
            this.dgvLocalLicenses.RowTemplate.Height = 24;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(1007, 164);
            this.dgvLocalLicenses.TabIndex = 31;
            this.dgvLocalLicenses.Tag = "Local";
            // 
            // contextMenuShowLocalLicense
            // 
            this.contextMenuShowLocalLicense.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuShowLocalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseToolStripMenuItem});
            this.contextMenuShowLocalLicense.Name = "contextMenuShowLicense";
            this.contextMenuShowLocalLicense.Size = new System.Drawing.Size(188, 30);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.showLicenseToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.driving_license;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblAllInternationalLSRecords);
            this.tabPage2.Controls.Add(this.dgvInternationalLicenses);
            this.tabPage2.Font = new System.Drawing.Font("Bahnschrift SemiLight Condensed", 12F);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1024, 215);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblAllInternationalLSRecords
            // 
            this.lblAllInternationalLSRecords.AutoSize = true;
            this.lblAllInternationalLSRecords.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblAllInternationalLSRecords.ForeColor = System.Drawing.Color.Black;
            this.lblAllInternationalLSRecords.Location = new System.Drawing.Point(6, 184);
            this.lblAllInternationalLSRecords.Name = "lblAllInternationalLSRecords";
            this.lblAllInternationalLSRecords.Size = new System.Drawing.Size(153, 28);
            this.lblAllInternationalLSRecords.TabIndex = 29;
            this.lblAllInternationalLSRecords.Text = "All Records = ??";
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
            this.dgvInternationalLicenses.ContextMenuStrip = this.contextMenuShowLocalLicense;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(11, 6);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.RowHeadersWidth = 51;
            this.dgvInternationalLicenses.RowTemplate.Height = 24;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1007, 164);
            this.dgvInternationalLicenses.TabIndex = 28;
            this.dgvInternationalLicenses.Tag = "Inter";
            // 
            // contextMenuStripShowInternationalLicense
            // 
            this.contextMenuStripShowInternationalLicense.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripShowInternationalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStripShowInternationalLicense.Name = "contextMenuShowLicense";
            this.contextMenuStripShowInternationalLicense.Size = new System.Drawing.Size(215, 58);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.toolStripMenuItem1.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.driving_license;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(214, 26);
            this.toolStripMenuItem1.Text = "Show License";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ucDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GroupBox1);
            this.Name = "ucDriverLicenses";
            this.Size = new System.Drawing.Size(1043, 298);
            this.guna2GroupBox1.ResumeLayout(false);
            this.tabControlUser.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.contextMenuShowLocalLicense.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.contextMenuStripShowInternationalLicense.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.TabControl tabControlUser;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblAllLocalDrivingRecords;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblAllInternationalLSRecords;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.ContextMenuStrip contextMenuShowLocalLicense;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripShowInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
