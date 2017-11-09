using ClassLibrary.BL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibrary.DAL {

    public static class StudentDAL {

        public static void NoQueryCommand(String sql) {

            using (SqlConnection connection = DB.InitializeConnection()) {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection)) {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void CreateTable() {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS student; " +
                "CREATE TABLE student (id int not null, name varchar(255) not null, birthDate varchar(45) not null, " +
                    "enrollDate varchar(45) not null, country varchar(45) not null, email varchar(45) not null, phone varchar(45))");
            String sql = stringBuilder.ToString();

            NoQueryCommand(sql);
        }

        public static void Create(Student student) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO student (id, name, birthDate, enrollDate, country, email, phone) VALUES " +
                "(@id, @name, @birthDate, @birthDate, @country, @email, @phone)");
            String sql = stringBuilder.ToString();

            using (SqlConnection connection = DB.InitializeConnection()) {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection)) {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;
                    command.Parameters.Add("@name", SqlDbType.VarChar, 255).Value = student.Name;
                    command.Parameters.Add("@birthDate", SqlDbType.VarChar, 45).Value = student.Name;
                    command.Parameters.Add("@enrollDate", SqlDbType.VarChar, 45).Value = student.Name;
                    command.Parameters.Add("@country", SqlDbType.VarChar, 45).Value = student.Name;
                    command.Parameters.Add("@email", SqlDbType.VarChar, 45).Value = student.Name;
                    command.Parameters.Add("@phone", SqlDbType.VarChar, 45).Value = student.Name;
                    int rows = command.ExecuteNonQuery();
                }
            }
        }

        public static void GetAll() {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM student");
            String sql = stringBuilder.ToString();

            using (SqlConnection connection = DB.InitializeConnection()) {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Console.WriteLine("ID: {0} \tNome: {1}", reader.GetInt32(0), reader.GetString(1));
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        public static void GetById(int id) {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM student WHERE id=@id");
            String sql = stringBuilder.ToString();

            using (SqlConnection connection = DB.InitializeConnection()) {
                connection.Open();
                
                using (SqlCommand command = new SqlCommand(sql, connection)) {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Console.WriteLine("ID: {0} \tNome: {1}", reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
        }

        public static void Update(Student student) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE student SET name = @name where id = @id");
            String sql = stringBuilder.ToString();

            using (SqlConnection connection = DB.InitializeConnection()) {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection)) {

                    command.Parameters.Add("@name", SqlDbType.VarChar, 45).Value = student.Name;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(Student student) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM student WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (SqlConnection connection = DB.InitializeConnection()) {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection)) {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;
                    command.ExecuteNonQuery();
                }
            }
        }   


        /*   public static void initializeDB() {
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
