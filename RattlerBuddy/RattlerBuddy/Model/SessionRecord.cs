using System;
using SQLite;

namespace RattlerBuddy.Model
{
    public class SessionRecord
    {
        [PrimaryKey]
        public DateTime Session_Time { get; set; }
        public int Session_ID { get; set; }
        public string Session_Attendance{ get; set; }
    }
}
