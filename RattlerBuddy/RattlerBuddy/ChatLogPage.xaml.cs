using System;
using System.Collections.Generic;
using SQLite;
using RattlerBuddy.Model;
using System.Linq;

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
            Message chat = (Message)info.CommandParameter;

            Navigation.PushAsync(new DisplayMessagePage(chat));

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Message>();
                var sentMessages = conn.Query<Message>("SELECT * FROM Message where Sender_ID = ?", App.User_ID);
                var recievedMessages = conn.Query<Message>("SELECT * FROM Message where Reciever_ID = ?", App.User_ID);
                List<Message> messages = new List<Message>();
                foreach(Message m in sentMessages)
                {
                    messages.Add(m);
                }
                foreach (Message m in recievedMessages)
                {
                    messages.Add(m);
                }
                messages = messages.OrderBy(o => o.Timestamp).ToList();
                //messages = messages.Distinct().ToList();
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
