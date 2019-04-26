using System;
using System.Collections.Generic;
using RattlerBuddy.Model;

using Xamarin.Forms;

namespace RattlerBuddy
{
    public partial class DisplaySessionPage : ContentPage
    {
        public DisplaySessionPage()
        {
            InitializeComponent();
        }
        public DisplaySessionPage( TutorSession session)
        {
            InitializeComponent();
            ClassName.Text = session.Class_Name;
            TutorName.Text = session.Tutor_FName +" "+ session.Tutor_LName;
            Date.Text = session.Meeting_Time.ToString();
            Location.Text = session.Location;

            
        }
    }
}
