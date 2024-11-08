using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Practik
{
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            private bool AuthenticateUser(string username, string password, out string roleName)
            {
                roleName = null;

            // Подключение к базе данных
            string connectionString = "Data Source=94.241.174.143;Initial Catalog=ProjectManagement;User ID=sa;Password=<CK6d/ehm>";
            using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Запрос для проверки логина и пароля
                    string query = "SELECT R.RoleName FROM Users U " +
                                   "JOIN Employees E ON U.EmployeeID = E.EmployeeID " +
                                   "JOIN Roles R ON E.RoleID = R.RoleID " +
                                   "WHERE U.Username = @Username AND U.PasswordHash = @PasswordHash";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", (password));

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            roleName = result.ToString();
                            return true;
                        }
                    }
                }
                return false;
            }

           

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password, out string roleName))
            {
                // Открываем форму в зависимости от роли пользователя
                switch (roleName)
                {
                    case "Руководитель отдела":
                        new Rukovoditel().Show();
                        break;
                    case "Тимлид":
                        new TIMLID().Show();
                        break;
                    case "Разработчик":
                        new Razrab().Show();
                        break;
                    default:
                        MessageBox.Show("Роль не определена.");
                        return;
                }
                this.Hide(); // Скрыть форму входа
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Завершает работу всего приложения

        }
    }
    }



