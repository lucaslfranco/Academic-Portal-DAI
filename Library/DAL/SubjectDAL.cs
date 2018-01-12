using Library.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL
{
    public static class SubjectDAL
    {
        public static void CreateTable()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS subject; " +
                "CREATE TABLE subject (id int not null, name varchar(255) not null, credits int not null, year int not null," +
                "semester int not null, startTime datetime not null, endTime datetime not null, classesHeld int not null, idTeacher int not null, idCourse int not null " +
                "CONSTRAINT PK_subject PRIMARY KEY (id)," +
                "CONSTRAINT FK_subject_teacher FOREIGN KEY (idTeacher) REFERENCES teacher (id), " +
                "CONSTRAINT FK_subject_course FOREIGN KEY (idCourse) REFERENCES course (id) " +
                "ON UPDATE CASCADE ON DELETE CASCADE)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Subject subject)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO subject (id, name, credits, year, semester, startTime, endTime, classesHeld, idTeacher, idCourse) VALUES " +
                "(@id, @name, @credits, @year, @semester, @startTime, @endTime, @classesHeld, @idTeacher, @idCourse)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> subjectDictionary = new Dictionary<string, object>();
                subjectDictionary.Add("@id", subject.Id);
                subjectDictionary.Add("@name", subject.Name);
                subjectDictionary.Add("@credits", subject.Credits);
                subjectDictionary.Add("@year", subject.Year);
                subjectDictionary.Add("@semester", subject.Semester);
                subjectDictionary.Add("@startTime", subject.StartTime);
                subjectDictionary.Add("@endTime", subject.EndTime);
                subjectDictionary.Add("@classesHeld", subject.ClassesHeld);
                subjectDictionary.Add("@idTeacher", subject.IdTeacher);
                subjectDictionary.Add("@idCourse", subject.IdCourse);

                db.NoQueryCommand(sql, subjectDictionary);
            }
        }

        public static List<Subject> GetAll()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM subject");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                List<Subject> subjects = new List<Subject>();
                List<Object[]> objects = db.QueryCommand(sql);

                foreach (Object[] obj in objects)
                {
                    Subject subject = new Subject();
                    subject.Id = (int)obj[0];
                    subject.Name = (String)obj[1];
                    subject.Credits = (int)obj[2];
                    subject.Year = (int)obj[3];
                    subject.Semester = (int)obj[4];
                    subject.StartTime = (DateTime)obj[5];
                    subject.EndTime = (DateTime)obj[6];
                    subject.ClassesHeld = (int)obj[7];
                    subject.IdTeacher = (int)obj[8];
                    subject.IdCourse = (int)obj[9];

                    subjects.Add(subject);
                }
                return subjects;
            }
        }

        public static Subject GetById(int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM subject WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Object[] objects = db.QueryCommand(sql, id);
                Subject subject = new Subject();

                subject.Id = (int)objects[0];
                subject.Name = (String)objects[1];
                subject.Credits = (int)objects[2];
                subject.Year = (int)objects[3];
                subject.Semester = (int)objects[4];
                subject.StartTime = (DateTime)objects[5];
                subject.EndTime = (DateTime)objects[6];
                subject.ClassesHeld = (int)objects[7];
                subject.IdTeacher = (int)objects[8];
                subject.IdCourse = (int)objects[9];

                return subject;
            }
        }

        public static List<Student> GetStudentsBySubject(int idSubject)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT st.* " +
                "FROM student st " +
                "inner join enrollment e " +
                    "on st.id = e.idStudent " +
                "inner join subject s " +
                    "on e.idSubject = s.id " +
                "where s.id = @idSubject");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, int> subjectIdDict = new Dictionary<string, int>();
                subjectIdDict.Add("@idSubject", idSubject);

                List<Student> students = new List<Student>();
                List<Object[]> objects = db.QueryCommand(sql, subjectIdDict);

                foreach (Object[] obj in objects)
                {
                    Student student = new Student();

                    student.Id = (int)obj[0];
                    student.Name = (String)obj[1];
                    student.BirthDate = (DateTime)obj[2];
                    student.EnrollDate = (DateTime)obj[3];
                    student.Country = (String)obj[4];
                    student.Email = (String)obj[5];
                    student.Phone = (String)obj[6];
                   
                    students.Add(student);
                }
                return students;
            }
        }

        public static void Update(Subject subject)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE subject SET id = @id, name = @name, credits = @credits, " +
                "year = @year WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> subjectDictionary = new Dictionary<string, object>();
                subjectDictionary.Add("@id", subject.Id);
                subjectDictionary.Add("@name", subject.Name);
                subjectDictionary.Add("@credits", subject.Credits);
                subjectDictionary.Add("@year", subject.Year);
                subjectDictionary.Add("@semester", subject.Semester);
                subjectDictionary.Add("@startTime", subject.StartTime);
                subjectDictionary.Add("@endTime", subject.EndTime);
                subjectDictionary.Add("@classesHeld", subject.ClassesHeld);
                subjectDictionary.Add("@idTeacher", subject.IdTeacher);
                subjectDictionary.Add("@idCourse", subject.IdCourse);

                db.NoQueryCommand(sql, subjectDictionary);
            }
        }

        public static void Delete(int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM student WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> subjectIdDict = new Dictionary<string, object>();
                subjectIdDict.Add("@id", id);

                db.NoQueryCommand(sql, subjectIdDict);
            }
        }
    }
}
