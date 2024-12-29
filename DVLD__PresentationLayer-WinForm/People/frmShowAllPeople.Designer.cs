using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    partial class frmShowAllPeople
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
            this.dgvAllPeopleData = new System.Windows.Forms.DataGridView();
            this.CmsPersonGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.CbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFilterText = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewPerson = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnClose = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeopleData)).BeginInit();
            this.CmsPersonGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllPeopleData
            // 
            this.dgvAllPeopleData.AllowUserToAddRows = false;
            this.dgvAllPeopleData.AllowUserToDeleteRows = false;
            this.dgvAllPeopleData.AllowUserToResizeColumns = false;
            this.dgvAllPeopleData.AllowUserToResizeRows = false;
            this.dgvAllPeopleData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllPeopleData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvAllPeopleData.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllPeopleData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllPeopleData.ContextMenuStrip = this.CmsPersonGrid;
            this.dgvAllPeopleData.Location = new System.Drawing.Point(9, 322);
            this.dgvAllPeopleData.Name = "dgvAllPeopleData";
            this.dgvAllPeopleData.ReadOnly = true;
            this.dgvAllPeopleData.RowHeadersWidth = 51;
            this.dgvAllPeopleData.RowTemplate.Height = 24;
            this.dgvAllPeopleData.Size = new System.Drawing.Size(1511, 394);
            this.dgvAllPeopleData.TabIndex = 1;
            // 
            // CmsPersonGrid
            // 
            this.CmsPersonGrid.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmsPersonGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CmsPersonGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.addNewPersonToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.sendEmailToolStripMenuItem,
            this.callToolStripMenuItem});
            this.CmsPersonGrid.Name = "CmsPersonGrid";
            this.CmsPersonGrid.Size = new System.Drawing.Size(211, 160);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.showDetailsToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.person_boy;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.addNewPersonToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.person_boy__1_;
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.addNewPersonToolStripMenuItem.Text = "Add New Person";
            this.addNewPersonToolStripMenuItem.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.editToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.person_boy__3_;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.deleteToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.person_boy__2_1;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.sendEmailToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.email;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            // 
            // callToolStripMenuItem
            // 
            this.callToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.callToolStripMenuItem.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.call;
            this.callToolStripMenuItem.Name = "callToolStripMenuItem";
            this.callToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.callToolStripMenuItem.Text = "Call";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(526, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manage People";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblRecordsCount.Location = new System.Drawing.Point(3, 722);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(195, 34);
            this.lblRecordsCount.TabIndex = 3;
            this.lblRecordsCount.Text = "All Records = ???";
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
            this.CbFilter.Location = new System.Drawing.Point(106, 264);
            this.CbFilter.Name = "CbFilter";
            this.CbFilter.ShadowDecoration.Parent = this.CbFilter;
            this.CbFilter.Size = new System.Drawing.Size(254, 36);
            this.CbFilter.TabIndex = 5;
            this.CbFilter.SelectedIndexChanged += new System.EventHandler(this.CbFilter_SelectedIndexChanged);
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
            this.txtFilterText.Location = new System.Drawing.Point(367, 264);
            this.txtFilterText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.PasswordChar = '\0';
            this.txtFilterText.PlaceholderText = "";
            this.txtFilterText.SelectedText = "";
            this.txtFilterText.ShadowDecoration.Parent = this.txtFilterText;
            this.txtFilterText.Size = new System.Drawing.Size(170, 36);
            this.txtFilterText.TabIndex = 6;
            this.txtFilterText.TextChanged += new System.EventHandler(this.txtFilterText_TextChanged);
            this.txtFilterText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterText_KeyPress);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter by :";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BorderColor = System.Drawing.Color.DimGray;
            this.btnAddNewPerson.BorderRadius = 10;
            this.btnAddNewPerson.BorderThickness = 2;
            this.btnAddNewPerson.CheckedState.Parent = this.btnAddNewPerson;
            this.btnAddNewPerson.CustomImages.Parent = this.btnAddNewPerson;
            this.btnAddNewPerson.FillColor = System.Drawing.Color.White;
            this.btnAddNewPerson.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewPerson.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewPerson.HoverState.Parent = this.btnAddNewPerson;
            this.btnAddNewPerson.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.person_boy__1_;
            this.btnAddNewPerson.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddNewPerson.Location = new System.Drawing.Point(1455, 259);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.ShadowDecoration.Parent = this.btnAddNewPerson;
            this.btnAddNewPerson.Size = new System.Drawing.Size(65, 57);
            this.btnAddNewPerson.TabIndex = 9;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD__PresentationLayer_WinForm.Properties.Resources.team;
            this.pictureBox1.Location = new System.Drawing.Point(526, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            this.BtnClose.Location = new System.Drawing.Point(1367, 722);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.ShadowDecoration.Parent = this.BtnClose;
            this.BtnClose.Size = new System.Drawing.Size(153, 45);
            this.BtnClose.TabIndex = 10;
            this.BtnClose.Text = "Close";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // frmShowAllPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1538, 774);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.txtFilterText);
            this.Controls.Add(this.CbFilter);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAllPeopleData);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowAllPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "People";
            this.Load += new System.EventHandler(this.frmShowAllPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeopleData)).EndInit();
            this.CmsPersonGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvAllPeopleData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordsCount;
        private Guna.UI2.WinForms.Guna2ComboBox CbFilter;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterText;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnAddNewPerson;
        private ContextMenuStrip CmsPersonGrid;
        private ToolStripMenuItem addNewPersonToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem sendEmailToolStripMenuItem;
        private ToolStripMenuItem callToolStripMenuItem;
        private ToolStripMenuItem showDetailsToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button BtnClose;
    }
}