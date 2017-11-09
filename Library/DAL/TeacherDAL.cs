using Library.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Library.DAL
{
    public static class TeacherDAL
    {   
        public static void CreateTable()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS teacher; " +
                "CREATE TABLE teacher (id int not null, name varchar(255) not null, condition varchar(255) not null, email varchar(45) not null, idSchool int not null)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Teacher teacher)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO teacher (id, name, condition, email, idSchool) VALUES " +
                "(@id, @name, @condition, @email, @idSchool)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {
                
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", teacher.Id);
                    command.Parameters.AddWithValue("@name", teacher.Name);
                    command.Parameters.AddWithValue("@condition", teacher.Condition);
                    command.Parameters.AddWithValue("@email", teacher.Email);
                    command.Parameters.AddWithValue("@idSchool", teacher.IdSchool);
                    int rows = command.ExecuteNonQuery();
                }
            }
        }

        public static List<Teacher> GetAll()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM teacher");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        List<Teacher> teachers = new List<Teacher>();

                        while (reader.Read())
                        {
                            Teacher teacher = new Teacher();

                            teacher.Id = reader.GetInt32(0);
                            teacher.Name = reader.GetString(1);
                            teacher.Condition = reader.GetString(2);
                            teacher.Email = reader.GetString(3);
                            teacher.IdSchool = reader.GetInt32(4);

                            teachers.Add(teacher);
                        }
                        return teachers;
                    }
                }
            }
        }

        public static Teacher GetById(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM teacher WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Teacher teacher = new Teacher();
                        while (reader.Read())
                        {
                            teacher.Id = reader.GetInt32(0);
                            teacher.Name = reader.GetString(1);
                            teacher.Condition = reader.GetString(2);
                            teacher.Email = reader.GetString(3);
                            teacher.IdSchool = reader.GetInt32(4);
                        }
                        return teacher;
                    }
                }
            }
        }

        public static void Update(Teacher teacher) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE teacher SET id = @id, name = @name, condition = @condition, " +
                "email = @email, idSchool = @idSchool WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {

                    command.Parameters.AddWithValue("@id", teacher.Id);
                    command.Parameters.AddWithValue("@name", teacher.Name);
                    command.Parameters.AddWithValue("@condition", teacher.Condition);
                    command.Parameters.AddWithValue("@email", teacher.Email);
                    command.Parameters.AddWithValue("@idSchool", teacher.IdSchool);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM student WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
