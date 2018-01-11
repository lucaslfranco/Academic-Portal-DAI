using Library.BL;
using Library.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Library.DAL {
    public static class StudentDAL {

        public static void CreateTable() {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS student; " +
                "CREATE TABLE student (id int not null auto_increment, name varchar(255) not null, birthDate datetime not null, " +
                    "enrollDate datetime not null, country varchar(45) not null, email varchar(45) not null, phone varchar(45), " +
                    "CONSTRAINT PK_student PRIMARY KEY (id))");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Student student) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO student (id, name, birthDate, enrollDate, country, email, phone) VALUES " +
                "(@id, @name, @birthDate, @enrollDate, @country, @email, @phone)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> studentDictionary = new Dictionary<string, object>();
                studentDictionary.Add("@id", student.Id);
                studentDictionary.Add("@name", student.Name);
                studentDictionary.Add("@birthDate", student.BirthDate);
                studentDictionary.Add("@enrollDate", student.EnrollDate);
                studentDictionary.Add("@country", student.Country);
                studentDictionary.Add("@email", student.Email);
                studentDictionary.Add("@phone", student.Phone);

                db.NoQueryCommand(sql, studentDictionary);
            }
        }

        public static List<Student> GetAll() {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM student");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                List<Student> students = new List<Student>();
                List<Object[]> objects = db.QueryCommand(sql);

                foreach (Object[] obj in objects) {
                    Student student = new Student();
                    student.Id = (int) obj[0];
                    student.Name = (String) obj[1];
                    student.BirthDate = (DateTime) obj[2];
                    student.EnrollDate = (DateTime) obj[3];
                    student.Country = (String) obj[4];
                    student.Email = (String) obj[5];
                    student.Phone = (String) obj[6];
                
                    students.Add(student);
                 }

                return students;
            }
        }

        public static Student GetById(int id) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM student WHERE id=@id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Student student = null;
                Object[] objects = db.QueryCommand(sql, id);

                if (objects != null)
                {
                    student = new Student();
                    student.Id = (int)objects[0];
                    student.Name = (String)objects[1];
                    student.BirthDate = (DateTime)objects[2];
                    student.EnrollDate = (DateTime)objects[3];
                    student.Country = (String)objects[4];
                    student.Email = (String)objects[5];
                    student.Phone = (String)objects[6];
                }
                return student;
            }
        }

        public static List<Subject> GetSubjectsByStudent(int idStudent)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT s.* " +
                "FROM subject s " +
                "inner join enrollment e " +
                    "on s.id = e.idSubject " +
                "inner join student st " +
                    "on e.idStudent = st.id " +
                "where st.id = @idStudent");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, int> enrollmentIdDict = new Dictionary<string, int>();
                enrollmentIdDict.Add("@idStudent", idStudent);

                List<Subject> subjects = new List<Subject>();
                List<Object[]> objects = db.QueryCommand(sql, enrollmentIdDict);

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

        public static List<Message> GetMessagesByStudent(int idStudent)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT m.* " +
                "FROM subject s " +
                "inner join message m " +
                    "on s.id = m.idSubject " +
                "inner join enrollment e " +
                    "on s.id = e.idSubject " +
                "inner join student st " +
                    "on st.id = e.idStudent " +
                "where st.id = @idStudent");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, int> messagesIdDict = new Dictionary<string, int>();
                messagesIdDict.Add("@idStudent", idStudent);

                List<Message> messages = new List<Message>();
                List<Object[]> objects = db.QueryCommand(sql, messagesIdDict);

                foreach (Object[] obj in objects)
                {
                    Message message = new Message();
                    message.Id = (int)obj[0];
                    message.Title = (String)obj[1];
                    message.Content = (String)obj[2];
                    message.Time = (DateTime)obj[3];
                    message.IdSubject = (int)obj[4];

                    messages.Add(message);
                }
                return messages;
            }
        }

        public static void Update(Student student) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE student SET id = @id, name = @name, birthDate = @birthDate, enrollDate = @enrollDate, " +
                "country = @country, email = @email, phone = @phone WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                Dictionary<string, object> studentDictionary = new Dictionary<string, object>();
                studentDictionary.Add("@id", student.Id);
                studentDictionary.Add("@name", student.Name);
                studentDictionary.Add("@birthDate", student.BirthDate);
                studentDictionary.Add("@enrollDate", student.EnrollDate);
                studentDictionary.Add("@country", student.Country);
                studentDictionary.Add("@email", student.Email);
                studentDictionary.Add("@phone", student.Phone);

                db.NoQueryCommand(sql, studentDictionary);
            }
        }

        public static void Delete(int id) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM student WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                Dictionary<string, object> studentIdDict = new Dictionary<string, object>();
                studentIdDict.Add("@id", id);

                db.NoQueryCommand(sql, studentIdDict);        
            }
        }   
    }
}
