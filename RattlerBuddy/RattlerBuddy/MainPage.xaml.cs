using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using RattlerBuddy.Model;



namespace RattlerBuddy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this,false);
        }

        void LoginButton_Clicked(object sender, System.EventArgs e)
        {

            bool emailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool passwordEmpty = string.IsNullOrEmpty(passwordEntry.Text);


            if( emailEmpty || passwordEmpty)
            {
                DisplayAlert("Alert","Please enter Username and Password!","Ok");
            }
            else
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {

                    conn.CreateTable<Student>();
                    string password = "";

                    var user_Account = conn.Query<Student>("SELECT Student_ID,Student_Email,Student_FName,Student_Password FROM STUDENT where Student_Email = ?", emailEntry.Text);

                    foreach (var s in user_Account)
                    {
                        App.User_ID = s.Student_ID;
                        App.User_Email = s.Student_Email;
                        App.User_Name = s.Student_FName;

                        password = s.Student_Password;
                    }

                    if (user_Account != null && user_Account.Any()!= false && password==passwordEntry.Text)
                    {

                        Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        DisplayAlert("Failure", "E-mail or Password incorrect!", "Ok");
                    }
                }
               
            }
        }

        void RegisterButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
