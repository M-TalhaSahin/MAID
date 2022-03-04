using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAID
{
    public partial class SignUp : Form
    {
        private dataBase dbconnection = new dataBase();
        public SignUp()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtRepeat.PasswordChar = '*';
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (dbconnection.usernameSearch(txtUsername.Text) != 0)
            {
                MessageBox.Show("Username is taken.", "ERROR");
                txtUsername.Clear();
                txtUsername.Focus();
            }
               
            else if(txtName.Text == "" || txtPassword.Text == "" || txtRepeat.Text == "" || txtSurname.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Please fill all properties.", "ERROR");
            }
            else if(txtPassword.Text != txtRepeat.Text)
            {
                MessageBox.Show("Passwords must be the same.", "ERROR");
            }
            else if(txtPassword.Text == txtRepeat.Text)
            {
                dbconnection.insertUser(txtName.Text, txtSurname.Text, txtUsername.Text, txtPassword.Text);
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            }


        }

        private void txtRepeat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_Click(sender, e);
        }
    }
}
