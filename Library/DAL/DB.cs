using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library.DAL
{
    public class DB : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DB()
        {
            try
            {
                var connectionBuilder = new SqlConnectionStringBuilder();
                connectionBuilder.DataSource = "daiproject.database.windows.net";
                connectionBuilder.UserID = "useradmin";
                connectionBuilder.Password = "DAIpassword321";
                connectionBuilder.InitialCatalog = "DAI_DB";

                Connection = new SqlConnection(connectionBuilder.ConnectionString);
                Connection.Open();
            }
            catch (SqlException e) {}
        }

        public void NoQueryCommand(String sql)
        {
           using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                  command.ExecuteNonQuery();
            }
        }

        public void NoQueryCommand(String sql, Dictionary<string, object> dictionary)
        {
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                foreach (KeyValuePair<string, object> item in dictionary)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }
                command.ExecuteNonQuery();
            }
        }

        public List<Object[]> QueryCommand(String sql)
        {
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Object[]> objects = new List<Object[]>();

                    while (reader.Read()) {
                        Object[] obj = new Object[reader.FieldCount];
                        reader.GetValues(obj);
                        objects.Add(obj);
                    }
                    return objects;
                }
            }
        }

        public Object[] QueryCommand(String sql, int id)
        {
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Object[] objects = new Object[reader.FieldCount];
                    while (reader.Read())
                        reader.GetValues(objects);
    
                    return objects;
                }
            }
        }

        public List<Object[]> QueryCommand(String sql, Dictionary<string, int> idDictionary)
        {
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                foreach (KeyValuePair<string, int> id in idDictionary)
                {
                    command.Parameters.AddWithValue(id.Key, id.Value);
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Object[]> objects = new List<Object[]>();

                    while (reader.Read())
                    {
                        Object[] obj = new Object[reader.FieldCount];
                        reader.GetValues(obj);
                        objects.Add(obj);
                    }
                    return objects;
                }
            }
        }

        public void Dispose()
        {
            if(Connection != null)
            {
                Connection.Close();
            }
            GC.SuppressFinalize(this);
        }
    }
}
