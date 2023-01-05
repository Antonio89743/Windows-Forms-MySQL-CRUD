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
    public partial class ChangeUsername : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

        public ChangeUsername()
        {
            InitializeComponent();
        }

        public ChangeUsername(string account)
        {
            InitializeComponent();
            this.log_in_info = account;
        }

        public string log_in_info { get; set; }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("New Username field is empty. Try again.");
                return;
            }
            else
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM loginform.userinfo WHERE Username = @UserName", connection);  
                    cmd1.Parameters.AddWithValue("@Username", textBox1.Text);
                    bool username_exists = false;
                    using (var dr1 = cmd1.ExecuteReader())
                        if (username_exists = dr1.HasRows) MessageBox.Show("Username not available!");
                    if (!(username_exists))
                    {
                        MySqlCommand cmd;
                        cmd = new MySqlCommand("update loginform.userinfo set Username='" + textBox1.Text + "' where Username='" + log_in_info + "' or Email='" + log_in_info + "'", connection);
                        cmd.CommandTimeout = 1000;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Username changed successfully.");
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
