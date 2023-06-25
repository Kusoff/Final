using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Final
{
    internal class DatabaseManager
    {
        string connectionString = "Data Source=WIN-B0PAN2P8O26\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";
        public void AddStudent(Student student)  // Метод для добавления нового студента в базу данных
        {
            using (SqlConnection connection = new SqlConnection(connectionString))  // Создаем новое подключение к базе данных
            {
                connection.Open();  // Открываем подключение

                string query = "INSERT INTO Students (FullName, DateOfBirth, Gender, Address, Passport, TotalScore, GroupName, Money) " +
                               "VALUES (@FullName, @DateOfBirth, @Gender, @Address, @Passport, @TotalScore, @GroupName, @Money)";
                // SQL-запрос для вставки новой строки с данными студента в таблицу Students

                SqlCommand command = new SqlCommand(query, connection);  // Создаем команду SQL с запросом и подключением
                command.Parameters.AddWithValue("@FullName", student.FullName);  // Добавляем параметры к команде 
                command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", student.Gender);
                command.Parameters.AddWithValue("@Address", student.Address);
                command.Parameters.AddWithValue("@Passport", student.Passport);
                command.Parameters.AddWithValue("@TotalScore", student.TotalScore);
                command.Parameters.AddWithValue("@GroupName", student.GroupName);
                command.Parameters.AddWithValue("@Money", student.Money);

                command.ExecuteNonQuery();  // Выполняем команду для добавления нового студента в базу данных
            }
        }

        public static bool DeleteStudent(int studentId)  // Метод для удаления студента из базы данных по его идентификатору
        {
            string connectionString = "Data Source=WIN-B0PAN2P8O26\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))  // Создаем новое подключение к базе данных
                try
                {

                    connection.Open();  // Открываем подключение

                    string query = "DELETE FROM Students WHERE Id = @StudentId";  // SQL-запрос для удаления студента по его идентификатору

                    SqlCommand command = new SqlCommand(query, connection);  // Создаем команду SQL с запросом и подключением
                    command.Parameters.AddWithValue("@StudentId", studentId);  // Добавляем параметр к команде

                    int rowsAffected = command.ExecuteNonQuery();  // приравниваем затронутые в результате выполнения запроса строчки к переменной

                    return rowsAffected > 0; //проверяет, были ли затронуты строки при удалении. Возвращает true или false

                }
                catch (Exception ex)
                {
                    // Обработка ошибок при удалении студента
                    // Можно добавить логирование ошибки или другую обработку

                    return false; // Возвращаем false в случае ошибки
                }
        }

    }
}
