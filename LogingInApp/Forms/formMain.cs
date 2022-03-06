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

namespace LogingInApp
{
    public partial class formMain : Form
    {
        private AddressControl _address;
        public formMain()
        {
            InitializeComponent();
            _address = ctlAddress;
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            User user = new User();
            var userList = user.GetUserList();
            populateList(userList);
            this.listViewStudents.ColumnClick += new ColumnClickEventHandler(onColumnClick);

            ColumnClickEventArgs eArgs = new ColumnClickEventArgs(0);
            onColumnClick(listViewStudents, eArgs);
        }

        private void onColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listViewStudents.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void populateList(IList<User> studentList)
        {
            listViewStudents.View = View.Details;

            listViewStudents.Columns.Add("ID");
            listViewStudents.Columns.Add("Name");
            listViewStudents.Columns.Add("Age");

            foreach (var student in studentList)
            {
                ListViewItem item = new ListViewItem(
                    new string[] { student.ID.ToString(), student.Name.ToString(), student.Age.ToString() }
                );
                listViewStudents.Items.Add(item);
            }

            listViewStudents.Sorting = SortOrder.Descending;
            listViewStudents.GridLines = true;
            listViewStudents.FullRowSelect = true;
        }

        private class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }

            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                int nr = 0;
                bool isNumber = int.TryParse(((ListViewItem)x).SubItems[col].Text, out nr);

                if (!isNumber)
                {
                    return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                }
                else
                {
                    int firstNumber = int.Parse(((ListViewItem)x).SubItems[col].Text);
                    int secondNumber = int.Parse(((ListViewItem)x).SubItems[col].Text);

                    return firstNumber.CompareTo(secondNumber);
                }
                
            }
        }

        private void formMain_OnClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            formLogin fl = new formLogin();
            fl.Show();
        }

        private void listViewStudents_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            MessageBox.Show($"This is ID: {_address.CountryId}");
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Address a = new Address();
            User u = new User();
            string streetAddress = ctlAddress.StreetAddress;
            string city = ctlAddress.City;
            int postCode = ctlAddress.PostCode;
            int countryId = ctlAddress.CountryId;

            int addressId = a.SaveAddress(streetAddress, city, postCode, countryId);

            u.SaveUser("Moca", "moca@sedc.com", 29, 0, addressId);
            _address.StreetAddress = "";
            _address.City = "";
            var txtPostcode = _address.Controls.Find("txtPostalCode", true);
            if (txtPostcode != null)
            {
                TextBox tb = txtPostcode[0] as TextBox;
                tb.Clear();
            }
            _address.CountryId = 1;

            listViewStudents.Clear();
            this.populateList(u.GetUserList());
 

            int[] students = new int[listViewStudents.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in listViewStudents.SelectedItems)
            {
                var id = item.Text;
                var name = item.SubItems[1].Text;
                var age = item.SubItems[2].Text;
                students[i] = int.Parse(id);
                i++;
            }
        }
    }
}
