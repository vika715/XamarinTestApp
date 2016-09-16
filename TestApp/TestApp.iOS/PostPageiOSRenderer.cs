using System;
using TestApp.Views;
using TestApp.JsonModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;
using SDWebImage;

[assembly: ExportRenderer(typeof(PostPage), typeof(TestApp.iOS.PostPageiOSRenderer))]

namespace TestApp.iOS
{
    class PostPageiOSRenderer: PageRenderer
    {
        private Post _post;
        UILabel titleLabel;
        UILabel subtitleLabel;
        UILabel messageLabel;
        UIImageView avatarImageView = new UIImageView();
        UIImageView postImageView = new UIImageView();

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                var page = e.NewElement as PostPage;
                _post = page.post;
                SetupUserInterface();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR: ", ex.Message);
            }
        }

        void SetupUserInterface()
        {
            avatarImageView.Frame = new CoreGraphics.CGRect(16, 16, 40, 40);
            titleLabel.Frame = new CoreGraphics.CGRect(72, 16, 60, 14);
            subtitleLabel.Frame = new CoreGraphics.CGRect(72, 42, 60, 14);
            postImageView.Frame = new CoreGraphics.CGRect(0, 72, View.Bounds.Width, 200);
            messageLabel.Frame = new CoreGraphics.CGRect(0, 288, View.Bounds.Width, 200);
            titleLabel = new UILabel()
            {
                Font = UIFont.FromName("AmericanTypewriter", 14f),
                TextColor = UIColor.FromRGB(21, 21, 21),
                TextAlignment = UITextAlignment.Left,
                BackgroundColor = UIColor.Clear
            };

            subtitleLabel = new UILabel()
            {
                Font = UIFont.FromName("AmericanTypewriter", 14f),
                TextColor = UIColor.FromRGB(121, 121, 121),
                TextAlignment = UITextAlignment.Left,
                BackgroundColor = UIColor.Clear
            };

            messageLabel = new UILabel()
            {
                Font = UIFont.FromName("AmericanTypewriter", 14f),
                TextColor = UIColor.FromRGB(21, 21, 21),
                TextAlignment = UITextAlignment.Justified,
                BackgroundColor = UIColor.Clear
            };
            titleLabel.Text = _post.From.Name;
            subtitleLabel.Text = _post.UpdateTime;
            messageLabel.Text = _post.Message;
            avatarImageView.SetImage(
                url: new NSUrl("https://graph.facebook.com/" + _post.From.Id + "/picture"));
            if (_post.FullPicture != String.Empty)
            {
                postImageView.SetImage(
                url: new NSUrl(_post.FullPicture));
            }
            View.Add(avatarImageView);
            View.Add(titleLabel);
            View.Add(subtitleLabel);
            View.Add(postImageView);
            View.Add(messageLabel);
        }
    }
}