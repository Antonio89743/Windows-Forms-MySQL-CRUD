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
using System.Diagnostics;
using System.Web;

namespace WindowsFormsApp1
{
    public partial class Change_Password : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

        public Change_Password()
        {
            InitializeComponent();
        }

        public Change_Password(string account, string password)
        {
            InitializeComponent();
            this.log_in_info = account;
            this.log_in_password = password;
        }

        public string log_in_info { get; set; }

        public string log_in_password { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (current_password.Text == new_password.Text)
            {
                MessageBox.Show("Password match! Try Again.");
                return;
            }
            if (string.IsNullOrEmpty(new_password.Text) || string.IsNullOrEmpty(current_password.Text))
            {
                MessageBox.Show("Please fill out all information!");
                return;
            }
            if (new_password.Text.Contains("'") || new_password.Text.Contains(" "))
            {
                MessageBox.Show("Password cannot contain spaces or single quotation marks!", "Try Again.");
                return;
            }
            else
            {
                try
                {
                    MySqlDataReader mdr;
                    connection.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from loginform.userinfo where Username='" + log_in_info + "' or Email='" + log_in_info + "'", connection);
                    mdr = cmd.ExecuteReader();
                    string old_password_from_db = "";
                    if (mdr.Read())
                    {
                        old_password_from_db = (mdr.GetString("Password"));
                    }
                    if (old_password_from_db == current_password.Text)
                    {
                        connection.Close();
                        update_password();
                    }    
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void update_password()
        {
            try 
            {
                connection.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("update loginform.userinfo set Password='" + new_password.Text + "' where Username='" + log_in_info + "' or Email='" + log_in_info + "'", connection);
                cmd.CommandTimeout = 1000;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Password changed successfully.");
            }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
    }
}
