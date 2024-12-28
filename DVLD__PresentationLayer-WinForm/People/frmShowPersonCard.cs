using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm.People
{
    public partial class frmShowPersonCard : Form
    {
        public frmShowPersonCard(int PersonID)
        {
            InitializeComponent();
            personDetailsControl1.LoadPersonInfo(PersonID);

        }
        public frmShowPersonCard(string NationalNo)
        {
            InitializeComponent();
            personDetailsControl1.LoadPersonInfo(NationalNo);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
