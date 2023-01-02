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
    public partial class register_form : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        public register_form()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;
            confirm_password.UseSystemPasswordChar = true;
        }

        private void register_form_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void return_to_login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm4 = new Login();
            frm4.ShowDialog();
        }

        private void register_Click(object sender, EventArgs e)
        {
            if (password.Text != confirm_password.Text)
            {
                MessageBox.Show("Password doesn't match! Try Again.");
                return;
            }
            if (string.IsNullOrEmpty(password.Text) || string.IsNullOrEmpty(confirm_password.Text) || string.IsNullOrEmpty(username.Text))
            {
                MessageBox.Show("Please fill out all information!");
                return;
            }
            if (password.Text.Contains("'") || password.Text.Contains(" "))
            {
                MessageBox.Show("Password cannot contain spaces or single quotation marks!", "Try Again.");
                return;
            }
            else
            {
                connection.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM loginform.userinfo WHERE Username = @UserName", connection),
                cmd2 = new MySqlCommand("SELECT * FROM loginform.userinfo WHERE Email = @UserEmail", connection);
                cmd1.Parameters.AddWithValue("@Username", username.Text);
                bool userExists = false;
                using (var dr1 = cmd1.ExecuteReader())
                    if (userExists = dr1.HasRows) MessageBox.Show("Username not available!");
                if (!(userExists))
                {
                    DateTimePicker dateTimePicker1 = new DateTimePicker();
                    string iquery = "INSERT INTO loginform.userinfo(`ID`, `Type`, `Username`, `Password`) VALUES (NULL, '" + "Regular" + "', '" + username.Text + "', '" + password.Text + "')";
                    MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                    commandDatabase.CommandTimeout = 60;
                    try
                    {
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                    MessageBox.Show("Account Successfully Registered!");
                } 
                connection.Close();
            }
        }

        private void show_MouseEnter(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = false;
            confirm_password.UseSystemPasswordChar = false;
        }

        private void show_MouseLeave(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = true;
            confirm_password.UseSystemPasswordChar = true;
        }
    }
}