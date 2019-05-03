using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RattlerBuddy
{
    public partial class TutoringHubPage : ContentPage
    {
        public TutoringHubPage()
        {
            InitializeComponent();
        }

        void FindSessionButton_Clicked(object sender, System.EventArgs e)
        {

            Navigation.PushAsync(new FindSessionPage());

        }

        void CreateSessionButton_Clicked(object sender, System.EventArgs e)
        {

            Navigation.PushAsync(new CreateSessionPage());

        }

    }
}
