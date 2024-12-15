namespace DVLD__PresentationLayer_WinForm
{
    partial class frmMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kllmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseInternaticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementForLostOrDamagedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePassworddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16.2F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(80, 80);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kllmToolStripMenuItem,
            this.smPeople,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem1,
            this.accountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10);
            this.menuStrip1.Size = new System.Drawing.Size(1458, 97);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kllmToolStripMenuItem
            // 
            this.kllmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicensesToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.detainToolStripMenuItem,
            this.manageApplicationTypesToolStripMenuItem,
            this.manageTestTypeToolStripMenuItem});
            this.kllmToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.applications;
            this.kllmToolStripMenuItem.Name = "kllmToolStripMenuItem";
            this.kllmToolStripMenuItem.Size = new System.Drawing.Size(241, 77);
            this.kllmToolStripMenuItem.Text = "Applications";
            // 
            // drivingLicensesToolStripMenuItem
            // 
            this.drivingLicensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.replacementForLostOrDamagedLicenseToolStripMenuItem,
            this.releaseDetainedDrivingLicenseToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.drivingLicensesToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold);
            this.drivingLicensesToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.driving_license;
            this.drivingLicensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.drivingLicensesToolStripMenuItem.Name = "drivingLicensesToolStripMenuItem";
            this.drivingLicensesToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
            this.drivingLicensesToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.licenseInternaticToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.NewCard;
            this.newDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(431, 38);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.id_card;
            this.localLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // licenseInternaticToolStripMenuItem
            // 
            this.licenseInternaticToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.InternationalLisence__1_;
            this.licenseInternaticToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.licenseInternaticToolStripMenuItem.Name = "licenseInternaticToolStripMenuItem";
            this.licenseInternaticToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.licenseInternaticToolStripMenuItem.Text = "International License";
            this.licenseInternaticToolStripMenuItem.Click += new System.EventHandler(this.licenseInternaticToolStripMenuItem_Click);
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.RenewCard;
            this.renewDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(431, 38);
            this.renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            this.renewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // replacementForLostOrDamagedLicenseToolStripMenuItem
            // 
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.ReplacementCard;
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Name = "replacementForLostOrDamagedLicenseToolStripMenuItem";
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Size = new System.Drawing.Size(431, 38);
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Text = "Replacement for Lost or Damaged License";
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Click += new System.EventHandler(this.replacementForLostOrDamagedLicenseToolStripMenuItem_Click);
            // 
            // releaseDetainedDrivingLicenseToolStripMenuItem
            // 
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.releaseCard;
            this.releaseDetainedDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Name = "releaseDetainedDrivingLicenseToolStripMenuItem";
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(431, 38);
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Text = "Release Detained Driving License";
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.management;
            this.retakeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(431, 38);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            this.retakeTestToolStripMenuItem.Click += new System.EventHandler(this.retakeTestToolStripMenuItem_Click);
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseApplicationToolStripMenuItem,
            this.internationalLicenseApplicationToolStripMenuItem});
            this.manageApplicationsToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold);
            this.manageApplicationsToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.management;
            this.manageApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
            this.manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // localDrivingLicenseApplicationToolStripMenuItem
            // 
            this.localDrivingLicenseApplicationToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.id_card;
            this.localDrivingLicenseApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.localDrivingLicenseApplicationToolStripMenuItem.Name = "localDrivingLicenseApplicationToolStripMenuItem";
            this.localDrivingLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(359, 38);
            this.localDrivingLicenseApplicationToolStripMenuItem.Text = "Local Driving License Application";
            this.localDrivingLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenseApplicationToolStripMenuItem_Click);
            // 
            // internationalLicenseApplicationToolStripMenuItem
            // 
            this.internationalLicenseApplicationToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.InternationalLisence__1_;
            this.internationalLicenseApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.internationalLicenseApplicationToolStripMenuItem.Name = "internationalLicenseApplicationToolStripMenuItem";
            this.internationalLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(359, 38);
            this.internationalLicenseApplicationToolStripMenuItem.Text = "International License Application";
            this.internationalLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseApplicationToolStripMenuItem_Click);
            // 
            // detainToolStripMenuItem
            // 
            this.detainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainedLicenseToolStripMenuItem,
            this.detainLicenseToolStripMenuItem,
            this.releaseDToolStripMenuItem});
            this.detainToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold);
            this.detainToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.secure_payment;
            this.detainToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detainToolStripMenuItem.Name = "detainToolStripMenuItem";
            this.detainToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
            this.detainToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageDetainedLicenseToolStripMenuItem
            // 
            this.manageDetainedLicenseToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.secure_payment;
            this.manageDetainedLicenseToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageDetainedLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageDetainedLicenseToolStripMenuItem.Name = "manageDetainedLicenseToolStripMenuItem";
            this.manageDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.manageDetainedLicenseToolStripMenuItem.Text = "Manage Detained License";
            this.manageDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.manageDetainedLicenseToolStripMenuItem_Click);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.secure_payment;
            this.detainLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            this.detainLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem_Click);
            // 
            // releaseDToolStripMenuItem
            // 
            this.releaseDToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.credit__1_;
            this.releaseDToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDToolStripMenuItem.Name = "releaseDToolStripMenuItem";
            this.releaseDToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.releaseDToolStripMenuItem.Text = "Release detained License";
            this.releaseDToolStripMenuItem.Click += new System.EventHandler(this.releaseDToolStripMenuItem_Click);
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            this.manageApplicationTypesToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold);
            this.manageApplicationTypesToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.checklist;
            this.manageApplicationTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
            this.manageApplicationTypesToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // manageTestTypeToolStripMenuItem
            // 
            this.manageTestTypeToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold);
            this.manageTestTypeToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.tasks;
            this.manageTestTypeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageTestTypeToolStripMenuItem.Name = "manageTestTypeToolStripMenuItem";
            this.manageTestTypeToolStripMenuItem.Size = new System.Drawing.Size(307, 38);
            this.manageTestTypeToolStripMenuItem.Text = "Manage Test Type";
            this.manageTestTypeToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypeToolStripMenuItem_Click);
            // 
            // smPeople
            // 
            this.smPeople.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smPeople.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smPeople.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.team;
            this.smPeople.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.smPeople.Name = "smPeople";
            this.smPeople.Padding = new System.Windows.Forms.Padding(5, 20, 5, 0);
            this.smPeople.Size = new System.Drawing.Size(203, 77);
            this.smPeople.Text = "   People";
            this.smPeople.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.smPeople.Click += new System.EventHandler(this.smPeople_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.driver;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(187, 77);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem1
            // 
            this.usersToolStripMenuItem1.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.boy;
            this.usersToolStripMenuItem1.Name = "usersToolStripMenuItem1";
            this.usersToolStripMenuItem1.Size = new System.Drawing.Size(171, 77);
            this.usersToolStripMenuItem1.Text = "Users";
            this.usersToolStripMenuItem1.Click += new System.EventHandler(this.usersToolStripMenuItem1_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePassworddToolStripMenuItem,
            this.toolStripMenuItem1});
            this.accountSettingsToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.user_profile;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(292, 77);
            this.accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentUserInfoToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.u;
            this.currentUserInfoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.currentUserInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(246, 38);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePassworddToolStripMenuItem
            // 
            this.changePassworddToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold);
            this.changePassworddToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.reset_password;
            this.changePassworddToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changePassworddToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePassworddToolStripMenuItem.Name = "changePassworddToolStripMenuItem";
            this.changePassworddToolStripMenuItem.Size = new System.Drawing.Size(246, 38);
            this.changePassworddToolStripMenuItem.Text = "change Password";
            this.changePassworddToolStripMenuItem.Click += new System.EventHandler(this.changePassworddToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.logout__1_;
            this.toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(246, 38);
            this.toolStripMenuItem1.Text = "Logout";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1458, 779);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1458, 779);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 876);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Driving Managers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem smPeople;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kllmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePassworddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem drivingLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseInternaticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementForLostOrDamagedLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDToolStripMenuItem;
    }
}

