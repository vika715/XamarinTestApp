using System;
using Xamarin.Forms;
using TestApp.Views;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Auth;
using Newtonsoft.Json;
using TestApp.JsonModels;
using System.Collections.Generic;

[assembly: ExportRenderer (typeof (FacebookAuthPage), typeof (TestApp.iOS.FacebookAuthPageiOSRenderer))]

namespace TestApp.iOS
{

    public class FacebookAuthPageiOSRenderer : PageRenderer
    {
         bool done = false;
         private static string CLIENT_ID = "876583869140327";
         public override void ViewDidAppear(bool animated)
         {
                base.ViewDidAppear(animated);
                if (done)
                    return;

                var auth = new OAuth2Authenticator(
                    clientId: CLIENT_ID,
                    scope: "publish_actions,user_posts", 
                    authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                    redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));
                auth.Completed += async (sender, eventArgs) => {
                    DismissViewController(true, null);
                    if (eventArgs.IsAuthenticated)
                    {
                        var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                        var request = new OAuth2Request("GET",
                            new Uri("https://graph.facebook.com/me/feed?fields=from,message,full_picture,updated_time,story"), null, eventArgs.Account);
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
                done = true;
                PresentViewController(auth.GetUI(), true, null);
            }
        }

}
