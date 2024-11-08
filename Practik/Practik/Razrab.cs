using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Practik
{
    public partial class Razrab : Form
    {
        private string connectionString = "Data Source=94.241.174.143;Initial Catalog=ProjectManagement;User ID=sa;Password=<CK6d/ehm>";

        public Razrab()
        {
            InitializeComponent();
        }


        // Метод для загрузки задач в DataGridView
        private void LoadTasks()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TaskID, TaskName, CreationDate, Deadline, Status FROM Tasks";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable tasksTable = new DataTable();
                adapter.Fill(tasksTable);

                // Устанавливаем источник данных для DataGridView
                dataGridViewTasks.DataSource = tasksTable;
            }
        }

        // Метод для сохранения изменений статуса задачи
        private void btnSaveChanges_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Проходимся по всем строкам DataGridView
                foreach (DataGridViewRow row in dataGridViewTasks.Rows)
                {
                    if (row.Cells["Status"].Value != null && row.Cells["TaskID"].Value != null)
                    {
                        int taskId = Convert.ToInt32(row.Cells["TaskID"].Value);
                        string status = row.Cells["Status"].Value.ToString();

                        // Обновление статуса задачи в базе данных
                        string updateQuery = "UPDATE Tasks SET Status = @Status WHERE TaskID = @TaskID";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Status", status);
                            cmd.Parameters.AddWithValue("@TaskID", taskId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Изменения сохранены.");
            }

            // Перезагрузка задач после сохранения изменений
            LoadTasks();
        }

        private void Razrab_Load_1(object sender, EventArgs e)
        {
            LoadTasks();
                
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Открываем форму входа Form1
            Form1 form1 = new Form1();
            form1.Show();

            // Закрываем текущую форму Razrab
            this.Close();
        }
    }
}
