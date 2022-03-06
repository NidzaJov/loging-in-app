using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingInApp
{
    public partial class Address : UserControl
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public int PostCode { get; set; }
        public Address()
        {
            InitializeComponent();
        }

        private void Address_Load(object sender, EventArgs e)
        {
            Country c = new Country();
            var countries = c.GetCountries();
            dropDownCountry.DataSource = countries;
            dropDownCountry.DisplayMember = "Name";
            dropDownCountry.ValueMember = "ID";
        }

        private void txtStreetAddress_TextChanged(object sender, EventArgs e)
        {
            this.StreetAddress = txtStreetAddress.Text;
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            this.City = txtCity.Text;
        }

        private void txtPostalCode_TextChanged(object sender, EventArgs e)
        {
            this.PostCode = int.Parse(txtPostalCode.Text);
        }

        private void dropDownCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            var selectedItem = combo.SelectedItem as Country;
            this.CountryId = selectedItem.ID;
        }
    }
}
