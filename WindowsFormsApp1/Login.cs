using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;

        public Login()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;
        }

        private void log_in_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Username or password field is empty, type in a valid value.");
            }
            else
            {
                connection.Open();
                string selectQuery = "SELECT * FROM loginform.userinfo WHERE Username = '" + username.Text + "' AND Password = '" + password.Text + "';";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";
                    string Query = "update loginform.userinfo set LastLogin='" + "' where Username='" + this.password.Text + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    { 
                    }
                    MyConn2.Close();
                    MessageBox.Show("Login Successful!");
                    this.Hide();

                    // now get data about user, access level and chose the next form accordingly

                    // by default, the users arent given administrator powers
                    // admins can make new admins, delete, update, create

                    // regular acconts can only read
                }
                else
                {
                    MessageBox.Show("Login information is incorrect. Try again.");
                }
                connection.Close();
            }
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            register_form register_form = new register_form();
            register_form.ShowDialog();
        }

        private void show_password_MouseEnter(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = false;
        }

        private void show_password_MouseLeave(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = true;
        }
    }
}