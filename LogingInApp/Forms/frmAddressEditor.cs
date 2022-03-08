using LogingInApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingInApp.Forms
{
    public partial class frmAddressEditor : Form
    {
        private int _addressId;
        public frmAddressEditor()
        {
            InitializeComponent();
        }

        public frmAddressEditor(int addressId)
        {
            InitializeComponent();
            populateValues(addressId);
            _addressId = addressId;
        }

        private void populateValues(int addressId)
        {
            ctlAddress.Populate(addressId);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Address a = new Address();
            Address editedAddress = new Address();

            User u = new User();
            // save edited address
            var txtStreetAddress = ctlAddress.Controls.Find("txtStreetAddress", true);
            if (txtStreetAddress != null)
            {
                TextBox tb = txtStreetAddress[0] as TextBox;
                editedAddress.StreetAddress = tb.Text;
            }

            var txtCity = ctlAddress.Controls.Find("txtCity", true);
            if (txtCity != null)
            {
                TextBox tb = txtCity[0] as TextBox;
                editedAddress.City = tb.Text;
            }

            var txtPostCode = ctlAddress.Controls.Find("txtPostCode", true);
            if (txtPostCode != null)
            {
                TextBox tb = txtPostCode[0] as TextBox;
                editedAddress.PostCode = int.Parse(tb.Text);
            }
            var ddlCountry = ctlAddress.Controls.Find("ddlCountry", true);
            if ( ddlCountry != null)
            {
                ComboBox cb = ddlCountry[0] as ComboBox;
                editedAddress.CountryId = cb.SelectedIndex;
            }
            editedAddress.ID = _addressId;

            bool isSuccessfull = a.EditAddress(_addressId, editedAddress);

            if (isSuccessfull)
            {
                this.Hide();

            }
            // or save new address and update user.AddressId
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmAddressEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
