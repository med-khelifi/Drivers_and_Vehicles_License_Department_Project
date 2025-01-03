using BVLD__BusinessLayer;
using ContactBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID = -1;

        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();


        }

        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ucPersondetailsWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
            {
                ucDriverLicenses1.Clear();
            }
            else
                ucDriverLicenses1.LoadInfoByPersonID(_PersonID);
        }

        private void frmShowPersonLicenseHistory_Load_1(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ucPersondetailsWithFilter1.LoadPersonInfo(_PersonID);
                ucPersondetailsWithFilter1.FilterEnabled = false;
                ucDriverLicenses1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ucPersondetailsWithFilter1.Enabled = true;
                ucPersondetailsWithFilter1.FilterFocus();
            }
        }
    }
}
