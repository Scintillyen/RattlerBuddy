using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using RattlerBuddy.Model;

namespace RattlerBuddy
{
    public partial class DisplayMessagePage : ContentPage
    {
        public DisplayMessagePage()
        {
            InitializeComponent();
        }

        public DisplayMessagePage(string email)
        {
            InitializeComponent();
            User.Text = email;
        }

        protected override void OnAppearing()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Message>();
                var messages = conn.Query<Message>("SELECT * FROM Message where Sender_ID = ? OR Reciever_ID = ?", App.User_ID, App.User_ID);

                messageListView.ItemsSource = messages;
            }
        }

    }
}
