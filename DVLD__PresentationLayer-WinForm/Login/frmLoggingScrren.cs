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
    public partial class frmLoggingScrren : Form
    {
      
        public frmLoggingScrren()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text)) 
            {
                MessageBox.Show("Fill All Login Information.");
            }
            else
            {
                if((clsGlobal.CurrentUser = clsUser.LogIn(txtUserName.Text.Trim(),txtPassword.Text.Trim())) == null)
                {
                    MessageBox.Show("Invalid UserName/Password.","Ivalid Informations",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    if (!clsGlobal.CurrentUser.isActive)
                    {
                        MessageBox.Show("Your Account Is Deactivated,Please Contact Your Admins.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    frmMainScreen frm = new frmMainScreen();
                    frm.ShowDialog();
                    if (chkRememberme.Checked)
                    {
                        File.WriteAllLines(clsBusinessAccessSettings.rememberMeFile, new[] { txtUserName.Text, txtPassword.Text });
                    }
                    else
                    {
                        txtPassword.Text = "";
                        txtUserName.Text = "";
                        File.WriteAllLines(clsBusinessAccessSettings.rememberMeFile, new[] { "","" });
                    }
                }
            }
        }

        private void frmLoggingScrren_Load(object sender, EventArgs e)
        {
            if (!File.Exists(clsBusinessAccessSettings.rememberMeFile))
            {
                File.Create(clsBusinessAccessSettings.rememberMeFile).Close(); // Close to release the file handle
                return;
            }

            string[] lines = File.ReadAllLines(clsBusinessAccessSettings.rememberMeFile);
            if (lines.Length >= 2)
            {
                txtUserName.Text = lines[0];
                txtPassword.Text = lines[1];
                chkRememberme.Checked = true;
            }
            else
            {
                chkRememberme.Checked = false;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
