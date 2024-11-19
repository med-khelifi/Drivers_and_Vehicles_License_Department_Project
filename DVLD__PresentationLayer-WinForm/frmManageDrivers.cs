using BVLD__BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmManageDrivers : Form
    {
        DataView DataViewDrivers;
        public frmManageDrivers()
        {
            InitializeComponent();
        }
        private void _LoadData()
        {

            DataViewDrivers = clsDriver.GetAllDriversTable().DefaultView;
            dgvDrivers.DataSource = DataViewDrivers;
            lblRecordsCount.Text = "All Records = " + dgvDrivers.Rows.Count;
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _LoadData();
            CbFilter.SelectedIndex = 0;
        }
        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CbFilter.SelectedIndex == 1 || CbFilter.SelectedIndex == 2) 
            {
                if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
        }
        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CbFilter.SelectedIndex == 0)
            {
                txtFilterText.Visible = false;
            }
            else
            {
                txtFilterText.Visible=true;
            }
            txtFilterText.Text = "";
        }
        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterText.Text == string.Empty)
            {
                DataViewDrivers.RowFilter = "";
            }
            else
            {
                DataViewDrivers.RowFilter = _GetFilterString(txtFilterText.Text);
            }
        }

        private string _GetFilterString(string filter)
        {
            Dictionary<int, string> FilterString = new Dictionary<int, string>()
            {
                {0,string.Empty},
                {1,$"DriverID = {filter}"},
                {2,$"PersonID = {filter}"},
                {3,$"NationalNo LIKE '{filter}%'"},
                {4,$"FullName LIKE '{filter}%'"}
         
            };
            return FilterString[CbFilter.SelectedIndex];
        }
    }
}
