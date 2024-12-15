namespace DVLD__PresentationLayer_WinForm
{
    partial class frmIssueDrivingLicenseFirstTime
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
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btnIssue = new Guna.UI2.WinForms.Guna2Button();
            this.BtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.ucLDLApplicationDetails1 = new DVLD__PresentationLayer_WinForm.ucLDLApplicationDetails();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.txtNotes);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.pictureBox7);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(2);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(3, 461);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(913, 120);
            this.guna2GroupBox1.TabIndex = 48;
            // 
            // txtNotes
            // 
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.Parent = this.txtNotes;
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.FocusedState.Parent = this.txtNotes;
            this.txtNotes.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.HoverState.Parent = this.txtNotes;
            this.txtNotes.Location = new System.Drawing.Point(179, 18);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(647, 1229, 647, 1229);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PasswordChar = '\0';
            this.txtNotes.PlaceholderText = "";
            this.txtNotes.SelectedText = "";
            this.txtNotes.ShadowDecoration.Parent = this.txtNotes;
            this.txtNotes.Size = new System.Drawing.Size(721, 90);
            this.txtNotes.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(45, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 24);
            this.label6.TabIndex = 30;
            this.label6.Text = "Notes :";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.retest;
            this.pictureBox7.Location = new System.Drawing.Point(124, 15);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 41;
            this.pictureBox7.TabStop = false;
            // 
            // btnIssue
            // 
            this.btnIssue.BorderColor = System.Drawing.Color.DimGray;
            this.btnIssue.BorderRadius = 10;
            this.btnIssue.BorderThickness = 2;
            this.btnIssue.CheckedState.Parent = this.btnIssue;
            this.btnIssue.CustomImages.Parent = this.btnIssue;
            this.btnIssue.FillColor = System.Drawing.Color.White;
            this.btnIssue.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.Black;
            this.btnIssue.HoverState.Parent = this.btnIssue;
            this.btnIssue.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.releaseCard;
            this.btnIssue.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnIssue.ImageSize = new System.Drawing.Size(32, 32);
            this.btnIssue.Location = new System.Drawing.Point(719, 587);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.ShadowDecoration.Parent = this.btnIssue;
            this.btnIssue.Size = new System.Drawing.Size(197, 45);
            this.btnIssue.TabIndex = 49;
            this.btnIssue.Text = "Issue";
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
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
            this.BtnClose.Location = new System.Drawing.Point(516, 587);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.ShadowDecoration.Parent = this.BtnClose;
            this.BtnClose.Size = new System.Drawing.Size(197, 45);
            this.BtnClose.TabIndex = 50;
            this.BtnClose.Text = "Close";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ucLDLApplicationDetails1
            // 
            this.ucLDLApplicationDetails1.BackColor = System.Drawing.Color.White;
            this.ucLDLApplicationDetails1.Location = new System.Drawing.Point(3, 2);
            this.ucLDLApplicationDetails1.Name = "ucLDLApplicationDetails1";
            this.ucLDLApplicationDetails1.Size = new System.Drawing.Size(917, 456);
            this.ucLDLApplicationDetails1.TabIndex = 0;
            // 
            // frmIssueDrivingLicenseFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(923, 647);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.ucLDLApplicationDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIssueDrivingLicenseFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Driving License First Time";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIssueDrivingLicenseFirstTime_FormClosing);
            this.Load += new System.EventHandler(this.frmIssueDrivingLicenseFirstTime_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucLDLApplicationDetails ucLDLApplicationDetails1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private Guna.UI2.WinForms.Guna2Button btnIssue;
        private Guna.UI2.WinForms.Guna2Button BtnClose;
    }
}