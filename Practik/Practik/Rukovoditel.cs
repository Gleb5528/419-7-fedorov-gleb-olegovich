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
using System.Windows.Forms.DataVisualization.Charting;

namespace Practik
{
    public partial class Rukovoditel : Form
    {
        private string connectionString = "Data Source=94.241.174.143;Initial Catalog=ProjectManagement;User ID=sa;Password=<CK6d/ehm>";

        public Rukovoditel()
        {
            InitializeComponent();
            dataGridViewProjects.Visible = false;
            chartEfficiency.Visible = false;
        }

        private void btnShowProjects_Click(object sender, EventArgs e)
        {
            btnShowProjects.BackColor = Color.Red;
            btnShowEfficiency.BackColor = SystemColors.Control;
            dataGridViewProjects.Visible = true;
            chartEfficiency.Visible = false;
            LoadProjectData();
        }

        private void btnShowEfficiency_Click(object sender, EventArgs e)
        {
            btnShowProjects.BackColor = SystemColors.Control;
            btnShowEfficiency.BackColor = Color.Red;
            dataGridViewProjects.Visible = false;
            chartEfficiency.Visible = true;
            ShowEfficiencyChart();
        }
        private void LoadProjectData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Добавляем ProjectID в запрос, чтобы он был доступен для обновления
                string query = "SELECT ProjectID, ProjectName, StartDate, EndDate, Budget, DepartmentHead FROM Projects";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewProjects.DataSource = dt;

                // Скрываем столбец ProjectID, чтобы он не отображался в DataGridView
                dataGridViewProjects.Columns["ProjectID"].Visible = false;
            }
        }


        private void ShowEfficiencyChart()
        {
            string connectionString = "Data Source=94.241.174.143;Initial Catalog=ProjectManagement;User ID=sa;Password=<CK6d/ehm>";
            string query = @"SELECT e.FullName, 
                            COUNT(CASE WHEN t.Status = N'Завершена' THEN 1 END) * 100.0 / COUNT(t.TaskID) AS Efficiency
                     FROM Employees e
                     JOIN TaskEmployees te ON e.EmployeeID = te.EmployeeID
                     JOIN Tasks t ON te.TaskID = t.TaskID
                     GROUP BY e.FullName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Очистить существующие данные графика, если есть
                chartEfficiency.Series.Clear();

                // Добавить данные в Chart
                Series series = new Series("Efficiency");
                series.ChartType = SeriesChartType.Pie; // Устанавливаем тип графика на круговой

                foreach (DataRow row in dt.Rows)
                {
                    DataPoint point = new DataPoint();
                    point.AxisLabel = ""; // Отключаем текст на самом графике
                    point.YValues = new double[] { Convert.ToDouble(row["Efficiency"]) };

                    // Подписываем КПД в легенде
                    point.LegendText = $"{row["FullName"]}: {Convert.ToDouble(row["Efficiency"]):0.0}%";

                    series.Points.Add(point);
                }

                chartEfficiency.Series.Add(series);

                // Настройки легенды, если требуется отображение
                chartEfficiency.Legends[0].Enabled = true;

                // Дополнительные настройки для улучшения отображения
                series["PieLabelStyle"] = "Disabled"; // Отключаем метки на секторах
                chartEfficiency.Visible = true;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Projects", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataTable changes = ((DataTable)dataGridViewProjects.DataSource).GetChanges();
                if (changes != null)
                {
                    adapter.Update(changes);
                    ((DataTable)dataGridViewProjects.DataSource).AcceptChanges();
                }
            }
        }

        private void btnAddProject_Click_1(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            decimal budget = decimal.Parse(txtBudget.Text);
            string departmentHead = txtDepartmentHead.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Projects (ProjectName, StartDate, EndDate, Budget, DepartmentHead) 
                                 VALUES (@ProjectName, @StartDate, @EndDate, @Budget, @DepartmentHead)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjectName", projectName);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@Budget", budget);
                cmd.Parameters.AddWithValue("@DepartmentHead", departmentHead);

                cmd.ExecuteNonQuery();
                LoadProjectData(); // Обновление DataGridView после добавления
            }
        }

        private void txtBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, одного знака десятичной точки и клавиш управления (Backspace и Delete)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true; // Блокируем символ, если он не разрешен
            }
            // Разрешаем только один знак десятичной точки
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.Contains(e.KeyChar))
            {
                e.Handled = true; // Блокируем второй знак десятичной точки
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

