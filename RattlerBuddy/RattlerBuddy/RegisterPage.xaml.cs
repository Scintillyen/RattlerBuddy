using System;
using System.Collections.Generic;
using RattlerBuddy.Model;
using SQLite;
using Xamarin.Forms;

namespace RattlerBuddy
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        void LoginButton_Clicked(object sender, System.EventArgs e)
        {

            Navigation.PushAsync(new MainPage());

        }

        void RegisterButton_Clicked(object sender, System.EventArgs e)
        {
            bool emailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool passwordEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            bool fNameEmpty = string.IsNullOrEmpty(nameEntry.Text);



            if (passwordEntry.Text == confirmPasswordEntry.Text && !emailEmpty && !fNameEmpty && !passwordEmpty)
            {
                Student student = new Student()
                {
                    Student_FName = nameEntry.Text,
                    Student_Email = emailEntry.Text,
                    Student_Password = passwordEntry.Text
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Student>();
                    int rows = conn.Insert(student);

                    var user_Account = conn.Query<Student>("SELECT Student_ID,Student_Email,Student_FName FROM STUDENT where Student_Email = ?", emailEntry.Text);

                    foreach (var s in user_Account)
                    {
                        App.User_ID = s.Student_ID;
                        App.User_Email = s.Student_Email;
                        App.User_Name = s.Student_FName;
                    }

                    if (rows > 0)
                    {
                        DisplayAlert("Success", "Welcome to Rattler Buddy!", "Ok");

                        Navigation.PushAsync(new HomePage());
                    }
                }

            }
            else if (passwordEntry.Text != confirmPasswordEntry.Text)
            {
                DisplayAlert("Failure", "Passwords must match!", "Ok");
            }
            else
            {
                DisplayAlert("Failure", "Please enter required fields!", "Ok");
            }

        }
    }
}

