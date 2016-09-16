using System;
using System.Collections.Generic;
using Android.App;
using TestApp.Views;
using TestApp.JsonModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using Newtonsoft.Json;

[assembly: ExportRenderer(typeof(FacebookAuthPage), typeof(TestApp.Droid.FacebookAuthPageRenderer))]

namespace TestApp.Droid
{
    class FacebookAuthPageRenderer : PageRenderer
    {
        private static string CLIENT_ID = "876583869140327";

        public FacebookAuthPageRenderer()
        {
            var activity = this.Context as Activity;
            var auth = new OAuth2Authenticator(
                clientId: CLIENT_ID, 
                scope: "publish_actions,user_posts", 
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var request = new OAuth2Request("GET", 
                        new Uri("https://graph.facebook.com/Disturbed/feed?fields=from,message,full_picture,updated_time,story"), null, eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var feedUser = await response.GetResponseTextAsync();
                    ResponseRootObject responseData = JsonConvert.DeserializeObject<ResponseRootObject>(feedUser);
                    List<Post> posts = responseData.Data;
                    await App.NavigateToMain(posts);
                }
                else {
                    await App.NavigateToMain(null);
                }
            };
            activity.StartActivity(auth.GetUI(activity));
        }
    }
}