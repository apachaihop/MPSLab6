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
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection StrCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\down;Extended Properties=text");
        private void Form1_Load_1(object sender, EventArgs e)
        { //Определяем подключение
            
            //Строка для выборки данных
            string Select1 = "SELECT * FROM [Dictionary1.txt]";
            //Создание объекта Command
            OleDbCommand comand1 = new OleDbCommand(Select1, StrCon);
            //Определяем объект Adapter для взаимодействия с источником данных
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(comand1);
            //Определяем объект DataSet
            DataSet AllTables = new DataSet();
            //Открываем подключение
            StrCon.Open();
            //Заполняем DataSet таблицей из источника данных
            adapter1.Fill(AllTables);
            //Заполняем обект datagridview для отображения данных на форме
            dataGridView1.DataSource = AllTables.Tables[0];
            StrCon.Close();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.Name);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"C:\down\Dictionary1.txt", false, Encoding.Default);
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    sw.Write(dataGridView1.Columns[j].HeaderText);
                    if (j < dataGridView1.ColumnCount - 1)
                        sw.Write(",");
                }
                sw.WriteLine();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        sw.Write(dataGridView1.Rows[i].Cells[j].Value);
                        if (j < dataGridView1.ColumnCount - 1)
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
        private void UpdateRecord(object sender, EventArgs e)
        {
            try
            {
                // Получите ID записи, которую нужно обновить
                string idToUpdate = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                // Запрос на обновление
                string updateQuery = $"UPDATE [Dictionary1.txt] SET column1 = value1, column2 = value2 WHERE id = {idToUpdate}";

                // Выполните запрос обновления
                OleDbCommand updateCommand = new OleDbCommand(updateQuery, StrCon);
                StrCon.Open();
                updateCommand.ExecuteNonQuery();
                StrCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteRecord(object sender, EventArgs e)
        {
            try
            {
                // Получите ID записи, которую нужно удалить
                string idToDelete = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                // Запрос на удаление
                string deleteQuery = $"DELETE FROM [Dictionary1.txt] WHERE id = {idToDelete}";

                // Выполните запрос на удаление
                OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, StrCon);
                StrCon.Open();
                deleteCommand.ExecuteNonQuery();
                StrCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilterRecords(object sender, EventArgs e)
        {
            try
            {
                // Запрос на фильтрацию
                string filterQuery = "SELECT * FROM [Dictionary1.txt] WHERE column1 = value1";

                // Выполните запрос фильтрации и обновите dataGridView
                OleDbCommand filterCommand = new OleDbCommand(filterQuery, StrCon);
                OleDbDataAdapter filterAdapter = new OleDbDataAdapter(filterCommand);
                DataSet filterDataSet = new DataSet();
                StrCon.Open();
                filterAdapter.Fill(filterDataSet);
                dataGridView1.DataSource = filterDataSet.Tables[0];
                StrCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string idToDelete = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                string deleteQuery = $"DELETE FROM [Dictionary1.txt] WHERE id = {idToDelete}";

                // Выполните запрос на удаление
                OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, StrCon);
                StrCon.Open();
                deleteCommand.ExecuteNonQuery();
                StrCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            string columnName = comboBox1.Text;
            string filterValue = textBox1.Text;

            // Применяем фильтр
            FilterData(columnName, filterValue,"");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void FilterData(string columnName, string filterValueMin,string filterValueMax)
        {
            // Создаем новый DataSet для хранения отфильтрованных данных
            DataSet filteredData = new DataSet();

            // Открываем подключение
            StrCon.Open();

            // Строка для выборки отфильтрованных данных
            string selectQuery = $"SELECT * FROM [Dictionary1.txt] WHERE [{columnName}] > {filterValueMin}";

            // Создаем объект Command
            OleDbCommand command = new OleDbCommand(selectQuery, StrCon);

            // Определяем объект Adapter для взаимодействия с источником данных
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            // Заполняем DataSet отфильтрованной таблицей из источника данных
            adapter.Fill(filteredData);

            // Заполняем объект DataGridView для отображения данных на форме
            dataGridView1.DataSource = filteredData.Tables[0];

            // Закрываем подключение
            StrCon.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
