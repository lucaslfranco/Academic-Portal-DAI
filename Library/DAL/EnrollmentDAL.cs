using Library.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Library.DAL
{
    public static class EnrollmentDAL
    {
        public static void CreateTable()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS enrollment; " +
                "CREATE TABLE enrollment (idDiscipline int not null, idStudent int not null, missedClasses int not null, idGrades int not null)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Enrollment enrollment)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO enrollment (idDiscipline, idStudent, missedClasses, idGrades) VALUES " +
                "(@idDiscipline, @idStudent, @missedClasses, @idGrades)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@idDiscipline", enrollment.IdDiscipline);
                    command.Parameters.AddWithValue("@idStudent", enrollment.IdStudent);
                    command.Parameters.AddWithValue("@missedClasses", enrollment.MissedClasses);
                    command.Parameters.AddWithValue("@idGrades", enrollment.IdGrades);
                    int rows = command.ExecuteNonQuery();
                }
            }
        }

        public static List<Enrollment> GetAll()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM enrollment");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        List<Enrollment> enrollments = new List<Enrollment>();

                        while (reader.Read())
                        {
                            Enrollment enrollment = new Enrollment();

                            enrollment.IdDiscipline = reader.GetInt32(0);
                            enrollment.IdStudent = reader.GetInt32(1);
                            enrollment.MissedClasses = reader.GetInt32(2);
                            enrollment.IdGrades = reader.GetInt32(3);

                            enrollments.Add(enrollment);
                        }
                        return enrollments;
                    }
                }
            }
        }

        public static Enrollment GetById(Enrollment enrollment)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM enrollment WHERE idDiscipline = @idDiscipline AND idStudent = @idStudent");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@idDiscipline", enrollment.IdDiscipline);
                    command.Parameters.AddWithValue("@idStudent", enrollment.IdStudent);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Enrollment dbEnrollment = new Enrollment();
                        while (reader.Read())
                        {
                            dbEnrollment.IdDiscipline = reader.GetInt32(0);
                            dbEnrollment.IdStudent = reader.GetInt32(1);
                            dbEnrollment.MissedClasses = reader.GetInt32(2);
                            dbEnrollment.IdGrades = reader.GetInt32(3);
                        }
                        return enrollment;
                    }
                }
            }
        }

        public static void Update(Enrollment enrollment)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE enrollment SET idDiscipline = @idDiscipline, idStudent = @idStudent, missedClasses = @missedClasses, " +
                "idGrades = @idGrades WHERE idDiscipline = @idDiscipline");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@idDiscipline", enrollment.IdDiscipline);
                    command.Parameters.AddWithValue("@idStudent", enrollment.IdStudent);
                    command.Parameters.AddWithValue("@missedClasses", enrollment.MissedClasses);
                    command.Parameters.AddWithValue("@idGrades", enrollment.IdGrades);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(Enrollment enrollment)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM enrollment WHERE idDiscipline = @idDiscipline AND idStudent = @idStudent");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@idDiscipline", enrollment.IdDiscipline);
                    command.Parameters.AddWithValue("@idDiscipline", enrollment.IdStudent);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
