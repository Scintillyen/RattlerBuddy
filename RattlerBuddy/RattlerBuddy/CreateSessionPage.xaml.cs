using System;
using System.Collections.Generic;
using RattlerBuddy.Model;
using SQLite;
using Xamarin.Forms;

namespace RattlerBuddy
{
    public partial class CreateSessionPage : ContentPage
    {
        public CreateSessionPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            datePicker.MinimumDate = DateTime.Now.Date;
            timePicker.Time = DateTime.Now.TimeOfDay;

        }

        void ResetButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CreateSessionPage());
        }

        void CreateSessionButton_Clicked(object sender, System.EventArgs e)
        {
            DateTime dateTime = new DateTime(datePicker.Date.Year, datePicker.Date.Month, datePicker.Date.Day, timePicker.Time.Hours,timePicker.Time.Minutes, timePicker.Time.Seconds);

            TutorSession tutorSession = new TutorSession()
            {
                Tutor_ID = App.User_ID,
                Meeting_Time = dateTime,
                Location = locationName.Text,
                Tutor_FName = App.User_Name,
                Class_Name=className.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TutorSession>();
                int rows = conn.Insert(tutorSession);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Session Created!", "Ok");

                    Navigation.PushAsync(new HomePage());
                }
            }
        }
    }
}
