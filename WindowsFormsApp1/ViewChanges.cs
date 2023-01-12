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
    public partial class ViewChanges : Form
    {
        public ViewChanges()
        {
            InitializeComponent();
        }

        private void ViewChanges_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            load_data_grid_view();
        }

        private void load_data_grid_view()
        {
            string connection_string = @"datasource=localhost;port=3306;username=root;password=";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection_string))
                {
                    conn.Open();
                    MySqlDataAdapter data_adapter = new MySqlDataAdapter("select * from changes_db.changes", conn);
                    DataSet data_set = new DataSet();
                    DataTable data_table = new DataTable();
                    data_adapter.Fill(data_table);
                    data_adapter.Fill(data_set);
                    BindingSource bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = data_table;
                    dataGridView1.DataSource = bindingSource1;
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.DisplayIndex = col.Index;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
