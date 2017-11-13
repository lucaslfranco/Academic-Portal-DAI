using Library.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Library.DAL
{
    public static class DisciplineDAL
    {
        public static void CreateTable()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS discipline; " +
                "CREATE TABLE discipline (id int not null, name varchar(255) not null, credits int not null, year int not null," +
                "semester int not null, startTime datetime not null, endTime datetime not null, classesHeld int not null, idTeacher int not null, idCourse int not null)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Discipline discipline)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO discipline (id, name, credits, year, semester, startTime, endTime, classesHeld, idTeacher, idCourse) VALUES " +
                "(@id, @name, @credits, @year, @semester, @startTime, @endTime, @classesHeld, @idTeacher, @idCourse)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", discipline.Id);
                    command.Parameters.AddWithValue("@name", discipline.Name);
                    command.Parameters.AddWithValue("@credits", discipline.Credits);
                    command.Parameters.AddWithValue("@year", discipline.Year);
                    command.Parameters.AddWithValue("@semester", discipline.Semester);
                    command.Parameters.AddWithValue("@startTime", discipline.StartTime);
                    command.Parameters.AddWithValue("endTime", discipline.EndTime);
                    command.Parameters.AddWithValue("classesHeld", discipline.ClassesHeld);
                    command.Parameters.AddWithValue("idTeacher", discipline.IdTeacher);
                    command.Parameters.AddWithValue("idCourse", discipline.IdCourse);
                    int rows = command.ExecuteNonQuery();
                }
            }
        }

        public static List<Discipline> GetAll()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM discipline");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Discipline> disciplines = new List<Discipline>();

                        while (reader.Read())
                        {
                            Discipline discipline = new Discipline();

                            discipline.Id = reader.GetInt32(0);
                            discipline.Name = reader.GetString(1);
                            discipline.Credits = reader.GetInt32(2);
                            discipline.Year = reader.GetInt32(3);
                            discipline.Semester = reader.GetInt32(4);
                            discipline.StartTime = reader.GetDateTime(5);
                            discipline.EndTime = reader.GetDateTime(6);
                            discipline.ClassesHeld = reader.GetInt32(7);
                            discipline.IdTeacher = reader.GetInt32(8);
                            discipline.IdCourse = reader.GetInt32(9);

                            disciplines.Add(discipline);
                        }
                        return disciplines;
                    }
                }
            }
        }

        public static Discipline GetById(int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM discipline WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Discipline discipline = new Discipline();
                        while (reader.Read())
                        {
                            discipline.Id = reader.GetInt32(0);
                            discipline.Name = reader.GetString(1);
                            discipline.Credits = reader.GetInt32(2);
                            discipline.Year = reader.GetInt32(3);
                            discipline.Semester = reader.GetInt32(4);
                            discipline.StartTime = reader.GetDateTime(5);
                            discipline.EndTime = reader.GetDateTime(6);
                            discipline.ClassesHeld = reader.GetInt32(7);
                            discipline.IdTeacher = reader.GetInt32(8);
                            discipline.IdCourse = reader.GetInt32(9);
                        }
                        return discipline;
                    }
                }
            }
        }

        public static void Update(Discipline discipline)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE discipline SET id = @id, name = @name, credits = @credits, " +
                "year = @year WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", discipline.Id);
                    command.Parameters.AddWithValue("@name", discipline.Name);
                    command.Parameters.AddWithValue("@credits", discipline.Credits);
                    command.Parameters.AddWithValue("@year", discipline.Year);
                    command.Parameters.AddWithValue("@semester", discipline.Semester);
                    command.Parameters.AddWithValue("@startTime", discipline.StartTime);
                    command.Parameters.AddWithValue("endTime", discipline.EndTime);
                    command.Parameters.AddWithValue("classesHeld", discipline.ClassesHeld);
                    command.Parameters.AddWithValue("idTeacher", discipline.IdTeacher);
                    command.Parameters.AddWithValue("idCourse", discipline.IdCourse);
                }
            }
        }

        public static void Delete(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM student WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
