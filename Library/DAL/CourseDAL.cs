using Library.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Library.DAL
{
    public static class CourseDAL
    {
        public static void CreateTable()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS course; " +
                "CREATE TABLE course (id int not null IDENTITY(1,1), name varchar(255) not null, degree varchar(255) not null, durationYears int not null, idSchool int not null " +
                "CONSTRAINT PK_course PRIMARY KEY (id), " +
                "CONSTRAINT FK_course_school FOREIGN KEY (idSchool) REFERENCES school (id) " +
                "ON UPDATE CASCADE ON DELETE CASCADE)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Course course)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO course (name, degree, durationYears, idSchool) VALUES " +
                "(@name, @degree, @durationYears, @idSchool)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@name", course.Name);
                    command.Parameters.AddWithValue("@degree", course.Degree);
                    command.Parameters.AddWithValue("@durationYears", course.DurationYears);
                    command.Parameters.AddWithValue("@idSchool", course.IdSchool);
                    int rows = command.ExecuteNonQuery();
                }
            }
        }

        public static List<Course> GetAll()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM course");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        List<Course> courses = new List<Course>();

                        while (reader.Read())
                        {
                            Course course = new Course();

                            course.Id = reader.GetInt32(0);
                            course.Name = reader.GetString(1);
                            course.Degree = reader.GetString(2);
                            course.DurationYears = reader.GetInt32(3);
                            course.IdSchool = reader.GetInt32(4);

                            courses.Add(course);
                        }
                        return courses;
                    }
                }
            }
        }

        public static Course GetById(int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM course WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Course course = new Course();
                        while (reader.Read())
                        {
                            course.Id = reader.GetInt32(0);
                            course.Name = reader.GetString(1);
                            course.Degree = reader.GetString(2);
                            course.DurationYears = reader.GetInt32(3);
                            course.IdSchool = reader.GetInt32(4);
                        }
                        return course;
                    }
                }
            }
        }

        public static void Update(Course course)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE course SET name = @name, degree = @degree, " +
                "durationYears = @durationYears, idSchool = @idSchool WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {

                    command.Parameters.AddWithValue("@id", course.Id);
                    command.Parameters.AddWithValue("@name", course.Name);
                    command.Parameters.AddWithValue("@degree", course.Degree);
                    command.Parameters.AddWithValue("@durationYears", course.DurationYears);
                    command.Parameters.AddWithValue("@idSchool", course.IdSchool);
                    command.ExecuteNonQuery();
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
