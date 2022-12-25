﻿using System;
using System.IO;
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
    public partial class Login : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;

        public Login()
        {
            InitializeComponent();
            CheckIfUserRemembered();
            password.UseSystemPasswordChar = true;
        }
        private void LogIn(string username, string password)
        {
            connection.Open();
            string selectQuery = "SELECT * FROM loginform.userinfo WHERE Username = '" + username + "' AND Password = '" + password + "';";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                string account_type = (mdr.GetString("Type"));
                if (account_type == "Regular")
                {
                    this.Hide();
                    Regular regular = new Regular();
                    regular.ShowDialog();
                }
                else if (account_type == "Privileged")
                {
                    this.Hide();
                    Privileged privileged = new Privileged();
                    privileged.ShowDialog();
                }
                else if (account_type == "Admin")
                {
                    this.Hide();
                    Admin admin = new Admin();
                    admin.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Login information is incorrect. Try again.");
            }
            connection.Close();
        }

        private void CheckIfUserRemembered()
        {
            string roamingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filePath = Path.Combine(roamingDirectory, "C Sharp Project & MySQL Database\\save_files");
            if (Directory.Exists(filePath))
            {
                filePath = (filePath + "\\remember_me.txt");
                string path = Convert.ToString(filePath);
                try
                {
                    string text = System.IO.File.ReadAllText(path);
                    string username = text.Replace("Username : '", "");
                    username = username.Split('\'')[0];
                    username = username.Replace(" ", "");
                    string password = text.Replace("Password : '", "").Replace("Username : '", "");
                    password = password.Split(',')[1];
                    int index = password.IndexOf('\'');
                    if (index >= 0)
                        password = password.Substring(0, index);
                    password = password.Replace("'", "");
                    password = password.Replace(" ", "");
                    LogIn(username, password);
                }
                catch
                {

                }
            }
        }

        private void log_in_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Username or password field is empty, type in a valid value.");
            }
            else
            {
                LogIn(username.Text, password.Text);
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