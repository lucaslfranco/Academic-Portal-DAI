using Library.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BL
{
    public class Discipline
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
            DisciplineDAL.Create(this);
        }

        public List<Discipline> GetAll()
        {
            return DisciplineDAL.GetAll();
        }

        public Discipline GetById()
        {
            return DisciplineDAL.GetById(Id);
        }

        public void Update()
        {
            DisciplineDAL.Update(this);
        }

        public void Delete()
        {
            DisciplineDAL.Delete(Id);
        }
    }
}
