using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public Settings(string account, string password)
        {
            InitializeComponent();
            this.log_in_info = account;
            this.log_in_password = password;
        }

        public string log_in_info { get; set; }

        public string log_in_password { get; set; }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void change_username_Click(object sender, EventArgs e)
        {
            ChangeUsername change_username_form = new ChangeUsername(log_in_info);
            change_username_form.ShowDialog();
        }

        private void change_email_Click(object sender, EventArgs e)
        {
            ChangeEmail change_email_form = new ChangeEmail(log_in_info);
            change_email_form.ShowDialog();
        }

        private void change_password_Click(object sender, EventArgs e)
        {
            Change_Password change_password_form = new Change_Password(log_in_info, log_in_password);
            change_password_form.ShowDialog();
        }
    }
}
