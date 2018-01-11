using Library.DAL;
using System;
using System.Collections.Generic;

namespace Library.BL
{
    public class Teacher {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Condition { get; set; }
        public String Email { get; set; }
        public int IdSchool { get; set; }

        // BL Methods
        public void Create()
        {
            TeacherDAL.Create(this);
        }

        public List<Teacher> GetAll()
        {
            return TeacherDAL.GetAll();
        }

        public Teacher GetById()
        {
            return TeacherDAL.GetById(Id);
        }

        public List<Subject> GetSubjectsByTeacher()
        {
            return TeacherDAL.GetSubjectsByTeacher(this.Id);
        }

        public void Update()
        {
            TeacherDAL.Update(this);
        }

        public void Delete()
        {
            TeacherDAL.Delete(Id);
        }

    }
}
