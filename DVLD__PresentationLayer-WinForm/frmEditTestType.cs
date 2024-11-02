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
    public partial class frmEditTestType : Form
    {
        int TesttypeID = 0;
        clsTestType _testType = null;
        bool isValidTitle = true;
        bool isValidDescription = true; 
        bool isValidFees = true;
  
        public delegate void OnFormClosedDelegate();
        public OnFormClosedDelegate OnFormCloseDelegate;
        public frmEditTestType(int testTypeID)
        {
            InitializeComponent();
            this.TesttypeID = testTypeID;
        }

        private void _LoadData()
        {
            _testType = clsTestType.Find(TesttypeID);
            if (_testType != null) 
            { 
                lblID.Text = _testType.TestTypeID.ToString();
                txtDescription.Text = _testType.TestTypeDescription;
                txtTitle.Text = _testType.TestTypeTitle;
                txtFees.Text = _testType.TestTypeFees.ToString();
            }
            else
            {
                MessageBox.Show("Error,Object is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool _AreValideInputs()
        {
            return isValidDescription && isValidTitle && isValidFees;
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void frmEditTestType_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnFormCloseDelegate?.Invoke();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_AreValideInputs()) 
            { 
                _testType.TestTypeFees = Convert.ToSingle(txtFees.Text);    
                _testType.TestTypeTitle = txtTitle.Text.Trim();
                _testType.TestTypeDescription = txtDescription.Text.Trim();

                if (_testType.Save())
                {
                    MessageBox.Show("Test Type Edited Successfully.","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Was Happend please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            if (!float.TryParse(txtFees.Text, out float fees))
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

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.SetError(txtDescription, "Invalid Value.");
                e.Cancel = true;
                isValidDescription = false;
            }
            else
            {
                isValidDescription = true;
            }
        }

        //private void txtTitle_Validating(object sender, CancelEventArgs e)
        //{
        //    errorProvider1.Clear();
        //    if (string.IsNullOrEmpty(txtTitle.Text))
        //    {
        //        errorProvider1.SetError(txtTitle, "Invalid Value.");
        //        e.Cancel = true;
        //        isValidTitle = false;
        //    }
        //    else
        //    {
        //        isValidTitle = true;
        //    }
        //}
    }
}
