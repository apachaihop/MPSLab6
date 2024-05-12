using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    

    public partial class Form1 : Form
    {
        private OleDbConnection connection;
        private OleDbDataAdapter dataAdapter;
        private DataTable dataTable;
        List<Filter> filters=new List<Filter>();
        public Form1()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            PopulateComboBoxFields();
        }

        private void InitializeDatabaseConnection()
        {
            try
            {
                string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.;Extended Properties=text";
                connection = new OleDbConnection(connectionString);
                string filePath = "Dictionary1.txt";
                string firstLine = "id,name,author,date,price";

                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, firstLine);
                }
                else
                {
                     var lines = File.ReadAllLines(filePath);

                    if (lines.Length == 0 || lines[0] != firstLine)
                    {
                        var newLines = new List<string> { firstLine };
                        lines[0]= firstLine;
                        File.WriteAllLines(filePath, newLines);
                    }
                    else
                    {
                        System.Console.WriteLine("Файл уже существует и содержит нужную строку.");
                    }
                }
                dataAdapter = new OleDbDataAdapter("SELECT * FROM Dictionary1.txt", connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewBook.DataSource = dataTable;
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateComboBoxFields()
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                comboBoxFields.Items.Add(column.ColumnName);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"Dictionary1.txt", false, Encoding.Default);
                for (int j = 0; j < dataGridViewBook.ColumnCount; j++)
                {
                    sw.Write(dataGridViewBook.Columns[j].HeaderText);
                    if (j < dataGridViewBook.ColumnCount - 1)
                        sw.Write(",");
                }
                sw.WriteLine();
                
                sw.Flush();
                sw.Close();
                string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.;Extended Properties=text";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    for (int i = 0; i < dataGridViewBook.RowCount-1; i++)
                    {
                        string commandText = "INSERT INTO Dictionary1.txt VALUES (";

                        for (int j = 0; j < dataGridViewBook.ColumnCount; j++)
                        {
                            if (dataGridViewBook.Columns[j].Name == "date") 
                            {
                                DateTime dateValue = Convert.ToDateTime(dataGridViewBook.Rows[i].Cells[j].Value);
                                string formattedDate = dateValue.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                commandText += "'" + formattedDate + "'";
                            }
                            else
                            {
                                commandText += "'" + dataGridViewBook.Rows[i].Cells[j].Value + "'";
                            }

                            if (j < dataGridViewBook.ColumnCount - 1)
                                commandText += ",";
                        }

                        commandText += ")";

                        using (OleDbCommand command = new OleDbCommand(commandText, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                string text = File.ReadAllText("Dictionary1.txt");
                text = text.Replace("\"", string.Empty);
                File.WriteAllText("Dictionary1.txt", text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FilterAndDisplayRows(List<Filter> filters)
        {
            DataTable filteredDataTable = dataTable.Copy();

            foreach (Filter filter in filters)
            {

                if(filter.ColumnName=="name"|| filter.ColumnName == "author")
                {
                    filter.FilterCondition = "LIKE";
                    filter.FilterValue = "%" + filter.FilterValue + "%";
                }
                if (filter.FilterOp != null)
                {
                    filteredDataTable.DefaultView.RowFilter += $"{filter.FilterOp} {filter.ColumnName} {filter.FilterCondition} '{filter.FilterValue}'";
                }
                else
                {
                    filteredDataTable.DefaultView.RowFilter += $"{filter.ColumnName} {filter.FilterCondition} '{filter.FilterValue}'";
                }
            }

            dataGridViewBook.DataSource = filteredDataTable;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string fieldName = comboBoxFields.SelectedItem.ToString();
                string condition = comboBoxFilter.SelectedItem.ToString();
                string filterValue = textBoxValue.Text;

                if (fieldName == "")
                {
                    MessageBox.Show("Пустой фильтр");
                    return;
                }
                if (condition == "")
                {
                    MessageBox.Show("Пустой фильтр");
                    return;

                }
                if (filterValue == "")
                {
                    MessageBox.Show("Пустой фильтр");
                    return;

                }
                Filter filter = new Filter();
                filter.ColumnName = fieldName;
                filter.FilterCondition = condition;
                filter.FilterValue = filterValue;
                if (button1.Enabled == true)
                {
                    filter.FilterOp = comboBoxCondition.SelectedItem.ToString();
                }
                filters.Add(filter);

                FilterAndDisplayRows(filters);

                button1.Enabled = true;
                comboBoxCondition.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Пустой фильтр");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewBook.DataSource = dataTable;
            button1.Enabled = false;
            comboBoxCondition.Enabled = false;
            filters.Clear();


        }

        private void dataGridViewBook_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {

            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }
    }
    public class Filter
    {
        public string ColumnName { get; set; }
        public string FilterCondition { get; set; }
        public string FilterOp { get; set; }
        public string FilterValue { get; set; }
    }
}
