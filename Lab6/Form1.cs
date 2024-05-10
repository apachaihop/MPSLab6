using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\down;Extended Properties=text";
            connection = new OleDbConnection(connectionString);
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Dictionary1.txt", connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewBook.DataSource = dataTable;
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
                StreamWriter sw = new StreamWriter(@"C:\down\Dictionary1.txt", false, Encoding.Default);
                for (int j = 0; j < dataGridViewBook.ColumnCount; j++)
                {
                    sw.Write(dataGridViewBook.Columns[j].HeaderText);
                    if (j < dataGridViewBook.ColumnCount - 1)
                        sw.Write(",");
                }
                sw.WriteLine();
                for (int i = 0; i < dataGridViewBook.RowCount; i++)
                {
                    for (int j = 0; j < dataGridViewBook.ColumnCount; j++)
                    {
                        sw.Write(dataGridViewBook.Rows[i].Cells[j].Value);
                        if (j < dataGridViewBook.ColumnCount - 1)
                            sw.Write(",");
                    }
                    sw.WriteLine();
                }
                sw.Flush();
                sw.Close();
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
                filteredDataTable.DefaultView.RowFilter = $"{filter.ColumnName} {filter.FilterCondition} '{filter.FilterValue}'";
            }

            dataGridViewBook.DataSource = filteredDataTable;
        }
        private void button4_Click(object sender, EventArgs e)
        {

            string fieldName = comboBoxFields.SelectedItem.ToString();
            string condition = comboBoxFilter.SelectedItem.ToString();
            string filterValue = textBoxValue.Text;

            string filterExpression = $"{fieldName} {condition} '{filterValue}'";

            Filter filter= new Filter();
            filter.ColumnName = fieldName;
            filter.FilterCondition = condition;
            filter.FilterValue = filterValue;
            filters.Add(filter);

            FilterAndDisplayRows(filters);

            button1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewBook.DataSource = dataTable;
            button1.Enabled = false;

        }
    }
    public class Filter
    {
        public string ColumnName { get; set; }
        public string FilterCondition { get; set; }
        public string FilterValue { get; set; }
    }
}
