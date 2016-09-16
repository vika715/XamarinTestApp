using Xamarin.Forms;
using TestApp.JsonModels;
using System.Collections.Generic;
using TestApp.Views;
using System.Threading.Tasks;

namespace TestApp
{
	public class App : Application
	{
        public App ()
		{
            MainPage = new NavigationPage();
            MainPage.Navigation.PushAsync(new LoginPage());
        }
        public async static Task NavigateToMain(List<Post> posts)
        {
            await App.Current.MainPage.Navigation.PushAsync(new HomePage(posts));
            App.Current.MainPage.Navigation.RemovePage(Current.MainPage.Navigation.NavigationStack[0]);
        }

        protected override void OnStart ()
		{
		}

		protected override void OnSleep ()
		{
		}

		protected override void OnResume ()
		{
		}
	}
}
