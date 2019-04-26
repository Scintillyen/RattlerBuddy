using System;
using System.Collections.Generic;
using SQLite;
using RattlerBuddy.Model;

using Xamarin.Forms;
using RattlerBuddy.ViewModel;

namespace RattlerBuddy
{
    public partial class ChatLogPage : ContentPage
    {
       // HomeVM viewModel;

        public ChatLogPage()
        {
            InitializeComponent();

           // viewModel = new HomeVM();
           // BindingContext = viewModel;

        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var info = (TextCell)sender;
            string id = (string)info.Text;

            Navigation.PushAsync(new DisplayMessagePage(id));

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Message>();
                var messages = conn.Query<Message>("SELECT distinct Reciever_Email FROM Message where Sender_ID = ? OR Reciever_ID = ?", App.User_ID, App.User_ID);

                chatLogListView.ItemsSource = messages;
            }
            //BindingContext = viewModel;
        }


        void NewMessage_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewMessagePage());
        }
    }
}
