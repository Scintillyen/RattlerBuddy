using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using RattlerBuddy.Model;
using System.Linq;

namespace RattlerBuddy
{
    public partial class HomePage : MasterDetailPage
    {


        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TutorSession>();

                var tutorSession = conn.Table<TutorSession>().ToList();

                sessionCountLabel.Text = tutorSession.Count.ToString();

                userName.Text = App.User_Name;
                userEmail.Text = App.User_Email;

                newsFeedListView.ItemsSource = tutorSession;
            }
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var info = (TextCell)sender;
            TutorSession session  = (TutorSession)info.CommandParameter;
            Navigation.PushAsync(new DisplaySessionPage(session));
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            IsPresented=true;
        }

        void LogOutDetailButton_Clicked(object sender, System.EventArgs e)
        {
            App.User_ID = -1;
            App.User_Email = "";
            App.User_Name = "";

            Navigation.PushAsync(new MainPage());
        }

        void TutoringDetailButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TutoringHubPage());
        }

        void MessageDetailButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChatLogPage());
        }

    }
}
