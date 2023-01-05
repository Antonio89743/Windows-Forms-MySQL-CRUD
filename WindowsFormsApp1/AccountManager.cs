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

                    int y = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Label label1 = new Label();
                        label1.Text = dr["ID"].ToString();
                        label1.Location = new Point(0, y);

                        Label label2 = new Label();
                        label2.Text = dr["Username"].ToString();
                        label2.Location = new Point(label1.Width + 10, y);


                        // create radio buttons for type picker



                        y += label1.Height + 5;
                        this.Controls.Add(label1);
                        this.Controls.Add(label2);
                        // Add other labels
                    }

                }
            }
        }
    }
}
