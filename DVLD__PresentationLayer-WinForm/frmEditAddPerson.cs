using BVLD__BusinessLayer;
using ContactBusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD__PresentationLayer_WinForm
{
    public partial class frmEditAddPerson : Form
    {
        public delegate void Databack(int PersonID=-1);
        public event Databack OnDataback;
        enum enMode { AddNew, Update }
        enMode Mode;

        int PersonID;
        clsPerson Person;

        private bool isValidName, isValidThirdname, isValidNationalNo, isValidAddress, isValidEmail, isValidPhone;

        string oldPath = "";
        string SelectedPath = "";
        Image DefaultImage = Properties.Resources.Person;
        public frmEditAddPerson(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
            if (PersonID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
        }
        private void frmEditAddPerson_Load(object sender, EventArgs e)
        {
            cbCountries.DataSource = clsCountry.GetAllCountriesNameList();
            _LoadData();
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }
        private Image _SetDefaultImage()
        {
            if (rbMale.Checked)
            {
                DefaultImage = Properties.Resources.Person; // Male default image
            }
            else if (rbFemale.Checked)
            {
                DefaultImage = Properties.Resources.person_girl; // Female default image
            }
            else
            {
                DefaultImage = Properties.Resources.Person; // Default person image (if exists)
            }

            return DefaultImage;
        }
        private void _LoadData()
        {
            if (Mode == enMode.AddNew)
            {
                lblCaption.Text = "Add New Person";
                Person = new clsPerson();
                llblremovePic.Visible = false;

                isValidEmail = true;
                isValidThirdname = true;
                return;
            }

            Person = clsPerson.Find(PersonID);
            if (Person == null)
            {
                MessageBox.Show("Person Not Found. App Will Close.");
                Close();
                return;
            }
            isValidName = true;
            isValidThirdname = true;
            isValidNationalNo = true;
            isValidAddress = true;
            isValidEmail = true;
            isValidPhone = true;

            lblCaption.Text = "Edit Person Info";
            lblID.Text = Person.PersonId.ToString();
            txtFirstName.Text = Person.FirstName;
            txtLastName.Text = Person.LastName;
            txtSecondName.Text = Person.SecondName;
            txtThirdName.Text = Person.ThirdName;
            txtNationalNo.Text = Person.NationalNo;
            dtpDateOfBirth.Value = Person.DateOfBirth;
            rbMale.Checked = (Person.Gender == 0);
            rbFemale.Checked = (Person.Gender == 1);
            txtPhone.Text = Person.Phone;
            cbCountries.SelectedIndex = Person.NationalityCountryID - 1;
            txtEmail.Text = Person.Email;
            txtAddress.Text = Person.Address;

            llblremovePic.Visible = !string.IsNullOrEmpty(Person.ImagePath);

           
            if (!string.IsNullOrEmpty(Person.ImagePath) /*&& File.Exists(Person.ImagePath)*/)
            {
                pbPersonPicture.Image = _LoadImageWithoutLocking(Person.ImagePath);
            }
            else
            {
                pbPersonPicture.Image = _SetDefaultImage();
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            OnDataback?.Invoke(Person.PersonId);
            Close();
            
        }
        private static Image _LoadImageWithoutLocking(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(stream); // Return a copy of the image
            }
        }
        private string _GetPicturePath()
        {
            // If an image was selected and it's not the default one
            if (!string.IsNullOrEmpty(SelectedPath))
            {
                string extension = Path.GetExtension(SelectedPath);
                string newPath = Path.Combine(clsBusinessAccessSettings.directoryPath, Guid.NewGuid().ToString() + extension);

                try
                {
                    // Check if the file exists at the selected path
                    if (File.Exists(SelectedPath))
                    {
                        File.Copy(SelectedPath, newPath); // Overwrite if necessary
                        return newPath;
                    }
                    else
                    {
                        MessageBox.Show("Selected image file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }
            else if (pbPersonPicture.Image != DefaultImage)
            {
                // If image is manually loaded from the file but no new path was selected
                return Person.ImagePath; // Return existing path
            }
            else
            {
                return ""; // No image selected or set
            }
        }      
        private void _DeleteOldPic()
        {
            if (!string.IsNullOrEmpty(oldPath) && File.Exists(oldPath))
            {
                try
                {
                    //Release the image if it's in use
                    //if (pbPersonPicture.Image != null)
                    //{
                    //    pbPersonPicture.Image.Dispose();
                    //}

                    File.Delete(oldPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    oldPath = string.Empty;
                }
            }
        }
        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (_AreValidInputs())
            {
                Person.FirstName = txtFirstName.Text;
                Person.LastName = txtLastName.Text;
                Person.SecondName = txtSecondName.Text;
                Person.ThirdName = txtThirdName.Text;
                Person.NationalNo = txtNationalNo.Text;
                Person.DateOfBirth = dtpDateOfBirth.Value;
                Person.Gender = rbMale.Checked ? 0 : 1;
                Person.Phone = txtPhone.Text;
                Person.NationalityCountryID = cbCountries.SelectedIndex + 1;
                Person.Email = txtEmail.Text;
                Person.Address = txtAddress.Text;
                Person.ImagePath = _GetPicturePath();

                if (Person.Save())
                {
                   
                    _DeleteOldPic();
                    MessageBox.Show("Person Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblID.Text = Person.PersonId.ToString();
                }
                else
                {
                    MessageBox.Show("Saving Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields To Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llblSetPic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                oldPath = Person.ImagePath;

                DefaultImage = null;
                SelectedPath = selectedFilePath;
                llblremovePic.Visible = true;
                pbPersonPicture.Image = _LoadImageWithoutLocking(SelectedPath);
            }
        }
        private void llblRemovePic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DefaultImage = _SetDefaultImage();
            oldPath = Person.ImagePath;

            pbPersonPicture.Image = null;// Clear PictureBox to unlock file
            
            pbPersonPicture.Image = DefaultImage;
            llblremovePic.Visible = false;
            SelectedPath = "";
        }
        private void frmEditAddPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnDataback?.Invoke(Person.PersonId);
        }
        private void CheckNameValidateName(object sender, CancelEventArgs e)
        {
            if (sender is Guna2TextBox textBoxValidate)
            {
                errorProvider1.Clear();
                string name = textBoxValidate.Text;

                string pattern = @"^[a-zA-Z\s\-]+$"; // Allow letters, spaces, and hyphens

                if (!Regex.IsMatch(name, pattern))
                {
                    errorProvider1.SetError(textBoxValidate, "Invalid Input! Only letters, spaces, and hyphens are allowed.");
                    e.Cancel = true;
                    isValidName = false;
                }
                else
                {
                    isValidName = true;
                }
            }
        }
        private void txtThirdName_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            string pattern = @"^[a-zA-Z\s\-]+$"; // Allow letters, spaces, and hyphens

            if (!string.IsNullOrEmpty(txtThirdName.Text))
            {
                if (!Regex.IsMatch(txtThirdName.Text, pattern))
                {
                    errorProvider1.SetError(txtThirdName, "Invalid Input! Only letters, spaces, and hyphens are allowed.");
                    e.Cancel = true;
                    isValidThirdname = false;
                }
                else
                {
                    isValidThirdname = true;
                }
            }
            else
            {
                isValidThirdname = true; // Allow empty third name
            }
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            string pattern = @"^[0-9]+$"; // Allow only numbers

            if (!Regex.IsMatch(txtPhone.Text, pattern))
            {
                errorProvider1.SetError(txtPhone, "Invalid Phone Number! Only numbers are allowed.");
                e.Cancel = true;
                isValidPhone = false;
            }
            else
            {
                isValidPhone = true;
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Basic email validation pattern

                if (!Regex.IsMatch(txtEmail.Text, pattern))
                {
                    errorProvider1.SetError(txtEmail, "Invalid Email! Please enter a valid email address.");
                    e.Cancel = true;
                    isValidEmail = false;
                }
                else
                {
                    isValidEmail = true;
                }
            }
            else
            {
                isValidEmail = true; // Allow empty email field
            }
        }
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "Address cannot be empty!");
                e.Cancel = true;
                isValidAddress = false;
            }
            else
            {
                isValidAddress = true;
            }
        }
        private void rbMale_Click(object sender, EventArgs e)
        {
            if (IsDefaultImage())
                pbPersonPicture.Image= _SetDefaultImage();
        }
        private bool _AreValidInputs()
        {
            return isValidName && isValidThirdname && isValidNationalNo && isValidAddress && isValidEmail && isValidPhone;
        }
        private bool itsOnlyCharsAndDigits(string Text)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return false; // Invalid input if empty
            }

            foreach (char c in Text)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (!itsOnlyCharsAndDigits(txtNationalNo.Text))
            {
                isValidNationalNo = false;
                errorProvider1.SetError(txtNationalNo, "Invalid National No! Only letters and digits are allowed.");
                e.Cancel = true;
            }
            if (clsPerson.isPersonExist(txtNationalNo.Text) && txtNationalNo.Text.Trim() != Person.NationalNo)
            {
                isValidNationalNo = false;
                errorProvider1.SetError(txtNationalNo, "Invalid National No! NationalNo is allready exist.");
                e.Cancel = true;
            }
            else
            {
                isValidNationalNo = true;
            }
        }

        private bool ImagesAreEqual(Image img1, Image img2)
        {
            if (img1 == null || img2 == null)
                return false;

            var bmp1 = new Bitmap(img1);
            var bmp2 = new Bitmap(img2);

            if (bmp1.Size != bmp2.Size)
                return false;

            for (int x = 0; x < bmp1.Width; x++)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Check if the current image is not a default image
        private bool IsDefaultImage()
        {
            return (ImagesAreEqual(pbPersonPicture.Image, Properties.Resources.Person) ||
                     ImagesAreEqual(pbPersonPicture.Image, Properties.Resources.person_girl));
        }

    }
}
