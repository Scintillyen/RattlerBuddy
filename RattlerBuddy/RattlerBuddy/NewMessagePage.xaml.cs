using System;
using System.Collections.Generic;
using RattlerBuddy.Model;
using SQLite;

using Xamarin.Forms;

namespace RattlerBuddy
{
    public partial class NewMessagePage : ContentPage
    {
        public NewMessagePage()
        {
            InitializeComponent();
        }

        void sendButton_Clicked(object sender, System.EventArgs e)
        {
            bool isRecieverEmpty = string.IsNullOrEmpty(recieverEntry.Text);
            bool isMessageEmpty = string.IsNullOrEmpty(messageEntry.Text);
            int recieverID = -1;

            
                if (!isRecieverEmpty && !isMessageEmpty)
            {


                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Student>();
                    var user_Account = conn.Query<Student>("SELECT Student_ID FROM STUDENT where Student_Email = ?", recieverEntry.Text);
                    foreach (var s in user_Account)
                    {
                        recieverID = s.Student_ID;
                    }

                }

                Message message = new Message()
                {
                    Sender_ID = App.User_ID,
                    Reciever_ID = recieverID,
                    Reciever_Email = recieverEntry.Text,
                    Message_Text = messageEntry.Text,
                    Timestamp = DateTime.Now
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Message>();
                    int rows = conn.Insert(message);
                }

                Navigation.PushAsync(new ChatLogPage());
            }
            else
            {
                DisplayAlert("Failure", "Fields can not be blank.", "Ok!");
            }

        }
    }
}
