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
                Dictionary<string, object> enrollmentDictionary = new Dictionary<string, object>();
                enrollmentDictionary.Add("@idDiscipline", enrollment.IdDiscipline);
                enrollmentDictionary.Add("@idStudent", enrollment.IdStudent);
                enrollmentDictionary.Add("@missedClasses", enrollment.MissedClasses);
                enrollmentDictionary.Add("@idGrades", enrollment.IdGrades);

                db.NoQueryCommand(sql, enrollmentDictionary);
            }
        }

        public static List<Enrollment> GetAll()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM enrollment");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                List<Enrollment> enrollments = new List<Enrollment>();
                List<Object[]> objects = db.QueryCommand(sql);

                foreach (Object[] obj in objects)
                {
                    Enrollment enrollment = new Enrollment();
                    enrollment.IdDiscipline = (int)obj[0];
                    enrollment.IdStudent = (int)obj[1];
                    enrollment.MissedClasses = (int)obj[2];
                    enrollment.IdGrades = (int)obj[3];

                    enrollments.Add(enrollment);
                }
                return enrollments;
            }
        }

        public static Enrollment GetById(int idDiscipline, int idStudent)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM enrollment WHERE idDiscipline = @idDiscipline AND idStudent = @idStudent");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, int> enrollmentIdDict = new Dictionary<string, int>();
                enrollmentIdDict.Add("@idDiscipline", idDiscipline);
                enrollmentIdDict.Add("@idStudent", idStudent);

                Object[] objects = db.QueryCommand(sql, enrollmentIdDict);
                Enrollment enrollment = new Enrollment();

                enrollment.IdDiscipline = (int)objects[0];
                enrollment.IdStudent = (int)objects[1];
                enrollment.MissedClasses = (int)objects[2];
                enrollment.IdGrades = (int)objects[3];

                return enrollment;
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
                Dictionary<string, object> enrollmentDictionary = new Dictionary<string, object>();
                enrollmentDictionary.Add("@idDiscipline", enrollment.IdDiscipline);
                enrollmentDictionary.Add("@idStudent", enrollment.IdStudent);
                enrollmentDictionary.Add("@missedClasses", enrollment.MissedClasses);
                enrollmentDictionary.Add("@idGrades", enrollment.IdGrades);

                db.NoQueryCommand(sql, enrollmentDictionary);
            }
        }

        public static void Delete(int idDiscipline, int idStudent)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM enrollment WHERE idDiscipline = @idDiscipline AND idStudent = @idStudent");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> enrollmentIdDict = new Dictionary<string, object>();
                enrollmentIdDict.Add("@idDiscipline", idDiscipline);
                enrollmentIdDict.Add("@idStudent", idStudent);

                db.NoQueryCommand(sql, enrollmentIdDict);
            }
        }
    }
}
