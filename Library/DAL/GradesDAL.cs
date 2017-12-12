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
                "CREATE TABLE grades (id int not null, grade1 float not null, grade2 float, grade3 float, grade4 float " +
                "CONSTRAINT PK_grades PRIMARY KEY (id))");
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
                Dictionary<string, object> gradesDictionary = new Dictionary<string, object>();
                gradesDictionary.Add("@id", grades.Id);
                gradesDictionary.Add("@grade1", grades.Grade1);
                gradesDictionary.Add("@grade2", grades.Grade2);
                gradesDictionary.Add("@grade3", grades.Grade3);
                gradesDictionary.Add("@grade4", grades.Grade4);
                db.NoQueryCommand(sql, gradesDictionary);
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
                    grades.Grade1 = (double)obj[1];
                    grades.Grade2 = (double)obj[2];
                    grades.Grade3 = (double)obj[3];
                    grades.Grade4 = (double)obj[4];

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
                grades.Grade1 = (double)objects[1];
                grades.Grade2 = (double)objects[2];
                grades.Grade3 = (double)objects[3];
                grades.Grade4 = (double)objects[4];

                return grades;
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
