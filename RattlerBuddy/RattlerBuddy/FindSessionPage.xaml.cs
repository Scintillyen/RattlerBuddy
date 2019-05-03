using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using RattlerBuddy.Model;

namespace RattlerBuddy
{
    public partial class FindSessionPage : ContentPage
    {
        public List<TutorSession> tutorSession { get; set; }
        public FindSessionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TutorSession>();

                tutorSession = conn.Table<TutorSession>().ToList();

               var resultCount = tutorSession.Count.ToString();

                sessionListView.ItemsSource = tutorSession;
            }
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var info = (TextCell)sender;
            TutorSession session = (TutorSession)info.CommandParameter;
            string tutorName = session.Tutor_FName + " " + session.Tutor_LName;
            string displayText = session.Class_Name + "\n" + session.Location + "\n" + session.Meeting_Time + "\n" + tutorName;
            DisplayAlert("Session Information", String.Format("{0,-10}", displayText), "Ok");

            //Navigation.PushAsync(new DisplaySessionPage(session));
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            List<TutorSession> searchResults = new List<TutorSession>();

            if (!String.IsNullOrEmpty(searchBar.Text))
            {
                foreach (TutorSession t in tutorSession)
                {
                    if (t.Class_Name.StartsWith(searchBar.Text, StringComparison.Ordinal))
                    {
                        searchResults.Add(t);
                    }
                }
                sessionListView.ItemsSource = searchResults;
            }
            else
            {
                sessionListView.ItemsSource = tutorSession;
            }
        }
    }
}
