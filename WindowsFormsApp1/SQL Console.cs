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
    public partial class SQL_Console : Form
    {
        public SQL_Console()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lines = richTextBox1.Text.Split('\n');
            foreach (string line in lines)
            {
                string connection_string = @"datasource=localhost;port=3306;username=root;password=";
                try
                {
                    MySqlConnection connection = new MySqlConnection(connection_string);
                    connection.Open();
                    MySqlCommand tally_result_command = new MySqlCommand(line, connection);
                    tally_result_command.ExecuteReader();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
