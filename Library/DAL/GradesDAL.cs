using Library.BL;
using Library.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Library.DAL
{
    public static class GradesDAL
    {
        public static void CreateTable()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS grades; " +
                "CREATE TABLE grades (id int not null, grade1 varchar(255) not null, grade2 varchar(255) not null, grade3 varchar(45) not null, grade4 int not null)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Grades grades)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO grades (id, grade1, grade2, grade3, grade4) VALUES " +
                "(@id, @grade1, @grade2, @grade3, @grade4)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", grades.Id);
                    command.Parameters.AddWithValue("@grade1", grades.Grade1);
                    command.Parameters.AddWithValue("@grade2", grades.Grade2);
                    command.Parameters.AddWithValue("@grade3", grades.Grade3);
                    command.Parameters.AddWithValue("@grade4", grades.Grade4);
                    int rows = command.ExecuteNonQuery();
                }
            }
        }

        public static List<Grades> GetAll()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM grades");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        List<Grades> gradesList = new List<Grades>();

                        while (reader.Read())
                        {
                            Grades grades = new Grades();

                            grades.Id = reader.GetInt32(0);
                            grades.Grade1 = reader.GetDouble(1);
                            grades.Grade2 = reader.GetDouble(2);
                            grades.Grade3 = reader.GetDouble(3);
                            grades.Grade4 = reader.GetDouble(4);

                            gradesList.Add(grades);
                        }
                        return gradesList;
                    }
                }
            }
        }

        public static Grades GetById(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM grades WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Grades grades = new Grades();
                        while (reader.Read())
                        {
                            grades.Id = reader.GetInt32(0);
                            grades.Grade1 = reader.GetDouble(1);
                            grades.Grade2 = reader.GetDouble(2);
                            grades.Grade3 = reader.GetDouble(3);
                            grades.Grade4 = reader.GetDouble(4);
                        }
                        return grades;
                    }
                }
            }
        }

        public static void Update(Grades grades)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE grades SET id = @id, grade1 = @grade1, grade2 = @grade2, " +
                "grade3 = @grade3, grade4 = @grade4 WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {

                    command.Parameters.AddWithValue("@id", grades.Id);
                    command.Parameters.AddWithValue("@grade1", grades.Grade1);
                    command.Parameters.AddWithValue("@grade2", grades.Grade2);
                    command.Parameters.AddWithValue("@grade3", grades.Grade3);
                    command.Parameters.AddWithValue("@grade4", grades.Grade4);
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
