using Foundation;
using UIKit;
using SDWebImage;

namespace TestApp.iOS
{
    public partial class PostiOSCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("PostiOSCell");
        public static readonly UINib Nib;
        UILabel titleLabel;
        UILabel subtitleLabel;
        UILabel messageLabel;
        UIImageView avatarImageView;
        UIImageView postImageView;
        
        public PostiOSCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Default;
            ContentView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            avatarImageView = new UIImageView();
            postImageView = new UIImageView();
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
            ContentView.Add(avatarImageView);
            ContentView.Add(titleLabel);
            ContentView.Add(subtitleLabel);
            ContentView.Add(messageLabel);
            ContentView.Add(postImageView);
        }

        public void UpdateCell(string name, string time, string message, string avatarImageUri, string postImageUri)
        {
            titleLabel.Text = name;
            subtitleLabel.Text = time;
            messageLabel.Text = message;
            avatarImageView.SetImage(
                url: new NSUrl(avatarImageUri));
            postImageView.SetImage(
                url: new NSUrl(postImageUri));
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            avatarImageView.Frame = new CoreGraphics.CGRect(16, 16, 40, 40);
            titleLabel.Frame = new CoreGraphics.CGRect(72, 16, 60, 14);
            subtitleLabel.Frame = new CoreGraphics.CGRect(72, 42, 60, 14);
            postImageView.Frame = new CoreGraphics.CGRect(0, 72, ContentView.Bounds.Width, 200);
            messageLabel.Frame = new CoreGraphics.CGRect(0,288, ContentView.Bounds.Width,200);
        }
    }
}