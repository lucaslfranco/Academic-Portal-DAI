using Library.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Library.DAL {
    public static class StudentDAL {

        public static void CreateTable() {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS student; " +
                "CREATE TABLE student (id int not null, name varchar(255) not null, birthDate varchar(45) not null, " +
                    "enrollDate varchar(45) not null, country varchar(45) not null, email varchar(45) not null, phone varchar(45))");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Student student) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO student (id, name, birthDate, enrollDate, country, email, phone) VALUES " +
                "(@id, @name, @birthDate, @birthDate, @country, @email, @phone)");
            String sql = stringBuilder.ToString();


            using (DB db = new DB())
            {
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", student.Id);
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@birthDate", student.BirthDate);
                    command.Parameters.AddWithValue("@enrollDate", student.EnrollDate);
                    command.Parameters.AddWithValue("@country", student.Country);
                    command.Parameters.AddWithValue("@email", student.Email);
                    command.Parameters.AddWithValue("@phone", student.Phone);
                    int rows = command.ExecuteNonQuery();
                }
            }
        }

        public static List<Student> GetAll() {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM student");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                using (SqlCommand command = new SqlCommand(sql, db.Connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {

                        List<Student> students = new List<Student>();

                        while (reader.Read()) {
                            Student student = new Student();

                            student.Id = reader.GetInt32(0);
                            student.Name = reader.GetString(1);
                            student.BirthDate = reader.GetString(2);
                            student.EnrollDate = reader.GetString(3);
                            student.Country = reader.GetString(4);
                            student.Email = reader.GetString(5);
                            student.Phone = reader.GetString(6);

                            students.Add(student);
                        }
                        return students;
                    }
                }
            }
        }

        public static Student GetById(int id) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM student WHERE id=@id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {
                
                using (SqlCommand command = new SqlCommand(sql, db.Connection)) {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        Student student = new Student();
                        while (reader.Read()) {
                            student.Id = reader.GetInt32(0);
                            student.Name = reader.GetString(1);
                            student.BirthDate = reader.GetString(2);
                            student.EnrollDate = reader.GetString(3);
                            student.Country = reader.GetString(4);
                            student.Email = reader.GetString(5);
                            student.Phone = reader.GetString(6);
                        }
                        return student;
                    }
                }
            }
        }

        public static void Update(Student student) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE student SET id = @id, name = @name, birthDate = @birthDate, enrollDate = @enrollDate, " +
                "country = @country, email = @email, phone = @phone WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                using (SqlCommand command = new SqlCommand(sql, db.Connection)) {

                    command.Parameters.AddWithValue("@id", student.Id);
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@birthDate", student.BirthDate);
                    command.Parameters.AddWithValue("@enrollDate", student.EnrollDate);
                    command.Parameters.AddWithValue("@country", student.Country);
                    command.Parameters.AddWithValue("@email", student.Email);
                    command.Parameters.AddWithValue("@phone", student.Phone);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM student WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                using (SqlCommand command = new SqlCommand(sql, db.Connection)) {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }   

        /*   public static void DB() {
               Console.WriteLine("Conexão com BD");
               SQLiteConnection.CreateFile("MyDB.sqlite");
               SQLiteConnection sqlConnection = new SQLiteConnection("Data Source=MyDB.sqlite;");
               sqlConnection.Open();

               String sql = "create table Pessoa (nome varchar(45), idade int)";
               SQLiteCommand sqlCommand = new SQLiteCommand(sql, sqlConnection);
               sqlCommand.ExecuteNonQuery();

               sql = "insert into Pessoa (nome, idade) values ('pessoa01', 33)";
               sqlCommand = new SQLiteCommand(sql, sqlConnection);
               sqlCommand.ExecuteNonQuery();

               sql = "insert into Pessoa (nome, idade) values ('pessoa02', 21)";
               sqlCommand = new SQLiteCommand(sql, sqlConnection);
               sqlCommand.ExecuteNonQuery();

               sql = "insert into Pessoa (nome, idade) values ('pessoa03', 51)";
               sqlCommand = new SQLiteCommand(sql, sqlConnection);
               sqlCommand.ExecuteNonQuery();

               sql = "select * from Pessoa order by nome asc";
               sqlCommand = new SQLiteCommand(sql, sqlConnection);

               SQLiteDataReader reader = sqlCommand.ExecuteReader();
               while (reader.Read())
                   Console.WriteLine("Nome: " + reader["nome"] + "\tIdade: " + reader["idade"]);

               sqlConnection.Close();
           }
       */
    }
}
