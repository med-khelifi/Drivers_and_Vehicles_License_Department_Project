namespace DVLD__PresentationLayer_WinForm
{
    partial class frmManageLocalDrivingLicenseApplication
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
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.dgvLDLApplication = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilterText = new Guna.UI2.WinForms.Guna2TextBox();
            this.CbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.BtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblRecordsCount.Location = new System.Drawing.Point(4, 651);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(195, 34);
            this.lblRecordsCount.TabIndex = 13;
            this.lblRecordsCount.Text = "All Records = ???";
            // 
            // dgvLDLApplication
            // 
            this.dgvLDLApplication.AllowUserToAddRows = false;
            this.dgvLDLApplication.AllowUserToDeleteRows = false;
            this.dgvLDLApplication.AllowUserToResizeColumns = false;
            this.dgvLDLApplication.AllowUserToResizeRows = false;
            this.dgvLDLApplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLDLApplication.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvLDLApplication.BackgroundColor = System.Drawing.Color.White;
            this.dgvLDLApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLDLApplication.Location = new System.Drawing.Point(10, 299);
            this.dgvLDLApplication.Name = "dgvLDLApplication";
            this.dgvLDLApplication.ReadOnly = true;
            this.dgvLDLApplication.RowHeadersWidth = 51;
            this.dgvLDLApplication.RowTemplate.Height = 24;
            this.dgvLDLApplication.Size = new System.Drawing.Size(1398, 346);
            this.dgvLDLApplication.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(511, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 34);
            this.label1.TabIndex = 11;
            this.label1.Text = "Manage Lacal Driving License Application\r\n\r\n\r\n\r\n\r\n";
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
            this.txtFilterText.Location = new System.Drawing.Point(368, 247);
            this.txtFilterText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.PasswordChar = '\0';
            this.txtFilterText.PlaceholderText = "";
            this.txtFilterText.SelectedText = "";
            this.txtFilterText.ShadowDecoration.Parent = this.txtFilterText;
            this.txtFilterText.Size = new System.Drawing.Size(170, 36);
            this.txtFilterText.TabIndex = 17;
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
            "Person ID",
            "Nationality No",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Gender",
            "Nationality",
            "Email",
            "phone"});
            this.CbFilter.ItemsAppearance.Parent = this.CbFilter;
            this.CbFilter.Location = new System.Drawing.Point(107, 247);
            this.CbFilter.Name = "CbFilter";
            this.CbFilter.ShadowDecoration.Parent = this.CbFilter;
            this.CbFilter.Size = new System.Drawing.Size(254, 36);
            this.CbFilter.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 36);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filter by :";
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
            this.guna2Button2.Location = new System.Drawing.Point(1325, 233);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(70, 60);
            this.guna2Button2.TabIndex = 18;
            // 
            // BtnClose
            // 
            this.BtnClose.BorderColor = System.Drawing.Color.DimGray;
            this.BtnClose.BorderRadius = 10;
            this.BtnClose.BorderThickness = 2;
            this.BtnClose.CheckedState.Parent = this.BtnClose;
            this.BtnClose.CustomImages.Parent = this.BtnClose;
            this.BtnClose.FillColor = System.Drawing.Color.White;
            this.BtnClose.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.Black;
            this.BtnClose.HoverState.Parent = this.BtnClose;
            this.BtnClose.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.close;
            this.BtnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnClose.Location = new System.Drawing.Point(1257, 651);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.ShadowDecoration.Parent = this.BtnClose;
            this.BtnClose.Size = new System.Drawing.Size(153, 45);
            this.BtnClose.TabIndex = 14;
            this.BtnClose.Text = "Close";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.application;
            this.pictureBox1.Location = new System.Drawing.Point(586, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1420, 703);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.txtFilterText);
            this.Controls.Add(this.CbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.dgvLDLApplication);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageLocalDrivingLicenseApplication";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button BtnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.DataGridView dgvLDLApplication;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterText;
        private Guna.UI2.WinForms.Guna2ComboBox CbFilter;
        private System.Windows.Forms.Label label2;
    }
}