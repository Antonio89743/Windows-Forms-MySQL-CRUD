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
    public partial class ChangeEmail : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

        public ChangeEmail()
        {
            InitializeComponent();
        }

        public ChangeEmail(string account)
        {
            InitializeComponent();
            this.log_in_info = account;
        }

        public string log_in_info { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("New Email field is empty. Try again.");
                return;
            }
            if (textBox1.Text.Contains("'") || textBox1.Text.Contains(" "))
            {
                MessageBox.Show("Email cannot contain spaces or single quotation marks!", "Try Again.");
                return;
            }
            if (textBox1.Text.Contains("@") == false || textBox1.Text.Contains(".") == false)
            {
                MessageBox.Show("Email must contain an at sign and a period!", "Try Again.");
                return;
            }
            else
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM loginform.userinfo WHERE Email = @UserEmail", connection);
                    cmd1.Parameters.AddWithValue("@UserEmail", textBox1.Text);
                    bool email_exists = false;
                    using (var dr1 = cmd1.ExecuteReader())
                        if (email_exists = dr1.HasRows) MessageBox.Show("Email not available!");
                    if (!(email_exists))
                    {
                        connection.Open();
                        MySqlCommand cmd;
                        cmd = new MySqlCommand("update loginform.userinfo set Email='" + textBox1.Text + "' where Username='" + log_in_info + "' or Email='" + log_in_info + "'", connection);
                        cmd.CommandTimeout = 1000;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Email changed successfully.");
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }
    }
}
