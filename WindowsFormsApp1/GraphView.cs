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
    public partial class GraphView : Form
    {
        public GraphView()
        {
            InitializeComponent();
            load_graphs();
        }

        private void GraphView_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void load_graphs()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = "datasource=localhost;port=3306;username=root;password=";
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from project_db.drivers_results";
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                chart1.Series.Clear();
                chart1.Series.Add("Points");
                while (reader.Read())
                {
                    chart1.Series[0].Points.AddXY(reader.GetString("FirstName") + " " + reader.GetString("LastName"), reader.GetFloat("Points"));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = "datasource=localhost;port=3306;username=root;password=";
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from project_db.constructors_results";
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                chart2.Series.Clear();
                chart2.Series.Add("Points");
                while (reader.Read())
                {
                    chart2.Series[0].Points.AddXY(reader.GetString("Name"), reader.GetFloat("Points"));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
} 

