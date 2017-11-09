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

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", school.Id);
                    command.Parameters.AddWithValue("@name", school.Name);
                    command.Parameters.AddWithValue("@postalCode", school.PostalCode);
                    command.Parameters.AddWithValue("@phone", school.Phone);
                    int rows = command.ExecuteNonQuery();
                }
            }
        }

        public static List<School> GetAll()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM school");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        List<School> schools = new List<School>();

                        while (reader.Read())
                        {
                            School school = new School();

                            school.Id = reader.GetInt32(0);
                            school.Name = reader.GetString(1);
                            school.PostalCode = reader.GetString(2);
                            school.Phone = reader.GetString(3);

                            schools.Add(school);
                        }
                        return schools;
                    }
                }
            }
        }

        public static School GetById(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM school WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        School school = new School();
                        while (reader.Read())
                        {
                            school.Id = reader.GetInt32(0);
                            school.Name = reader.GetString(1);
                            school.PostalCode = reader.GetString(2);
                            school.Phone = reader.GetString(3);
                        }
                        return school;
                    }
                }
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

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", school.Id);
                    command.Parameters.AddWithValue("@name", school.Name);
                    command.Parameters.AddWithValue("@postalCode", school.PostalCode);
                    command.Parameters.AddWithValue("@phone", school.Phone);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM school WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
