using Library.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL
{
    public static class GradesDAL
    {
        public static void CreateTable()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS grades; " +
                "CREATE TABLE grades (id int not null IDENTITY(1,1), grade1 float not null, grade2 float, grade3 float, grade4 float " +
                "CONSTRAINT PK_grades PRIMARY KEY (id))");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static int Create(Grades grades)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO grades (grade1, grade2, grade3, grade4) " +
                "OUTPUT INSERTED.id " +
                "VALUES (@grade1, @grade2, @grade3, @grade4)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> gradesDictionary = new Dictionary<string, object>();
                gradesDictionary.Add("@grade1", grades.Grade1);
                gradesDictionary.Add("@grade2", grades.Grade2);
                gradesDictionary.Add("@grade3", grades.Grade3);
                gradesDictionary.Add("@grade4", grades.Grade4);

                int insertedId = db.NoQueryCommandScalar(sql, gradesDictionary);
                return insertedId;
            }
        }

        public static List<Grades> GetAll()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM grades");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                List<Grades> gradesList = new List<Grades>();
                List<Object[]> objects = db.QueryCommand(sql);

                foreach (Object[] obj in objects)
                {
                    Grades grades = new Grades();
                    grades.Id = (int)obj[0];
                    grades.Grade1 = (obj[1] != null) ? (double)obj[1] : 0;
                    grades.Grade2 = (obj[2] != null) ? (double)obj[2] : 0;
                    grades.Grade3 = (obj[3] != null) ? (double)obj[3] : 0;
                    grades.Grade4 = (obj[4] != null) ? (double)obj[4] : 0;

                    gradesList.Add(grades);
                }
                return gradesList;
            }
        }

        public static Grades GetById(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM grades WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Object[] objects = db.QueryCommand(sql, id);
                Grades grades = new Grades();

                grades.Id = (int)objects[0];

                // Ternary operator to assign only valid values to grades
                grades.Grade1 = objects[1].GetType().ToString() != "System.DBNull" ? (double) objects[1] : 0;
                grades.Grade2 = objects[2].GetType().ToString() != "System.DBNull" ? (double) objects[2] : 0;
                grades.Grade3 = objects[3].GetType().ToString() != "System.DBNull" ? (double) objects[3] : 0;
                grades.Grade4 = objects[4].GetType().ToString() != "System.DBNull" ? (double) objects[4] : 0;

                return grades;
            }
        }

        public static void Update(Grades grades)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE grades SET grade1 = @grade1, grade2 = @grade2, " +
                "grade3 = @grade3, grade4 = @grade4 WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> gradesDictionary = new Dictionary<string, object>();
                gradesDictionary.Add("@id", grades.Id);
                gradesDictionary.Add("@grade1", grades.Grade1);
                gradesDictionary.Add("@grade2", grades.Grade2);
                gradesDictionary.Add("@grade3", grades.Grade3);
                gradesDictionary.Add("@grade4", grades.Grade4);

                db.NoQueryCommand(sql, gradesDictionary);
            }
        }

        public static void Delete(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM grades WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> gradesIdDict = new Dictionary<string, object>();
                gradesIdDict.Add("@id", id);

                db.NoQueryCommand(sql, gradesIdDict);
            }
        }
    }
}
