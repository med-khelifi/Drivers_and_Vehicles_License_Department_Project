using BVLD__BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void smPeople_Click(object sender, EventArgs e)
        {
            frmShowAllPeople frm = new frmShowAllPeople();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(clsBusinessAccessSettings.directoryPath))
            {
                Directory.CreateDirectory(clsBusinessAccessSettings.directoryPath); // Create directory if it doesn't exist
            }
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowAllUsers frm = new frmShowAllUsers();
            frm.ShowDialog();
        }
    }
}
