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
using System.Net.Mail;

namespace WindowsFormsApp1
{
    public partial class ForgottenPassword : Form
    {
        public ForgottenPassword()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

        private void reset_password_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("'") || textBox1.Text.Contains(" "))
            {
                MessageBox.Show("Email cannot contain spaces or single quotation marks!", "Try Again.");
                return;
            }
            if (textBox1.Text.Contains("@") == false || textBox1.Text.Contains(".") == false)
            {
                MessageBox.Show("Email must contain and at sign and a period!", "Try Again.");
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
                        if (email_exists = dr1.HasRows)
                        {
                            connection.Close();
                            send_email();
                        }
                        else
                        {
                            MessageBox.Show("Email is not valid. Try again.");
                        }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }
        private void send_email()
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("project_db_connect_mysql@outlook.com", "t5HeG#fPL?tU=xg");
                client.EnableSsl = true;
                client.Credentials = credentials;
                MailMessage mail = new MailMessage("project_db_connect_mysql@outlook.com", textBox1.Text);
                mail.Subject = "C# Forms Desktop App Forgotten Password";
                string new_password = generate_password();
                update_password_db(new_password, textBox1.Text);
                mail.Body = "<p>Your new password is: " + new_password + "<p>";
                mail.IsBodyHtml = true;
                client.Send(mail);
                MessageBox.Show("Message sent succesfully. Check your email.");
                this.Hide();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void update_password_db(string new_password, string email)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("update loginform.userinfo set Password='" + new_password + "' where Email='" + email +"'", connection);
                cmd.CommandTimeout = 1000;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private string generate_password()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[16];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }
    }
}
