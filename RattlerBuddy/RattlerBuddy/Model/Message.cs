using System;
using SQLite;


namespace RattlerBuddy.Model
{
    public class Message
    {
        
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }
        public int Sender_ID { get; set; }
        public int Reciever_ID { get; set; }
        public string Reciever_Email { get; set; }

        public string Message_Text { get; set; }



    }

}
