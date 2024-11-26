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
    public partial class ucDriverLicenses : UserControl
    {
        public DataTable InternationalLicenseDate 
            { 
            set
            {
                dgvInternationalLicenses.DataSource = value;
                lblAllInternationalLSRecords.Text = "Al Records = " + value.Rows.Count;
            } 
        }
        public DataTable LocalLicenseDate
        {
            set
            {
                dgvLocalLicenses.DataSource = value;    
                lblAllLocalDrivingRecords.Text = "Al Records = " + value.Rows.Count;
            }
        }
        public ucDriverLicenses()
        {
            InitializeComponent();
        }
    }
}
