using Library.DAL;
using System;
using System.Collections.Generic;

namespace Library.BL
{
    public class Course
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Degree { get; set; }
        public int DurationYears { get; set; }
        public int IdSchool { get; set; }

        // BL Methods
        public void Create()
        {
            CourseDAL.Create(this);
        }

        public List<Course> GetAll()
        {
            return CourseDAL.GetAll();
        }

        public Course GetById()
        {
            return CourseDAL.GetById(Id);
        }

        public void Update()
        {
            CourseDAL.Update(this);
        }

        public void Delete()
        {
            CourseDAL.Delete(Id);
        }
    }
}
