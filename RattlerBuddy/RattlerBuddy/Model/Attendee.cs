using System;
using SQLite;
namespace RattlerBuddy.Model
{
    public class Attendee
    {
        [PrimaryKey]
        public DateTime Session_Date { get; set; }
        public int Session_ID { get; set; }
        public int Student_ID { get; set; }

    }
}
