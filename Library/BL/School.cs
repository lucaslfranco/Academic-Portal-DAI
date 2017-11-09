using Library.DAL;
using System;
using System.Collections.Generic;

namespace Library.BL
{
    public class School
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String PostalCode { get; set; }
        public String Phone { get; set; }

        public void Create ()
        {
            SchoolDAL.Create(this);
        }

        public List<School> GetAll()
        {
            return SchoolDAL.GetAll();
        }

        public School GetById()
        {
            return SchoolDAL.GetById(Id);
        }

        public void Update()
        {
            SchoolDAL.Update(this);
        }

        public void Delete()
        {
            SchoolDAL.Delete(Id);
        }
    }
}
