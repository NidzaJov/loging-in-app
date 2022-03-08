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
        public frmAddressEditor()
        {
            InitializeComponent();
        }

        public frmAddressEditor(int addressId)
        {
            InitializeComponent();
            populateValues(addressId);
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
