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
                Dictionary<string, object> disciplineDictionary = new Dictionary<string, object>();
                disciplineDictionary.Add("@id", discipline.Id);
                disciplineDictionary.Add("@name", discipline.Name);
                disciplineDictionary.Add("@credits", discipline.Credits);
                disciplineDictionary.Add("@year", discipline.Year);
                disciplineDictionary.Add("@semester", discipline.Semester);
                disciplineDictionary.Add("@startTime", discipline.StartTime);
                disciplineDictionary.Add("@endTime", discipline.EndTime);
                disciplineDictionary.Add("@classesHeld", discipline.ClassesHeld);
                disciplineDictionary.Add("@idTeacher", discipline.IdTeacher);
                disciplineDictionary.Add("@idCourse", discipline.IdCourse);

                db.NoQueryCommand(sql, disciplineDictionary);
            }
        }

        public static List<Discipline> GetAll()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM discipline");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                List<Discipline> disciplines = new List<Discipline>();
                List<Object[]> objects = db.QueryCommand(sql);

                foreach (Object[] obj in objects)
                {
                    Discipline discipline = new Discipline();
                    discipline.Id = (int)obj[0];
                    discipline.Name = (String)obj[1];
                    discipline.Credits = (int)obj[2];
                    discipline.Year = (int)obj[3];
                    discipline.Semester = (int)obj[4];
                    discipline.StartTime = (DateTime)obj[5];
                    discipline.EndTime = (DateTime)obj[6];
                    discipline.ClassesHeld = (int)obj[7];
                    discipline.IdTeacher = (int)obj[8];
                    discipline.IdCourse = (int)obj[9];

                    disciplines.Add(discipline);
                }
                return disciplines;
            }
        }

        public static Discipline GetById(int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM discipline WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Object[] objects = db.QueryCommand(sql, id);
                Discipline discipline = new Discipline();

                discipline.Id = (int)objects[0];
                discipline.Name = (String)objects[1];
                discipline.Credits = (int)objects[2];
                discipline.Year = (int)objects[3];
                discipline.Semester = (int)objects[4];
                discipline.StartTime = (DateTime)objects[5];
                discipline.EndTime = (DateTime)objects[6];
                discipline.ClassesHeld = (int)objects[7];
                discipline.IdTeacher = (int)objects[8];
                discipline.IdCourse = (int)objects[9];

                return discipline;
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
                Dictionary<string, object> disciplineDictionary = new Dictionary<string, object>();
                disciplineDictionary.Add("@id", discipline.Id);
                disciplineDictionary.Add("@name", discipline.Name);
                disciplineDictionary.Add("@credits", discipline.Credits);
                disciplineDictionary.Add("@year", discipline.Year);
                disciplineDictionary.Add("@semester", discipline.Semester);
                disciplineDictionary.Add("@startTime", discipline.StartTime);
                disciplineDictionary.Add("@endTime", discipline.EndTime);
                disciplineDictionary.Add("@classesHeld", discipline.ClassesHeld);
                disciplineDictionary.Add("@idTeacher", discipline.IdTeacher);
                disciplineDictionary.Add("@idCourse", discipline.IdCourse);

                db.NoQueryCommand(sql, disciplineDictionary);
            }
        }

        public static void Delete(int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM student WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> disciplineIdDict = new Dictionary<string, object>();
                disciplineIdDict.Add("@id", id);

                db.NoQueryCommand(sql, disciplineIdDict);
            }
        }
    }
}
