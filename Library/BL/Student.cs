using Library.DAL;
using System;
using System.Collections.Generic;

namespace Library.BL
{
    public class Student
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnrollDate { get; set; }
        public String Country { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
       
        // BL Methods
        public void Create() {
            StudentDAL.Create(this);
        }

        public List<Student> GetAll() {
            return StudentDAL.GetAll();
        }

        public Student GetById() {
            return StudentDAL.GetById(Id);
        }

        public void Update() {
            StudentDAL.Update(this);
        }

        public void Delete() {
            StudentDAL.Delete(Id);
        }
    }
}
