using BVLD__BusinessLayer;
using ContactBusinessLayer;
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
    public partial class frmShowPersonDetails : Form
    {
        public delegate void EditPersonFormClosedEventhandler();
        public event EditPersonFormClosedEventhandler FormClosedEvent;

        bool isPersonEdited = false;
        int PersonID = -1;
        public frmShowPersonDetails(int personID)
        {
            InitializeComponent();
            PersonID = personID;
        }

        public void frmPersonDetails_Load(object sender, EventArgs e)
        {
            clsPerson Person = clsPerson.Find(PersonID);
            

            if (Person != null)
            {
                p1.PersonID = $"#{Person.PersonId}";
                p1.FullName = $"{Person.FirstName} {Person.SecondName} {Person.ThirdName} {Person.LastName}";
                p1.NationalNo = Person.NationalNo;
                p1.Gender = (Person.Gender == 0 ? "Male" : "Female");
                p1.Address = Person.Address;
                p1.Email = Person.Email;
                p1.DateOfBirth = Person.DateOfBirth;
                p1.Phone = Person.Phone;
                p1.ImagePath = Person.ImagePath;

                clsCountry Country = clsCountry.Find(Person.NationalityCountryID);
                if (Country != null)
                {
                    p1.Country = Country.CountryName;
                }
                else
                {
                    p1.Country = "_____";
                }
            }

            p1.EditPersonDetailsEventFired += EditPersonDetailsEventFired;
        }

        private void EditPersonDetailsEventFired(object sender, EventArgs e)
        {
            frmEditAddPerson frm = new frmEditAddPerson(PersonID);
            frm.ShowDialog();
            frmPersonDetails_Load(sender, e);
            isPersonEdited = true;
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            if (isPersonEdited)
            {
                FormClosedEvent?.Invoke();
            }
            Close();

        }
    }
}
