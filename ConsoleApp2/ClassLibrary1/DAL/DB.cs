using System;
using System.Data.SqlClient;

namespace ClassLibrary.DAL
{
    public static class DB
    {
        public static SqlConnection InitializeConnection() {
            try {
                var connectionBuilder = new SqlConnectionStringBuilder();
                connectionBuilder.DataSource = "projectdai.database.windows.net";
                connectionBuilder.UserID = "lucasfranco";
                connectionBuilder.Password = "DAIpassword321";
                connectionBuilder.InitialCatalog = "aplicacaoDAI";

                return new SqlConnection(connectionBuilder.ConnectionString);
            }
            catch (SqlException e) {
                Console.WriteLine(e.ToString());
            }
            return null;
        }
    }
}
