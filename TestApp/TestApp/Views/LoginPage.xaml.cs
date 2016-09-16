using System;
using Xamarin.Forms;

namespace TestApp.Views
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            InitializeComponent();
        }

        private async void OnClickFBLoginButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FacebookAuthPage());
            Navigation.RemovePage(this);
        }
    }
}
