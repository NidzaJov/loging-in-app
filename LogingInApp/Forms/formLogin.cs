using LogingInApp.Classes;
using LogingInApp.Forms;
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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
            
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void FormLogin_OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (textUserName.Text == "" || textPassword.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }

            try
            {
                if (textUserName.Text != "" && textPassword.Text != "")
                {
                    User user = new User();
                    User searchedUser = user.GetUserList(textUserName.Text).FirstOrDefault();
                    if (searchedUser != null)
                    {
                        Role role = new Role();
                        Role usersRole = role.GetRole(searchedUser.RoleId);
                        if(usersRole != null)
                        {
                            switch (usersRole.Name)
                            {
                                case "Admin":
                                    {
                                        Form fa = new AdminForm();
                                        this.Hide();
                                        fa.Show();
                                        break;
                                    }
                                default:
                                    {
                                        formMain fm = new formMain();
                                        fm.Show();
                                        break;
                                    }
                            }
                                
                        }
                    }
                } 
                else
                {
                    MessageBox.Show("Login Failed");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
