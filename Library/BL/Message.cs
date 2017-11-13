using Library.DAL;
using System;
using System.Collections.Generic;

namespace Library.BL
{
    public class Message
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public int IdDiscipline { get; set; }

        // BL Methods
        public void Create()
        {
            MessageDAL.Create(this);
        }

        public List<Message> GetAll()
        {
            return MessageDAL.GetAll();
        }

        public Message GetById()
        {
            return MessageDAL.GetById(Id);
        }

        public void Update()
        {
            MessageDAL.Update(this);
        }

        public void Delete()
        {
            MessageDAL.Delete(Id);
        }
    }
}
