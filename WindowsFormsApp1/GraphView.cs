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
            string connection_string = @"datasource=localhost;port=3306;username=root;password=";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection_string))
                {
                    conn.Open();
                    MySqlDataAdapter data_adapter = new MySqlDataAdapter("select * from project_db.drivers_results", conn);
                    MessageBox.Show(data_adapter.ToString());
                }

                //string myConnectionString = @"datasource=localhost;port=3306;username=root;password=";
                //MySqlConnection dbConnection = new MySqlConnection(myConnectionString);
                //MySqlCommand sqlCmd = new MySqlCommand();
                //MySqlCommand cmd = dbConnection.CreateCommand();
                //cmd.CommandText = "SELECT * from project_db.drivers_results";
                //MySqlDataReader reader;
                //chart1.Series.Clear();
                //chart2.Series.Clear();
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{


                //    chart1.Series[0].Points.AddXY(reader.GetString("FirstName"), reader.GetDateTime("LastName"));
                //}
            }
            catch
            {

            }
        }
    } 
}
