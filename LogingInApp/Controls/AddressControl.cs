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

namespace LogingInApp.Controls
{
    public partial class AddressControl : UserControl
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public int PostCode { get; set; }
        private bool nonNumber = false;

        public event EventHandler OnChildTextChanged;

        public AddressControl()
        {
            InitializeComponent();
        }

        private void AddressControl_Load(object sender, EventArgs e)
        {
            Country c = new Country();
            var countries = c.GetCountries();
            ddlCountry.DataSource = countries;
            ddlCountry.DisplayMember = "Name";
            ddlCountry.ValueMember = "ID";
        }

        public void Populate(int addressId)
        {
            Address a = new Address();
            var address = a.GetAddress(addressId);
            if (address != null)
            {
                txtStreetAddress.Text = address.StreetAddress;
                txtCity.Text = address.City;
                txtPostCode.Text = address.PostCode.ToString();
                ddlCountry.SelectedValue = address.ID;
            }
            else
            {
                MessageBox.Show("This address does not exist");
            }

        }

        private void txtPostCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumber == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtPostCode_MouseLeave(object sender, EventArgs e)
        {
            if (txtPostCode.Text != "")
            {
                this.PostCode = int.Parse(txtPostCode.Text);
            }
        }

        private void txtPostCode_TextChanged(object sender, EventArgs e)
        {
            if (OnChildTextChanged != null)
                OnChildTextChanged(txtPostCode.Text, null);
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            this.City = txtCity.Text;
            if (OnChildTextChanged != null)
                OnChildTextChanged(txtCity.Text, null);
        }

        private void txtStreetAddress_TextChanged(object sender, EventArgs e)
        {
            this.StreetAddress = txtStreetAddress.Text;
            if (OnChildTextChanged != null)
                OnChildTextChanged(txtStreetAddress.Text, null);
        }

        private void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender; // ddlCountry
            var selectedItem = combo.SelectedItem as Country;
            this.CountryId = selectedItem.ID;
        }
    }
}
