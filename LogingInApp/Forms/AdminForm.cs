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
    public partial class AdminForm : Form
    {
        private User editedUser;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            User user = new User();
            var userList = user.GetUserList();
            populateList(userList);
            Role role = new Role();
            role.GetAllRoles();
            comboBoxRoles.DataSource = role.AllRoles;
            comboBoxRoles.DisplayMember = "Name";
            comboBoxRoles.ValueMember = "ID";
            listViewUsers.Select();
            comboBoxRoles.SelectedValue = "0";

        }

        private void populateList(IList<User> userList)
        {
            listViewUsers.View = View.Details;
            listViewUsers.Columns.Add("ID");
            listViewUsers.Columns.Add("Name");
            listViewUsers.Columns.Add("RoleId");

            foreach (var user in userList)
            {
                ListViewItem item = new ListViewItem(
                    new string[] { user.ID.ToString(), user.Name.ToString(), user.RoleId.ToString() });
                listViewUsers.Items.Add(item);
                listViewUsers.Sorting = System.Windows.Forms.SortOrder.Descending;
                listViewUsers.GridLines = true;
                listViewUsers.FullRowSelect = true;
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void listViewUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listViewUsers.FocusedItem != null && listViewUsers.FocusedItem.Bounds.Contains(e.Location))
            {
                
                MenuItem item = new MenuItem("Change role");
                item.Click += delegate (object sender1, EventArgs e1)
                {
                    ChangeRoleClick(sender, e, listViewUsers.FocusedItem);
                };
                ContextMenu contextMenu = new ContextMenu();
                listViewUsers.ContextMenu = contextMenu;
                contextMenu.MenuItems.Add(item);
                contextMenu.Show(listViewUsers ,new Point(e.X, e.Y));

            }
        }

        private void ChangeRoleClick(object sender, MouseEventArgs e, ListViewItem focusedItem)
        {
            comboBoxRoles.Visible = true;
            
            User user = new User();
            int id = int.Parse(focusedItem.Text);
            editedUser = user.GetUser(id);
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            Role selectedRole = combo.SelectedItem as Role;
            if (editedUser != null)
            {
                editedUser.RoleId = selectedRole.ID;
                User user = new User();
                bool successfull = user.EditUser(editedUser.ID, editedUser);
                if (successfull)
                {
                    this.Refresh();
                    listViewUsers.Items.Clear();
                    user.GetUserList();
                    populateList(user.AllUsers);
                }
                
            }
            
        }
    }
}
