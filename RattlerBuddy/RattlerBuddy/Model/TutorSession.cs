using System;
using System.Collections.Generic;
using SQLite;

namespace RattlerBuddy.Model
{
    public class TutorSession
    {
        [PrimaryKey, AutoIncrement]
        public int Session_ID { get; set; }
        public int Tutor_ID { get; set; }
        public string Class_Name { get; set; }
        public string Tutor_FName { get; set; }
        public string Tutor_LName { get; set; }
        public DateTime Meeting_Time { get; set; }
        public string Location { get; set; }

    }
}
