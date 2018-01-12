using Library.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BL
{
    public class Grades
    {
        public int Id { get; set; }
        public double Grade1 { get; set; }
        public double Grade2 { get; set; }
        public double Grade3 { get; set; }
        public double Grade4 { get; set; }

        // BL Methods
        public int Create()
        {
            return GradesDAL.Create(this);
        }

        public List<Grades> GetAll()
        {
            return GradesDAL.GetAll();
        }

        public Grades GetById()
        {
            return GradesDAL.GetById(Id);
        }

        public void Update()
        {
            GradesDAL.Update(this);
        }

        public void Delete()
        {
            GradesDAL.Delete(Id);
        }
    }
}
