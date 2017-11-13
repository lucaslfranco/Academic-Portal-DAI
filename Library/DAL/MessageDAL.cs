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
                "CREATE TABLE message (id int not null, title varchar(45) not null, content varchar(255) not null, time DateTime not null, idDiscipline int not null)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                db.NoQueryCommand(sql);
            }
        }

        public static void Create(Message message)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO message (id, title, content, time, idDiscipline) VALUES " +
                "(@id, @title, @content, @time, @idDiscipline)");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
                messageDictionary.Add("@id", message.Id);
                messageDictionary.Add("@title", message.Title);
                messageDictionary.Add("@content", message.Content);
                messageDictionary.Add("@time", message.Time);
                messageDictionary.Add("@idDiscipline", message.IdDiscipline);

                db.NoQueryCommand(sql, messageDictionary);
            }
        }

        public static List<Message> GetAll()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM message");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                List<Message> messages = new List<Message>();
                List<Object[]> objects = db.QueryCommand(sql);

                foreach (Object[] obj in objects)
                {
                    Message message = new Message();
                    message.Id = (int)obj[0];
                    message.Title = (String)obj[1];
                    message.Content = (String)obj[2];
                    message.Time = (DateTime)obj[3];
                    message.IdDiscipline = (int)obj[4];
                   
                    messages.Add(message);
                }

                return messages;
            }
        }

        public static Message GetById(int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM message WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Object[] objects = db.QueryCommand(sql, id);
                Message message = new Message();

                message.Id = (int)objects[0];
                message.Title = (String)objects[1];
                message.Content = (String)objects[2];
                message.Time = (DateTime)objects[3];
                message.IdDiscipline = (int)objects[4];

                return message;
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
                Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
                messageDictionary.Add("@id", message.Id);
                messageDictionary.Add("@title", message.Title);
                messageDictionary.Add("@content", message.Content);
                messageDictionary.Add("@time", message.Time);
                messageDictionary.Add("@idDiscipline", message.IdDiscipline);

                db.NoQueryCommand(sql, messageDictionary);
            }
        }

        public static void Delete(int id)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM message WHERE id = @id");
            String sql = stringBuilder.ToString();

            using (DB db = new DB())
            {
                Dictionary<string, object> messageIdDict = new Dictionary<string, object>();
                messageIdDict.Add("@id", id);

                db.NoQueryCommand(sql, messageIdDict);
            }
        }
    }
}
