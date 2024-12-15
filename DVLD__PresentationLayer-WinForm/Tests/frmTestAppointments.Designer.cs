namespace DVLD__PresentationLayer_WinForm
{
    partial class frmTestAppointments
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddNewAppointment = new Guna.UI2.WinForms.Guna2Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.CMSAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAllRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.ucLDLApplicationDetails1 = new DVLD__PresentationLayer_WinForm.ucLDLApplicationDetails();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.CMSAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.BtnClose);
            this.panel1.Controls.Add(this.btnAddNewAppointment);
            this.panel1.Controls.Add(this.dgvAppointments);
            this.panel1.Controls.Add(this.lblAllRecords);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblCaption);
            this.panel1.Controls.Add(this.pbTestType);
            this.panel1.Controls.Add(this.ucLDLApplicationDetails1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 917);
            this.panel1.TabIndex = 0;
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
            this.BtnClose.Location = new System.Drawing.Point(760, 864);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.ShadowDecoration.Parent = this.BtnClose;
            this.BtnClose.Size = new System.Drawing.Size(153, 41);
            this.BtnClose.TabIndex = 28;
            this.BtnClose.Text = "Close";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.BorderColor = System.Drawing.Color.DimGray;
            this.btnAddNewAppointment.BorderRadius = 5;
            this.btnAddNewAppointment.BorderThickness = 2;
            this.btnAddNewAppointment.CheckedState.Parent = this.btnAddNewAppointment;
            this.btnAddNewAppointment.CustomImages.Parent = this.btnAddNewAppointment;
            this.btnAddNewAppointment.FillColor = System.Drawing.Color.White;
            this.btnAddNewAppointment.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewAppointment.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewAppointment.HoverState.Parent = this.btnAddNewAppointment;
            this.btnAddNewAppointment.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.add_event;
            this.btnAddNewAppointment.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAddNewAppointment.Location = new System.Drawing.Point(859, 675);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.ShadowDecoration.Parent = this.btnAddNewAppointment;
            this.btnAddNewAppointment.Size = new System.Drawing.Size(54, 47);
            this.btnAddNewAppointment.TabIndex = 27;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToResizeColumns = false;
            this.dgvAppointments.AllowUserToResizeRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.CMSAppointments;
            this.dgvAppointments.Location = new System.Drawing.Point(10, 731);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.Size = new System.Drawing.Size(903, 130);
            this.dgvAppointments.TabIndex = 26;
            this.dgvAppointments.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAppointments_CellMouseDown);
            // 
            // CMSAppointments
            // 
            this.CMSAppointments.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.CMSAppointments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMSAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.CMSAppointments.Name = "CMSAppointments";
            this.CMSAppointments.Size = new System.Drawing.Size(215, 84);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.editToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.takeTestToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.retest;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // lblAllRecords
            // 
            this.lblAllRecords.AutoSize = true;
            this.lblAllRecords.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblAllRecords.ForeColor = System.Drawing.Color.Black;
            this.lblAllRecords.Location = new System.Drawing.Point(5, 864);
            this.lblAllRecords.Name = "lblAllRecords";
            this.lblAllRecords.Size = new System.Drawing.Size(162, 28);
            this.lblAllRecords.TabIndex = 24;
            this.lblAllRecords.Text = "All Records = ???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 694);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 28);
            this.label3.TabIndex = 25;
            this.label3.Text = "Appointments :";
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.Red;
            this.lblCaption.Location = new System.Drawing.Point(10, 171);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(903, 34);
            this.lblCaption.TabIndex = 23;
            this.lblCaption.Text = "Vision Test Appointments\r\n";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTestType
            // 
            this.pbTestType.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.VesionTest;
            this.pbTestType.Location = new System.Drawing.Point(374, 12);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(174, 147);
            this.pbTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTestType.TabIndex = 22;
            this.pbTestType.TabStop = false;
            // 
            // ucLDLApplicationDetails1
            // 
            this.ucLDLApplicationDetails1.BackColor = System.Drawing.Color.White;
            this.ucLDLApplicationDetails1.Location = new System.Drawing.Point(5, 208);
            this.ucLDLApplicationDetails1.Name = "ucLDLApplicationDetails1";
            this.ucLDLApplicationDetails1.Size = new System.Drawing.Size(923, 461);
            this.ucLDLApplicationDetails1.TabIndex = 21;
            // 
            // frmTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(945, 917);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vision Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTestAppointments_FormClosing);
            this.Load += new System.EventHandler(this.frmScheduleTests_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.CMSAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button BtnClose;
        private Guna.UI2.WinForms.Guna2Button btnAddNewAppointment;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Label lblAllRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.PictureBox pbTestType;
        private ucLDLApplicationDetails ucLDLApplicationDetails1;
        private System.Windows.Forms.ContextMenuStrip CMSAppointments;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}