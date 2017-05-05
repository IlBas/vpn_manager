using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Configuration;
using System.Security.Principal;
using Security.RemoteSecurity;

namespace Security
{
 
    public partial class Login : Form
    {
        public  Login()
        {
            InitializeComponent();
            
        }
        string _Membership;
        public Login(string MemberOf)
        {

            InitializeComponent();
            _Membership = MemberOf;
        }

        private User _User;
        private void button1_Click(object sender, EventArgs e)
        {
            #region Old
            //string adPath = ConfigurationSettings.AppSettings["Server"].ToString();// "LDAP://elettric80.lan"; //Path to your LDAP directory server LDAP//srv-e80exclb "elettric80"
            //Security adAuth = new Security(adPath);
            //try
            //{
            //    _User = null;
            //    if (true == adAuth.IsAuthenticated(ConfigurationSettings.AppSettings["Domain"].ToString(),txtUser.Text, txtPassword.Text))
            //    {
            //        _User = new User();
            //        _User.user = txtUser.Text;
            //        _User.Membership = adAuth.GetGroups();
                   
            //    }
            //    else
            //    {
            //       // MessageBox.Show("User not Exist or Password Wrong!" , "Error" ,MessageBoxButtons.OK ,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
            //        //errorLabel.Text = "Authentication did not succeed. Check user name and password.";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //errorLabel.Text = "Error authenticating. " + ex.Message;
            //}
            //this.Close();
            #endregion
            CheckLogin();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Text = string.Format(this.Text, ConfigurationSettings.AppSettings["Domain"].ToString());
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        public User user
        {
            get { return _User; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void txtUser_Enter(object sender, System.EventArgs e)
        {
         //  GrayedText = textBox1.Text; // Stores old text value if you want
            txtUser.Text = ""; // Clears the text field
            txtUser.ForeColor = Color.Black;
            txtUser.ReadOnly = false; // Makes the field editable
        }

        private void txtPassword_Enter(object sender, System.EventArgs e)
        {
            //  GrayedText = textBox1.Text; // Stores old text value if you want
            txtPassword.Text = ""; // Clears the text field
            txtPassword.ForeColor = Color.Black;
            txtPassword.ReadOnly = false; // Makes the field editable
        }


        private void textBox1_Leave(object sender, System.EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Gray;
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }


        private void CheckLogin()
        {
            try
            {
                RemoteSecurity.ContractClient fl = new RemoteSecurity.ContractClient();
                fl.Open();
                OperationResult op = fl.LogIn(txtUser.Text, txtPassword.Text);
                if (op.User != string.Empty)
                {
                    _User = new User();
                    _User.user = txtUser.Text;
                    _User.Membership = op.Group;
                }
                else
                {
                    MessageBox.Show("User not Exist or Password Wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    //errorLabel.Text = "Authentication did not succeed. Check user name and password.";
                }
                fl.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Return))
            {
                CheckLogin();
            }
        }
      
    }

}
