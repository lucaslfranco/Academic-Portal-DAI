using System;
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
                connectionBuilder.DataSource = "projectdai.database.windows.net";
                connectionBuilder.UserID = "lucasfranco";
                connectionBuilder.Password = "DAIpassword321";
                connectionBuilder.InitialCatalog = "aplicacaoDAI";

                Connection = new SqlConnection(connectionBuilder.ConnectionString);
                Connection.Open();
            }
            catch (SqlException e) { }
        }

        public void NoQueryCommand(String sql)
        {
           using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                  command.ExecuteNonQuery();
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
