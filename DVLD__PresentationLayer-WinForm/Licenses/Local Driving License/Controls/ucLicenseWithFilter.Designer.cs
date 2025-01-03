namespace DVLD__PresentationLayer_WinForm
{
    partial class ucLicenseWithFilter
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.txtLicenseID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchLicense = new Guna.UI2.WinForms.Guna2Button();
            this.ucDriverLicenseInfo1 = new DVLD__PresentationLayer_WinForm.ucDriverLicenseInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.BackColor = System.Drawing.Color.White;
            this.gbFilter.Controls.Add(this.txtLicenseID);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Controls.Add(this.btnSearchLicense);
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1082, 74);
            this.gbFilter.TabIndex = 13;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter :";
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLicenseID.DefaultText = "";
            this.txtLicenseID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLicenseID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLicenseID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLicenseID.DisabledState.Parent = this.txtLicenseID;
            this.txtLicenseID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLicenseID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicenseID.FocusedState.Parent = this.txtLicenseID;
            this.txtLicenseID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicenseID.HoverState.Parent = this.txtLicenseID;
            this.txtLicenseID.Location = new System.Drawing.Point(169, 22);
            this.txtLicenseID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.PasswordChar = '\0';
            this.txtLicenseID.PlaceholderText = "";
            this.txtLicenseID.SelectedText = "";
            this.txtLicenseID.ShadowDecoration.Parent = this.txtLicenseID;
            this.txtLicenseID.Size = new System.Drawing.Size(451, 44);
            this.txtLicenseID.TabIndex = 9;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterText_KeyPress);
            this.txtLicenseID.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicenseID_Validating);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(41, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 36);
            this.label2.TabIndex = 7;
            this.label2.Text = "License ID : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearchLicense
            // 
            this.btnSearchLicense.BorderColor = System.Drawing.Color.DimGray;
            this.btnSearchLicense.BorderRadius = 10;
            this.btnSearchLicense.BorderThickness = 2;
            this.btnSearchLicense.CheckedState.Parent = this.btnSearchLicense;
            this.btnSearchLicense.CustomImages.Parent = this.btnSearchLicense;
            this.btnSearchLicense.FillColor = System.Drawing.Color.White;
            this.btnSearchLicense.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchLicense.ForeColor = System.Drawing.Color.Black;
            this.btnSearchLicense.HoverState.Parent = this.btnSearchLicense;
            this.btnSearchLicense.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.driving_license;
            this.btnSearchLicense.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSearchLicense.Location = new System.Drawing.Point(639, 22);
            this.btnSearchLicense.Name = "btnSearchLicense";
            this.btnSearchLicense.ShadowDecoration.Parent = this.btnSearchLicense;
            this.btnSearchLicense.Size = new System.Drawing.Size(65, 44);
            this.btnSearchLicense.TabIndex = 10;
            this.btnSearchLicense.Click += new System.EventHandler(this.btnSearchLicense_Click);
            // 
            // ucDriverLicenseInfo1
            // 
            this.ucDriverLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ucDriverLicenseInfo1.Location = new System.Drawing.Point(3, 83);
            this.ucDriverLicenseInfo1.Name = "ucDriverLicenseInfo1";
            this.ucDriverLicenseInfo1.Size = new System.Drawing.Size(1096, 374);
            this.ucDriverLicenseInfo1.TabIndex = 14;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucLicenseWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucDriverLicenseInfo1);
            this.Controls.Add(this.gbFilter);
            this.Name = "ucLicenseWithFilter";
            this.Size = new System.Drawing.Size(1095, 461);
            this.gbFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private Guna.UI2.WinForms.Guna2TextBox txtLicenseID;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnSearchLicense;
        private ucDriverLicenseInfo ucDriverLicenseInfo1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
