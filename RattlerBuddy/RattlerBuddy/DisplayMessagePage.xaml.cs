using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using RattlerBuddy.Model;
using System.Linq;

namespace RattlerBuddy
{
    public partial class DisplayMessagePage : ContentPage
    {
        public int party_ID{get;set;}
        public Message mess { get; set; }
        public DisplayMessagePage()
        {
            InitializeComponent();
        }

        public DisplayMessagePage(Message message)
        {
            InitializeComponent();
            party_ID = message.Reciever_ID; User.Text = message.Reciever_Email;
            if(App.User_ID != message.Sender_ID) { party_ID = message.Sender_ID; }
            
        }

        protected override void OnAppearing()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Message>();
                var sentMessages = conn.Query<Message>("SELECT * FROM Message where Sender_ID = ? AND Reciever_ID = ?", App.User_ID,party_ID);
                var recievedMessages = conn.Query<Message>("SELECT * FROM Message where Sender_ID = ? AND Reciever_ID = ?", party_ID, App.User_ID);


                List<Message> messages = new List<Message>();
                foreach (Message m in sentMessages)
                {
                    messages.Add(m);
                }
                foreach (Message m in recievedMessages)
                {
                    messages.Add(m);
                }
                messages = messages.OrderBy(o => o.Timestamp).ToList();
                messages = messages.Distinct().ToList();
                messageListView.ItemsSource = messages;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Message message = new Message()
            {
                Sender_ID = App.User_ID,
                Reciever_ID = party_ID,
                Reciever_Email = User.Text,
                Message_Text = messageEntry.Text,
                Timestamp = DateTime.Now
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Message>();
                int rows = conn.Insert(message);
            }
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Message>();
                var sentMessages = conn.Query<Message>("SELECT * FROM Message where Sender_ID = ? AND Reciever_ID = ?", App.User_ID, party_ID);
                var recievedMessages = conn.Query<Message>("SELECT * FROM Message where Sender_ID = ? AND Reciever_ID = ?", party_ID, App.User_ID);


                List<Message> messages = new List<Message>();
                foreach (Message m in sentMessages)
                {
                    messages.Add(m);
                }
                foreach (Message m in recievedMessages)
                {
                    messages.Add(m);
                }
                messages = messages.OrderBy(o => o.Timestamp).ToList();
                messages = messages.Distinct().ToList();
                messageListView.ItemsSource = messages;
            }
            messageEntry.Text = "";

        }
    }
}
