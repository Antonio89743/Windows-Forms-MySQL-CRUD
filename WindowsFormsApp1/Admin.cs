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
        public static class Globals
        {
            public static string id_of_selected_row = null;
            public static int column_index = 0;
            public static int row_index = 0;
            public static DataGridViewRow selectedRow = null;
        }

        public Admin()
        {
            InitializeComponent();
            FillTablePickerComboBox();
            load_data_grid_view();
        }
        public Admin(string account, string password)
        {
            InitializeComponent();
            FillTablePickerComboBox();
            load_data_grid_view();
            this.log_in_info = account;
            this.log_in_password = password;
        }

        public string log_in_info { get; set; }

        public string log_in_password { get; set; }

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
                    DataSet data_set = new DataSet();
                    DataTable data_table = new DataTable();
                    data_adapter.Fill(data_table); 
                    data_adapter.Fill(data_set);       
                    BindingSource bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = data_table;
                    bindingNavigator1.BindingSource = bindingSource1;
                    dataGridView1.DataSource = bindingSource1;
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.DisplayIndex = col.Index;
                    }
                }
                try
                {
                    MySqlConnection connection = new MySqlConnection(connection_string);
                    MySqlCommand tally_result_command = new MySqlCommand("select sum(Points) from project_db." + table_picker.Text.ToString(), connection);
                    tally_result_command.CommandTimeout = 1000;
                    connection.Open(); 
                    var reader = tally_result_command.ExecuteScalar();
                    if (reader.ToString() == "")
                    {
                        total_points.Text = "Total Points: null";
                    }
                    else 
                    {
                        total_points.Text = "Total Points: " + reader.ToString();
                    }   
                    connection.Close();
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
            AccountManager account_manager_form = new AccountManager(log_in_info, log_in_password);
            account_manager_form.ShowDialog();
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

        private void button1_Click(object sender, EventArgs e)
        {
            GraphView frm4 = new GraphView();
            frm4.ShowDialog();
        }

        private void cut_cell_data(object sender, EventArgs e)
        {
            if (Globals.selectedRow.Cells[Globals.column_index].Value.ToString() != "")
            {
                Clipboard.SetText(Globals.selectedRow.Cells[Globals.column_index].Value.ToString());
                // delete content from datagridview and from mysql db
            }
        }

        private void copy_cell_data(object sender, EventArgs e)
        {
            if (Globals.selectedRow.Cells[Globals.column_index].Value.ToString() != "")
            {
                Clipboard.SetText(Globals.selectedRow.Cells[Globals.column_index].Value.ToString());
            }     
        }

        private void paste_cell_data(object sender, EventArgs e)
        {
            // get active cell
            // get only selected letters substring (the letters with blue background)
            // replace that substring with whatever is in the cplipboard
        }

        private void delete_row(object sender, EventArgs e)
        {
            string connection_string = @"datasource=localhost;port=3306;username=root;password=";
            if (Globals.id_of_selected_row.ToString() != "")
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connection_string))
                    {
                        MySqlCommand cmd = new MySqlCommand("delete from project_db." + table_picker.Text.ToString() + " where ID=" + Globals.id_of_selected_row, conn);
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
            else
            {
                MessageBox.Show("Row is empty. Pick a row with a valid entry");
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string connection_string = @"datasource=localhost;port=3306;username=root;password=";
            var data_input = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            var data_input_column_name_string = dataGridView1.Columns[e.ColumnIndex].Name.ToString();
            int? row_edited_id = null;
            foreach (DataGridViewColumn column in this.dataGridView1.Columns)
            {
                try
                {
                    if (column.Name == "ID")
                    {
                        row_edited_id = Int16.Parse(dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString());
                    }
                }
                catch
                {
                }

            }
            if (data_input_column_name_string == "ID")
            {
                int send_var = int.Parse(data_input);
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connection_string))
                    {
                        MySqlCommand cmd = new MySqlCommand("replace into project_db." + table_picker.Text.ToString() + "(" + data_input_column_name_string + ") values(" + send_var + ")", conn);
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
            else if (data_input_column_name_string == "Points")
            {
                float send_var = float.Parse(data_input);
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connection_string))
                    {
                        MySqlCommand cmd;
                        if (row_edited_id != null)
                        {
                            cmd = new MySqlCommand("update project_db." + table_picker.Text.ToString() + " set " + data_input_column_name_string + "=" + send_var + " where ID=" + row_edited_id, conn);
                        }
                        else
                        {
                            cmd = new MySqlCommand("insert into project_db." + table_picker.Text.ToString() + "(" + data_input_column_name_string + ") values('" + send_var + "')", conn);
                        }
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
            else
            {
                string send_var = data_input;
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connection_string))
                    {
                        MySqlCommand cmd;
                        if (row_edited_id != null)
                        {
                            cmd = new MySqlCommand("update project_db." + table_picker.Text.ToString() + " set " + data_input_column_name_string + "='" + send_var + "' where ID=" + row_edited_id, conn);
                        }
                        else
                        {
                            cmd = new MySqlCommand("insert into project_db." + table_picker.Text.ToString() + "(" + data_input_column_name_string + ") values('" + send_var + "')", conn);
                        }
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
            load_data_grid_view();
        }

        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 48, 72, 112);
            bindingNavigator1.BackColor = Color.FromArgb(255, 48, 72, 112);
        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = default(Color);
            bindingNavigator1.BackColor = default(Color);
        }

        private void changeThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog bgColor = new ColorDialog();
            bgColor.ShowDialog();
            this.BackColor = bgColor.Color;
            bindingNavigator1.BackColor = bgColor.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQL_Console sql_console = new SQL_Console();
            sql_console.ShowDialog();
        }

        private void settings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
    }
}
