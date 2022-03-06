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
    public partial class AddressControl : UserControl
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public int PostCode { get; set; }
        private bool nonNumber = false;

        public AddressControl()
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


        private void dropDownCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            var selectedItem = combo.SelectedItem as Country;
            this.CountryId = selectedItem.ID;
        }

        private void txtPostalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumber)
            {
                e.Handled = true;
            }
        }

        private void txtPostalCode_MouseLeave(object sender, EventArgs e)
        {
            if (txtPostalCode.Text != "")
            {
                this.PostCode = int.Parse(txtPostalCode.Text);
            }
        }

        private void txtPostalCode_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumber = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    nonNumber = true;
                }
            }
            
        }
    }
}
