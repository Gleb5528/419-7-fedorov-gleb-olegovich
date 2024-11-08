using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Practik
{
    public partial class TIMLID : Form
    {
        private string connectionString = "Data Source=94.241.174.143;Initial Catalog=ProjectManagement;User ID=sa;Password=<CK6d/ehm>";

        public TIMLID()
        {
            InitializeComponent();
            LoadTasks();

        }
        // Метод для загрузки данных из таблицы Tasks в DataGridView
        private void LoadTasks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT TaskID, TaskName, CreationDate, Deadline, ProjectID, Status, TeamLead, AssignedEmployee, Comments FROM Tasks", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewTasks.DataSource = dataTable;
            }
        }



        // Метод для сохранения изменений в базе данных


        private void btnAdd_Click_1(object sender, EventArgs e)        // Метод для добавления новой задачи

        {
            string taskName = textBoxTaskName.Text;
            DateTime deadline = dateTimePickerDeadline.Value;
            DateTime creationDate = dateTimePickerCreationDate.Value;
            int projectId = Convert.ToInt32(textBoxProjectID.Text);
            string status = comboBoxStatus.SelectedItem.ToString();
            string teamLead = textBoxTeamLead.Text;
            string assignedEmployee = textBoxAssignedEmployee.Text;
            string comments = textBoxComments.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Tasks (TaskName, CreationDate, Deadline, ProjectID, Status, TeamLead, AssignedEmployee, Comments) VALUES (@TaskName, @CreationDate, @Deadline, @ProjectID, @Status, @TeamLead, @AssignedEmployee, @Comments)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TaskName", taskName);
                command.Parameters.AddWithValue("@CreationDate", creationDate);
                command.Parameters.AddWithValue("@Deadline", deadline);
                command.Parameters.AddWithValue("@ProjectID", projectId);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@TeamLead", teamLead);
                command.Parameters.AddWithValue("@AssignedEmployee", assignedEmployee);
                command.Parameters.AddWithValue("@Comments", comments);

                command.ExecuteNonQuery();
            }

            LoadTasks(); // Перезагружаем данные в DataGridView
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridViewTasks.CurrentRow;
            if (row != null)
            {
                int taskId = Convert.ToInt32(row.Cells["TaskID"].Value);
                string taskName = row.Cells["TaskName"].Value.ToString();
                DateTime creationDate = Convert.ToDateTime(row.Cells["CreationDate"].Value);
                DateTime deadline = Convert.ToDateTime(row.Cells["Deadline"].Value);
                int projectId = Convert.ToInt32(row.Cells["ProjectID"].Value);
                string status = row.Cells["Status"].Value.ToString();
                string teamLead = row.Cells["TeamLead"].Value.ToString();
                string assignedEmployee = row.Cells["AssignedEmployee"].Value.ToString();
                string comments = row.Cells["Comments"].Value.ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET TaskName = @TaskName, CreationDate = @CreationDate, Deadline = @Deadline, ProjectID = @ProjectID, Status = @Status, TeamLead = @TeamLead, AssignedEmployee = @AssignedEmployee, Comments = @Comments WHERE TaskID = @TaskID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TaskID", taskId);
                    command.Parameters.AddWithValue("@TaskName", taskName);
                    command.Parameters.AddWithValue("@CreationDate", creationDate);
                    command.Parameters.AddWithValue("@Deadline", deadline);
                    command.Parameters.AddWithValue("@ProjectID", projectId);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@TeamLead", teamLead);
                    command.Parameters.AddWithValue("@AssignedEmployee", assignedEmployee);
                    command.Parameters.AddWithValue("@Comments", comments);

                    command.ExecuteNonQuery();
                }

                LoadTasks(); // Перезагружаем данные в DataGridView
            }

        }

        private void textBoxProjectID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли символ цифрой или управляющим (например, Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Блокируем ввод, если символ не является цифрой
            }
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
