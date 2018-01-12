using Library.DAL;
using System;
using System.Collections.Generic;

namespace Library.BL
{
    public class Subject
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Credits { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ClassesHeld { get; set; }
        public int IdTeacher { get; set; }
        public int IdCourse { get; set; }

        // BL Methods
        public void Create()
        {
            SubjectDAL.Create(this);
        }

        public List<Subject> GetAll()
        {
            return SubjectDAL.GetAll();
        }

        public Subject GetById()
        {
            return SubjectDAL.GetById(Id);
        }

        public List<Student> GetStudentsBySubject()
        {
            return SubjectDAL.GetStudentsBySubject(Id);
        }

        public void Update()
        {
            SubjectDAL.Update(this);
        }

        public void Delete()
        {
            SubjectDAL.Delete(Id);
        }
    }
}
