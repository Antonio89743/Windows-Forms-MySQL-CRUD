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
    public partial class Privileged : Form
    {
        public static class Globals
        {
            public static string id_of_selected_row = null;
            public static int column_index = 0;
            public static int row_index = 0;
            public static DataGridViewRow selectedRow = null;
        }
        public Privileged()
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
            catch (Exception error)    
            {
                MessageBox.Show(error.Message);
            }
            dbConnection.Close();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data_grid_view();
        }

        private void settings_Click(object sender, EventArgs e)
        {

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

        private void Privileged_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                Globals.id_of_selected_row = row.Cells[0].Value.ToString();
                Globals.column_index = e.ColumnIndex;
                Globals.row_index = e.RowIndex;
                Globals.selectedRow = dataGridView1.Rows[Globals.row_index];
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu mnuContextMenu = new ContextMenu();
                    mnuContextMenu.MenuItems.Add("Cut", new EventHandler(cut_cell_data));
                    mnuContextMenu.MenuItems.Add("Copy", new EventHandler(copy_cell_data));
                    mnuContextMenu.MenuItems.Add("Paste", new EventHandler(paste_cell_data));
                    mnuContextMenu.MenuItems.Add("Delete Row", new EventHandler(delete_row));
                    this.ContextMenu = mnuContextMenu;
                    mnuContextMenu.Show(this, new Point(Cursor.Position.X - 210, Cursor.Position.Y - 230));
                }
            }
        }
        private void graph_view_Click(object sender, EventArgs e)
        {
            GraphView frm4 = new GraphView();
            frm4.ShowDialog();
        }
        private void cut_cell_data(object sender, EventArgs e)
        {
            Clipboard.SetText(Globals.selectedRow.Cells[Globals.column_index].Value.ToString());
            // delete content from datagridview and from mysql db
        }

        private void copy_cell_data(object sender, EventArgs e)
        {
            Clipboard.SetText(Globals.selectedRow.Cells[Globals.column_index].Value.ToString());
        }

        private void paste_cell_data(object sender, EventArgs e)
        {

        }
        private void delete_row(object sender, EventArgs e)
        {
            string connection_string = @"datasource=localhost;port=3306;username=root;password=";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection_string))
                {
                    MySqlCommand cmd = new MySqlCommand("delete from project_db." + table_picker.Text.ToString() + " where ID=" + Globals.id_of_selected_row, conn);
                    cmd.Parameters.AddWithValue("@Table", table_picker.Text.ToString());
                    cmd.Parameters.AddWithValue("@ID_of_selected_row", Globals.id_of_selected_row);
                    cmd.CommandTimeout = 1000;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    load_data_grid_view();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
