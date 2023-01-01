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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            FillTablePickerComboBox();
            load_data_grid_view();
        }

        private void FillTablePickerComboBox()
        {
            string myConnectionString = @"datasource=localhost;port=3306;username=root;password=";
            MySqlConnection dbConnection = new MySqlConnection(myConnectionString);
            MySqlCommand sqlCmd = new MySqlCommand();
            try
            {
                sqlCmd.Connection = dbConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "use project_db; select * from information_schema.tables where table_schema = 'project_db';";
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);
                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                table_picker.DataSource = dtRecord;
                table_picker.DisplayMember = "TABLE_NAME";
                table_picker.SelectedText.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbConnection.Close();     
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void table_picker_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    MySqlDataAdapter data_adapter = new MySqlDataAdapter("select * from " + table_picker.Text.ToString(), conn);
                    DataTable data_table = new DataTable();
                    data_adapter.Fill(data_table);
                    dataGridView1.DataSource = data_table;
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.DisplayIndex = col.Index;
                    }
                }
                try
                {
                    MySqlConnection connection = new MySqlConnection(connection_string);
                    connection.Open();
                    MySqlCommand tally_result_command = new MySqlCommand("select sum(Points) from project_db." + table_picker.Text.ToString(), connection);
                    int tally_result = Convert.ToInt32(tally_result_command.ExecuteScalar().ToString());
                    connection.Close();
                    total_points.Text = "Total Points: " + tally_result.ToString();
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch
            {

            }
        }

        private void log_out_Click(object sender, EventArgs e)
        {
            try
            {
                string roamingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var filePath = Path.Combine(roamingDirectory, "C Sharp Project & MySQL Database\\save_files");
                filePath = (filePath + "\\remember_me.txt");
                File.Delete(filePath);
            }
            catch (Exception error)
            {
                Console.WriteLine($"File could not be deleted:");
                Console.WriteLine(error.Message);
            }
            this.Hide();
            Login frm4 = new Login();
            frm4.ShowDialog();
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            load_data_grid_view();
        }

        private void account_manager_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountManager account_manager_form = new AccountManager();
            account_manager_form.ShowDialog();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // drop selected row context menu
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                { 
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
            }

            //private void dataGridView1_MouseClick(object sender, MouseEventArgs e)

            //if (e.Button == MouseButtons.Right)
            //{
            //    ContextMenu m = new ContextMenu();
            //    m.MenuItems.Add(new MenuItem("Cut"));
            //    m.MenuItems.Add(new MenuItem("Copy"));
            //    m.MenuItems.Add(new MenuItem("Paste"));

            //    int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            //    if (currentMouseOverRow >= 0)
            //    {
            //        m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
            //    }

            //    m.Show(dataGridView1, new Point(e.X, e.Y));

            //}


        }
    }
}
