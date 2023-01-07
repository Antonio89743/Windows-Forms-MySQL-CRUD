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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class AccountManager : Form
    {
        public AccountManager()
        {
            InitializeComponent();
        }

        public AccountManager(string account, string password)
        {
            InitializeComponent();
            this.log_in_info = account;
            this.log_in_password = password;
        }

        public string log_in_info { get; set; }
        public string log_in_password { get; set; }

        private void AccountManager_Load(object sender, EventArgs e)
        {
            load_accounts();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void RadioButtonChecked(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                string new_type = (sender as RadioButton).Text;
                var panel = (sender as RadioButton).Parent;
                int id = Int16.Parse((panel.Controls.OfType<Label>().First()).Text);

                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                try
                {
                    connection.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("update loginform.userinfo set Type='" + new_type + "' where ID=" + id, connection);
                    cmd.CommandTimeout = 1000;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Type changed successfully.");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void load_accounts()
        {
            string myConnectionString = @"datasource=localhost;port=3306;username=root;password=";
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                string CommandText = "SELECT * FROM loginform.userinfo where Password not in ('" + log_in_password + "') and (Username not in ('" + log_in_info + "') or Email not in ('" + log_in_info + "'))";
                using (MySqlCommand cmd = new MySqlCommand(CommandText, conn))
                {
                    conn.Open();
                    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    int y = 5;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Panel panel = new Panel();
                        panel.Location = new Point(0, y);
                        Label label1 = new Label();
                        label1.Text = dr["ID"].ToString();
                        label1.Location = new Point(0, y);
                        label1.AutoSize = true;
                        label1.Width = 25;
                        Label label2 = new Label();
                        label2.Text = dr["Username"].ToString();
                        label2.Location = new Point(label1.Width + 0, y);
                        RadioButton radio_button_regular = new RadioButton();
                        radio_button_regular.Text = "Regular";
                        radio_button_regular.Location = new Point(label1.Width + 150, y);
                        radio_button_regular.AutoSize = true;
                        RadioButton radio_button_privileged = new RadioButton();
                        radio_button_privileged.Text = "Privileged";
                        radio_button_privileged.Location = new Point(label1.Width + 250, y);
                        radio_button_privileged.AutoSize = true;
                        RadioButton radio_button_admin = new RadioButton();
                        radio_button_admin.Text = "Admin";
                        radio_button_admin.Location = new Point(label1.Width + 350, y);
                        radio_button_admin.AutoSize = true;
                        if (dr["Type"].ToString() == "Admin")
                        {
                            radio_button_admin.Checked = true;
                        }
                        else if (dr["Type"].ToString() == "Privileged")
                        {
                            radio_button_privileged.Checked = true;
                        }
                        else
                        {
                            radio_button_regular.Checked = true;
                        }
                        y += label1.Height + 5;
                        this.Controls.Add(panel);
                        panel.Controls.Add(label1);
                        panel.Controls.Add(label2);
                        panel.Controls.Add(radio_button_regular);
                        panel.Controls.Add(radio_button_privileged);
                        panel.Controls.Add(radio_button_admin);
                        panel.AutoSize = true;
                        panel.Height = 20;
                        radio_button_regular.CheckedChanged += new EventHandler(RadioButtonChecked);
                        radio_button_privileged.CheckedChanged += new EventHandler(RadioButtonChecked);
                        radio_button_admin.CheckedChanged += new EventHandler(RadioButtonChecked);
                        conn.Close();
                    }
                }
            }
        }
    }
}
