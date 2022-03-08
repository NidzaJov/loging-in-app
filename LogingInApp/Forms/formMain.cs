using LogingInApp.Classes;
using LogingInApp.Controls;
using LogingInApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingInApp
{
    public partial class formMain : Form
    {
        private bool isEdit = false;
        private User editedUser = null;
        private AddressControl _address;

        public static string connectionString = ConfigurationManager.ConnectionStrings["localDb"].ConnectionString;
        public static SqlConnection connection = new SqlConnection(connectionString);
        private static SqlDataAdapter _dataAdapter = DataAdapters.EmployeeAdapter(connection);
        private DataSet employees;
        public formMain()
        {
            InitializeComponent();
            _address = addressControl1;
        }
        private void formMain_Load(object sender, EventArgs e)
        {
            User user = new User();
            var userList = user.GetUserList();
            populateList(userList);
            /*
            
            */
            populateGridView();
        }

        private void populateGridView()
        {
            gwEmployees.AutoGenerateColumns = true;
            gwEmployees.EditMode = DataGridViewEditMode.EditOnEnter;

            employees = new DataSet();
            try
            {
                _dataAdapter.Fill(employees, "Employee");
                gwEmployees.DataSource = employees.Tables["Employee"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during filling of data set", ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        private void UpdateGridView()
        {
            try
            {
                _dataAdapter.Update(employees, "Employee");
                populateGridView();
                MessageBox.Show("Sucessfull saving");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Aborted saving {ex.Message}");
            }
        }

        private void onColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listViewStudents.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void populateList(IList<User> studentList)
        {
            this.listViewStudents.ColumnClick += new ColumnClickEventHandler(onColumnClick);
            ColumnClickEventArgs eArgs = new ColumnClickEventArgs(0);
            onColumnClick(listViewStudents, eArgs);
            this.listViewStudents.MouseClick += listViewStudents_OnMouseClick;

            listViewStudents.View = View.Details;
            listViewStudents.Columns.Add("ID");
            listViewStudents.Columns.Add("Name");
            listViewStudents.Columns.Add("Email");
            listViewStudents.Columns.Add("Age");

            foreach (var student in studentList)
            {
                ListViewItem item = new ListViewItem(
                    new string[] { student.ID.ToString(), student.Name.ToString(), student.Email.ToString(), student.Age.ToString() }
                );
                listViewStudents.Items.Add(item);
            }

            listViewStudents.Sorting = System.Windows.Forms.SortOrder.Descending;
            listViewStudents.GridLines = true;
            listViewStudents.FullRowSelect = true;
        }

        private void populateForm(ListViewItem item)
        {
            User u = new User();
            txtName.Text = item.SubItems[1].Text;
            txtEmail.Text = item.SubItems[2].Text;
            txtID.Text = item.SubItems[0].Text;
            txtAge.Text = item.SubItems[3].Text;

            int id = int.Parse(item.SubItems[0].Text);
            var user = u.GetUser(id);
            user.Name = item.SubItems[1].Text;
            user.Email = item.SubItems[2].Text;
            user.Age = int.Parse(item.SubItems[3].Text);

            editedUser = user;
        }
        private void clearFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtAge.Text = "";
            txtID.Text = "";

            var txtStreetAddress = _address.Controls.Find("txtStreetAddress", true);
            if (txtStreetAddress != null)
            {
                TextBox tb = txtStreetAddress[0] as TextBox;
                tb.Clear();
            }

            var txtCity = _address.Controls.Find("txtCity", true);
            if (txtCity != null)
            {
                TextBox tb = txtCity[0] as TextBox;
                tb.Clear();
            }
            _address.City = "";

            var txtPostCode = _address.Controls.Find("txtPostCode", true);
            if (txtPostCode != null)
            {
                TextBox tb = txtPostCode[0] as TextBox;
                tb.Clear();
            }
            _address.CountryId = 1;
        }

        private void listViewStudents_OnMouseClick(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Right && listViewStudents.FocusedItem != null &&
                listViewStudents.FocusedItem.Bounds.Contains(e.Location))
            {
                ContextMenu m = new ContextMenu();
                MenuItem editMenuItem = new MenuItem("Edit");
                editMenuItem.Click += delegate (object sender2, EventArgs e2)
                {
                    EditClick(sender, e, listViewStudents.FocusedItem);
                };
                m.MenuItems.Add(editMenuItem);

                MenuItem editAddressItem = new MenuItem("Edit address");
                editAddressItem.Click += delegate (object sender3, EventArgs e3)
                {
                    EditAddressClick(sender, e, listViewStudents.FocusedItem);
                };
                m.MenuItems.Add(editAddressItem);

                MenuItem separatorMenuItem = new MenuItem("-");
                m.MenuItems.Add(separatorMenuItem);

                MenuItem deleteMenuItem = new MenuItem("Delete");
                deleteMenuItem.Click += delegate (object sender2, EventArgs e2)
                {
                    DeleteClick(sender, e, listViewStudents.FocusedItem);
                };
                m.MenuItems.Add(deleteMenuItem);

                m.Show(listViewStudents, new Point(e.X, e.Y));
            }
        }

        private void DeleteClick(Object sender, MouseEventArgs e, ListViewItem item)
        {
            int id = int.Parse(item.Text);
            User user = new User();
            bool isDeleted = user.DeleteUser(id);

            if (isDeleted)
            {
                this.Refresh();
                listViewStudents.Clear();
                populateList(user.GetUserList());
            } else
            {
                MessageBox.Show("Error deleting user");
            }
        }

        private void EditClick(object sender, MouseEventArgs e, ListViewItem item)
        {
            isEdit = true;
            populateForm(item);
        }

        private void EditAddressClick(object sender, MouseEventArgs e, ListViewItem focusedItem)
        {
            int id = int.Parse(focusedItem.Text);
            User user = new User();
            var u = user.GetUser(id);
            frmAddressEditor fm = new frmAddressEditor(u.AddressId);
            fm.Show();
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Address a = new Address();
            User u = new User();
            _address = this.addressControl1;
            _address.OnChildTextChanged += new EventHandler(child_OnChildTextChanged);

            if (isEdit && editedUser != null)
            {
                editedUser.Name = txtName.Text;
                editedUser.Email = txtEmail.Text;
                editedUser.Age = Int32.Parse(txtAge.Text);
                bool isSuccessfull = u.EditUser(editedUser.ID, editedUser);

                if(isSuccessfull)
                {
                    listViewStudents.Items.Clear();
                    this.populateList(u.GetUserList());
                    editedUser = null;
                    isEdit = false;
                    clearFields();
                }
            } else
            {
                string streetAddress = _address.StreetAddress;
                string city = _address.City;
                int postCode = _address.PostCode;
                int countryId = _address.CountryId;

                int addressId = a.SaveAddress(streetAddress, city, postCode, countryId);

                u.SaveUser(txtName.Text, txtEmail.Text, int.Parse(txtAge.Text), 0,  addressId);
                clearFields();
                listViewStudents.Items.Clear();
                this.populateList(u.GetUserList());
                /*
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
                */
            }
        }
        void child_OnChildTextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in gwEmployees.SelectedRows)
            {
                gwEmployees.Rows.RemoveAt(row.Index);
            }
        }
    }
}
