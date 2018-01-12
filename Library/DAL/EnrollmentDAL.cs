using Library.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL
{
    public static class EnrollmentDAL
    {
        public static void CreateTable()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS enrollment; " +
                "CREATE TABLE enrollment (idSubject int not null, idStudent int not null, missedClasses int not null, idGrades int not null " +
                "CONSTRAINT PK_enrollment PRIMARY KEY (idSubject, idStudent))");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Enrollment enrollment)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO enrollment (idSubject, idStudent, missedClasses, idGrades) VALUES " +
                "(@idSubject, @idStudent, @missedClasses, @idGrades)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> enrollmentDictionary = new Dictionary<string, object>();
                enrollmentDictionary.Add("@idSubject", enrollment.IdSubject);
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
                    enrollment.IdSubject = (int)obj[0];
                    enrollment.IdStudent = (int)obj[1];
                    enrollment.MissedClasses = (int)obj[2];
                    enrollment.IdGrades = (int)obj[3];

                    enrollments.Add(enrollment);
                }
                return enrollments;
            }
        }

        public static Enrollment GetById(int idSubject, int idStudent)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM enrollment WHERE idSubject = @idSubject AND idStudent = @idStudent");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, int> enrollmentIdDict = new Dictionary<string, int>();
                enrollmentIdDict.Add("@idSubject", idSubject);
                enrollmentIdDict.Add("@idStudent", idStudent);

                Object[] objects = db.QueryCommand(sql, enrollmentIdDict)[0];

                Enrollment enrollment = new Enrollment();

                enrollment.IdSubject = (int)objects[0];
                enrollment.IdStudent = (int)objects[1];
                enrollment.MissedClasses = (int)objects[2];
                enrollment.IdGrades = (int)objects[3];

                return enrollment;
            }
        }

        public static void Update(Enrollment enrollment)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE enrollment SET missedClasses = @missedClasses, " +
                "idGrades = @idGrades WHERE idSubject = @idSubject AND idStudent = @idStudent");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> enrollmentDictionary = new Dictionary<string, object>();
                enrollmentDictionary.Add("@idSubject", enrollment.IdSubject);
                enrollmentDictionary.Add("@idStudent", enrollment.IdStudent);
                enrollmentDictionary.Add("@missedClasses", enrollment.MissedClasses);
                enrollmentDictionary.Add("@idGrades", enrollment.IdGrades);

                db.NoQueryCommand(sql, enrollmentDictionary);
            }
        }

        public static void Delete(int idSubject, int idStudent)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM enrollment WHERE idSubject = @idSubject AND idStudent = @idStudent");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> enrollmentIdDict = new Dictionary<string, object>();
                enrollmentIdDict.Add("@idSubject", idSubject);
                enrollmentIdDict.Add("@idStudent", idStudent);

                db.NoQueryCommand(sql, enrollmentIdDict);
            }
        }
    }
}
