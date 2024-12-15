using BVLD__BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmEditApplicationType : Form
    {
        public delegate void FormClosedDelegate();
        public FormClosedDelegate FormClosedDelegation;

        int ApplicationID = -1;
        public frmEditApplicationType(int applicationID)
        {
            InitializeComponent();
            ApplicationID = applicationID;
        }
        float fees = 0;
        bool isValidFees = true;
        bool isValidTitle = true;
        clsApplicationType _Application = null;
        private void BtnClose_Click(object sender, EventArgs e)
        {
            //FormClosedDelegation?.Invoke();
            Close();
        }

        private bool _AreValidInputs()
        {
            return isValidFees && isValidTitle;
        }
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) 
            { 
                e.Handled = true;
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (!float.TryParse(txtFees.Text,out fees))
            {
                errorProvider1.SetError(txtFees, "Invalid Value.");
                e.Cancel = true;
                isValidFees = false;
            }
            else
            {
                isValidFees = true;
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                errorProvider1.SetError(txtTitle, "Invalid Value.");
                e.Cancel = true;
                isValidTitle = false;
            }
            else
            {
                isValidTitle = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_AreValidInputs()) 
            { 
                _Application.ApplicationFees = Convert.ToSingle(txtFees.Text);
                _Application.ApplicationTypeTitle = txtTitle.Text;

                if (_Application.Save())
                {
                    MessageBox.Show("َApplication Type Edited.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("َError .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void _LoadData()
        {
            _Application = clsApplicationType.Find(ApplicationID);
            
            lblID.Text = _Application.ApplicationTypeID.ToString();
            txtTitle.Text = _Application.ApplicationTypeTitle;
            txtFees.Text = _Application.ApplicationFees.ToString();
        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void frmEditApplicationType_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosedDelegation?.Invoke();
        }
    }
}
