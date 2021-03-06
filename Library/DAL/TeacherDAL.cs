﻿using Library.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL
{
    public static class TeacherDAL
    {   
        public static void CreateTable()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS teacher; " +
                "CREATE TABLE teacher (id int not null, name varchar(255) not null, condition varchar(255) not null, email varchar(45) not null, idSchool int not null, " +
                "CONSTRAINT PK_teacher PRIMARY KEY (id), " +
                "CONSTRAINT FK_teacher_school FOREIGN KEY (idSchool) REFERENCES school (id) " +
                "ON UPDATE CASCADE ON DELETE CASCADE)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Teacher teacher)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO teacher (id, name, condition, email, idSchool) VALUES " +
                "(@id, @name, @condition, @email, @idSchool)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) 
            {
                Dictionary<string, object> teacherDictionary = new Dictionary<string, object>();
                teacherDictionary.Add("@id", teacher.Id);
                teacherDictionary.Add("@name", teacher.Name);
                teacherDictionary.Add("@condition", teacher.Condition);
                teacherDictionary.Add("@email", teacher.Email);
                teacherDictionary.Add("@idSchool", teacher.IdSchool);

                db.NoQueryCommand(sql, teacherDictionary);
            }
        }

        public static List<Teacher> GetAll()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM teacher");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                List<Teacher> teachers = new List<Teacher>();
                List<Object[]> objects = db.QueryCommand(sql);

                foreach (Object[] obj in objects)
                {
                    Teacher teacher = new Teacher();
                    teacher.Id = (int)obj[0];
                    teacher.Name = (String)obj[1];
                    teacher.Condition = (String)obj[2];
                    teacher.Email = (String)obj[3];
                    teacher.IdSchool = (int)obj[4];

                    teachers.Add(teacher);
                }
                return teachers;
            }
        }

        public static Teacher GetById(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM teacher WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                Teacher teacher = null;
                Object[] objects = db.QueryCommand(sql, id);
                
                if(objects != null)
                {
                    teacher = new Teacher();
                    teacher.Id = (int)objects[0];
                    teacher.Name = (String)objects[1];
                    teacher.Condition = (String)objects[2];
                    teacher.Email = (String)objects[3];
                    teacher.IdSchool = (int)objects[4];
                }

                return teacher;
            }
        }

        public static List<Subject> GetSubjectsByTeacher(int idTeacher)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT s.* " +
                "FROM teacher t " +
                "INNER JOIN subject s " +
                    "ON t.id = s.idTeacher " +
                "WHERE s.idTeacher = @idTeacher"
             );
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, int> idDict = new Dictionary<string, int>();
                idDict.Add("@idTeacher", idTeacher);

                List<Subject> subjects = new List<Subject>();
                List<Object[]> objects = db.QueryCommand(sql, idDict);

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

        public static void Update(Teacher teacher) {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE teacher SET id = @id, name = @name, condition = @condition, " +
                "email = @email, idSchool = @idSchool WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {

                Dictionary<string, object> teacherDictionary = new Dictionary<string, object>();
                teacherDictionary.Add("@id", teacher.Id);
                teacherDictionary.Add("@name", teacher.Name);
                teacherDictionary.Add("@condition", teacher.Condition);
                teacherDictionary.Add("@email", teacher.Email);
                teacherDictionary.Add("@idSchool", teacher.IdSchool);

                db.NoQueryCommand(sql, teacherDictionary);
            }
        }

        public static void Delete(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM teacher WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB()) {
                Dictionary<string, object> teacherIdDict = new Dictionary<string, object>();
                teacherIdDict.Add("@id", id);

                db.NoQueryCommand(sql, teacherIdDict);
            }
        }
    }
}
