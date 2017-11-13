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
                "CREATE TABLE student (id int not null, name varchar(255) not null, birthDate datetime not null, " +
                    "enrollDate datetime not null, country varchar(45) not null, email varchar(45) not null, phone varchar(45))");
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
                Object[] objects = db.QueryCommand(sql, id);
                Student student = new Student();

                student.Id = (int) objects[0];
                student.Name = (String) objects[1];
                student.BirthDate = (DateTime) objects[2];
                student.EnrollDate = (DateTime) objects[3];
                student.Country = (String) objects[4];
                student.Email = (String) objects[5];
                student.Phone = (String) objects[6];

                return student;
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
