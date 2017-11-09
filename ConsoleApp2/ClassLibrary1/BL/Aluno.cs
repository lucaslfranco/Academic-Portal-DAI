using ClassLibrary.DAL;
using System;

namespace ClassLibrary.BL
{
    public class Student
    {
        public int Id { get; set; }
        String name { get; set; }
        String birthDate { get; set; }
        String enrollDate { get; set; }
        String country { get; set; }
        String email { get; set; }
        String phone { get; set; }

        // Getters and Setters
        
        public String Name {
            get { return name; }
            set { name = value; }
        }
        public String BirthDate {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public String EnrollDate {
            get { return enrollDate; }
            set { enrollDate = value; }
        }
        public String Country {
            get { return country; }
            set { country = value; }
        }
        public String Email {
            get { return email; }
            set { email = value; }
        }
        public String Phone {
            get { return phone; }
            set { phone = value; }
        }

        // BL Methods
        public void Create() {
            StudentDAL.Create(this);
        }

        public void GetAll() {
            StudentDAL.GetAll();
        }

        public void GetById() {
            StudentDAL.GetById(this.Id);
        }

        public void Update() {
            StudentDAL.Update(this);
        }

        public void Delete() {
            StudentDAL.Delete(this);
        }
    }
}
