namespace DVLD__PresentationLayer_WinForm
{
    partial class frmLicensesHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.p1 = new DVLD__PresentationLayer_WinForm.PersonDetailsControl();
            this.ucDriverLicenses1 = new DVLD__PresentationLayer_WinForm.ucDriverLicenses();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(413, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 40);
            this.label1.TabIndex = 12;
            this.label1.Text = "Licenses History";
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
            this.BtnClose.Location = new System.Drawing.Point(897, 757);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.ShadowDecoration.Parent = this.BtnClose;
            this.BtnClose.Size = new System.Drawing.Size(153, 41);
            this.BtnClose.TabIndex = 29;
            this.BtnClose.Text = "Close";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Gender = "_";
            this.p1.Location = new System.Drawing.Point(12, 90);
            this.p1.Name = "p1";
            this.p1.PersonID = "_";
            this.p1.Size = new System.Drawing.Size(1038, 358);
            this.p1.TabIndex = 0;
            // 
            // ucDriverLicenses1
            // 
            this.ucDriverLicenses1.Location = new System.Drawing.Point(7, 454);
            this.ucDriverLicenses1.Name = "ucDriverLicenses1";
            this.ucDriverLicenses1.Size = new System.Drawing.Size(1043, 298);
            this.ucDriverLicenses1.TabIndex = 30;
            // 
            // frmLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1061, 807);
            this.Controls.Add(this.ucDriverLicenses1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licenses History";
            this.Load += new System.EventHandler(this.frmLicensesHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersonDetailsControl p1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button BtnClose;
        private ucDriverLicenses ucDriverLicenses1;
    }
}