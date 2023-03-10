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

        public string log_in_info { get; set; }
        public string username { get; set; }
        public string log_in_password { get; set; }

        public Privileged()
        {
            InitializeComponent();
            FillTablePickerComboBox();
            load_data_grid_view();
        }

        public Privileged(string account, string password)
        {
            InitializeComponent();
            FillTablePickerComboBox();
            load_data_grid_view();
            this.log_in_info = account;
            this.log_in_password = password;
            if (log_in_info.Contains("@"))
            {
                try
                {
                    MySqlCommand command;
                    MySqlDataReader mdr;
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                    connection.Open();
                    string selectQuery = "SELECT * FROM loginform.userinfo WHERE (Username = '" + username + "' or Email = '" + username + "') AND Password = '" + password + "';";
                    command = new MySqlCommand(selectQuery, connection);
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        this.username = mdr.GetString("Username");
                    }
                    else
                    {
                    }
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Server connection failed. Check if Xampp's Apache and MySQL modules are working correctly.");
                }
            }
            else
            {
                this.username = this.log_in_info;
            }
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
            Settings settings = new Settings(log_in_info, log_in_password);
            settings.ShowDialog();
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
            if (Globals.selectedRow.Cells[Globals.column_index].Value.ToString() != "")
            {
                Clipboard.SetText(Globals.selectedRow.Cells[Globals.column_index].Value.ToString());
                Globals.selectedRow.Cells[Globals.column_index].Value = "";
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
            Globals.selectedRow.Cells[Globals.column_index].Value = Clipboard.GetText();
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
                        table_edited(table_picker.Text.ToString(), " ", Globals.id_of_selected_row.ToString(), "DELETE", Globals.id_of_selected_row.ToString());
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

        private void table_edited(string table, string new_value, string old_value, string change_type, string chenged_id)
        {
            string date_and_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string connection_string = @"datasource=localhost;port=3306;username=root;password=";
            string values = this.username.ToString() + "', '" + date_and_time + "', '" + table + "', '" + change_type + "', '" + old_value + "', '" + new_value + "', '" + chenged_id;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection_string))
                {
                    MySqlCommand cmd = new MySqlCommand("insert into changes_db.changes (Username, Datetime, TableChanged, ChangeType, OldValue, NewValue, ChangedID) values('" + values + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string connection_string = @"datasource=localhost;port=3306;username=root;password=";
            var data_input = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            var data_input_column_name_string = dataGridView1.Columns[e.ColumnIndex].Name.ToString();
            int? row_edited_id = null;
            string new_value = "";
            string old_value = "";
            string change_type = "";
            string chenged_id = row_edited_id.ToString();
            foreach (DataGridViewColumn column in this.dataGridView1.Columns)
            {
                try
                {
                    if (column.Name == "ID")
                    {
                        row_edited_id = Int16.Parse(dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString());
                        change_type = "CREATE";
                        new_value = dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString();
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
                    try
                    {
                        MySqlCommand command;
                        MySqlDataReader mdr;
                        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                        connection.Open();
                        string selectQuery = "SELECT * FROM project_db." + table_picker.Text.ToString() + " where ID=" + row_edited_id;
                        command = new MySqlCommand(selectQuery, connection);
                        mdr = command.ExecuteReader();
                        if (mdr.Read())
                        {
                            old_value = mdr.GetString("ID");
                        }
                        else
                        {
                        }
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Server connection failed. Check if Xampp's Apache and MySQL modules are working correctly.");
                    }
                    using (MySqlConnection conn = new MySqlConnection(connection_string))
                    {
                        MySqlCommand cmd = new MySqlCommand("replace into project_db." + table_picker.Text.ToString() + "(" + data_input_column_name_string + ") values(" + send_var + ")", conn);
                        change_type = "UPDATE";
                        new_value = data_input;
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
                new_value = send_var.ToString();
                try
                {
                    try
                    {
                        MySqlCommand command;
                        MySqlDataReader mdr;
                        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                        connection.Open();
                        string selectQuery = "SELECT * FROM project_db." + table_picker.Text.ToString() + " where ID=" + row_edited_id;
                        command = new MySqlCommand(selectQuery, connection);
                        mdr = command.ExecuteReader();
                        if (mdr.Read())
                        {
                            old_value = mdr.GetString("Points");
                        }
                        else
                        {
                        }
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Server connection failed. Check if Xampp's Apache and MySQL modules are working correctly.");
                    }
                    using (MySqlConnection conn = new MySqlConnection(connection_string))
                    {
                        MySqlCommand cmd;
                        if (row_edited_id != null)
                        {
                            cmd = new MySqlCommand("update project_db." + table_picker.Text.ToString() + " set " + data_input_column_name_string + "=" + send_var + " where ID=" + row_edited_id, conn);
                            change_type = "UPDATE";

                        }
                        else
                        {
                            cmd = new MySqlCommand("insert into project_db." + table_picker.Text.ToString() + "(" + data_input_column_name_string + ") values('" + send_var + "')", conn);
                            change_type = "CREATE";
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
                new_value = send_var;
                try
                {
                    try
                    {
                        MySqlCommand command;
                        MySqlDataReader mdr;
                        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                        connection.Open();
                        string selectQuery = "SELECT * FROM project_db." + table_picker.Text.ToString() + " where ID=" + row_edited_id;
                        command = new MySqlCommand(selectQuery, connection);
                        mdr = command.ExecuteReader();
                        if (mdr.Read())
                        {
                            old_value = mdr.GetString(data_input_column_name_string);
                        }
                        else
                        {
                        }
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Server connection failed. Check if Xampp's Apache and MySQL modules are working correctly.");
                    }
                    using (MySqlConnection conn = new MySqlConnection(connection_string))
                    {
                        MySqlCommand cmd;
                        if (row_edited_id != null)
                        {
                            cmd = new MySqlCommand("update project_db." + table_picker.Text.ToString() + " set " + data_input_column_name_string + "='" + send_var + "' where ID=" + row_edited_id, conn);
                            change_type = "UPDATE";
                        }
                        else
                        {
                            cmd = new MySqlCommand("insert into project_db." + table_picker.Text.ToString() + "(" + data_input_column_name_string + ") values('" + send_var + "')", conn);
                            change_type = "CREATE";
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
            table_edited(table_picker.Text.ToString(), new_value, old_value, change_type, chenged_id);
        }

        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 48, 72, 112);
            bindingNavigator1.BackColor = Color.FromArgb(255, 48, 72, 112);
        }

        private void lightThmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = default(Color);
            bindingNavigator1.BackColor = default(Color);
        }

        private void customBackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog bgColor = new ColorDialog();
            bgColor.ShowDialog();
            this.BackColor = bgColor.Color;
            bindingNavigator1.BackColor = bgColor.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQL_Console sql_console = new SQL_Console();
            sql_console.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewChanges view = new ViewChanges();
            view.ShowDialog();
        }
    }
}
    