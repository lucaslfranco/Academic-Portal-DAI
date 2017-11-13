using Library.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Library.DAL
{
    public static class MessageDAL
    {
        public static void CreateTable()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DROP TABLE IF EXISTS message; " +
                "CREATE TABLE message (id int not null, title varchar(255) not null, content varchar(255) not null, idDiscipline int not null)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Message message)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO message (id, title, content, idDiscipline) VALUES " +
                "(@id, @title, @content, @idDiscipline)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", message.Id);
                    command.Parameters.AddWithValue("@title", message.Title);
                    command.Parameters.AddWithValue("@content", message.Content);
                    command.Parameters.AddWithValue("@idDiscipline", message.IdDiscipline);
                    int rows = command.ExecuteNonQuery();
                }
            }
        }

        public static List<Message> GetAll()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM message");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Message> messages = new List<Message>();

                        while (reader.Read())
                        {
                            Message message = new Message();

                            message.Id = reader.GetInt32(0);
                            message.Title = reader.GetString(1);
                            message.Content = reader.GetString(2);
                            message.IdDiscipline = reader.GetInt32(4);

                            messages.Add(message);
                        }
                        return messages;
                    }
                }
            }
        }

        public static Message GetById(int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM message WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Message message = new Message();
                        while (reader.Read())
                        {
                            message.Id = reader.GetInt32(0);
                            message.Title = reader.GetString(1);
                            message.Content = reader.GetString(2);
                            message.IdDiscipline = reader.GetInt32(4);
                        }
                        return message;
                    }
                }
            }
        }

        public static void Update(Message message)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE message SET id = @id, title = @title, content = @content, " +
                "idDiscipline = @idDiscipline WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {

                using (SqlCommand command = new SqlCommand(sql, db.Connection))
                {

                    command.Parameters.AddWithValue("@id", message.Id);
                    command.Parameters.AddWithValue("@title", message.Title);
                    command.Parameters.AddWithValue("@content", message.Content);
                    command.Parameters.AddWithValue("@idDiscipline", message.IdDiscipline);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM student WHERE id = @id");
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
