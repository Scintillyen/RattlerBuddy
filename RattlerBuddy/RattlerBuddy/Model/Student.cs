using System;
using SQLite;
namespace RattlerBuddy.Model
{
    public class Student
    {
        [PrimaryKey,AutoIncrement]
        public int Student_ID { get; set; }

        public string Student_Email { get; set; }
        public string Student_FName { get; set; }
        public string Student_LName { get; set; }
        public string Student_Password { get; set; }
        public bool Student_Tutor { get; set;}
    }
}
