using Library.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BL
{
    public class Enrollment
    {
        public int IdSubject { get; set; }
        public int IdStudent { get; set; }
        public int MissedClasses { get; set; }
        public int IdGrades { get; set; }

        // BL Methods
        public void Create()
        {
            EnrollmentDAL.Create(this);
        }

        public List<Enrollment> GetAll()
        {
            return EnrollmentDAL.GetAll();
        }

        public Enrollment GetById()
        {
            return EnrollmentDAL.GetById(IdSubject, IdStudent);
        }

        public void Update()
        {
            EnrollmentDAL.Update(this);
        }

        public void Delete()
        {
            EnrollmentDAL.Delete(IdSubject, IdStudent);
        }
    }
}
