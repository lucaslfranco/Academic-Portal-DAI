using Library.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Library.DAL
{
    public static class SchoolDAL
    {
        public static void CreateTable()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS school; " +
                "CREATE TABLE school (id int not null, name varchar(255) not null, postalCode varchar(255) not null, phone varchar(45) not null)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(School school)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO school (id, name, postalCode, phone) VALUES " +
                "(@id, @name, @postalCode, @phone)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> schoolDictionary = new Dictionary<string, object>();
                schoolDictionary.Add("@id", school.Id);
                schoolDictionary.Add("@name", school.Name);
                schoolDictionary.Add("@postalCode", school.PostalCode);
                schoolDictionary.Add("@phone", school.Phone);

                db.NoQueryCommand(sql, schoolDictionary);
            }
        }

        public static List<School> GetAll()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM school");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                List<School> schools = new List<School>();
                List<Object[]> objects = db.QueryCommand(sql);

                foreach (Object[] obj in objects)
                {
                    School school = new School();
                    school.Id = (int)obj[0];
                    school.Name = (String)obj[1];
                    school.PostalCode = (String)obj[2];
                    school.Phone = (String)obj[3];

                    schools.Add(school);
                }
                return schools;
            }
        }

        public static School GetById(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM school WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Object[] objects = db.QueryCommand(sql, id);
                School school = new School();

                school.Id = (int)objects[0];
                school.Name = (String)objects[1];
                school.PostalCode = (String)objects[2];
                school.Phone = (String)objects[3];

                return school;
            }
        }

        public static void Update(School school)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE school SET id = @id, name = @name, postalCode = @postalCode, " +
                "phone = @phone WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> schoolDictionary = new Dictionary<string, object>();
                schoolDictionary.Add("@id", school.Id);
                schoolDictionary.Add("@name", school.Name);
                schoolDictionary.Add("@postalCode", school.PostalCode);
                schoolDictionary.Add("@phone", school.Phone);

                db.NoQueryCommand(sql, schoolDictionary);
            }
        }

        public static void Delete(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM school WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> schoolIdDict = new Dictionary<string, object>();
                schoolIdDict.Add("@id", id);

                db.NoQueryCommand(sql, schoolIdDict);
            }
        }
    }
}
