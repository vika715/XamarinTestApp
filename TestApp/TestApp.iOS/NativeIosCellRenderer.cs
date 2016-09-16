using TestApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;

[assembly: ExportRenderer(typeof(PostViewCell), typeof(TestApp.iOS.NativeiOSCellRenderer))]
namespace TestApp.iOS
{
    public class NativeiOSCellRenderer : ViewCellRenderer
    {
        static NSString rid = new NSString("NativeCell");

        public override UITableViewCell GetCell(Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var post = (PostViewCell)item;
            PostiOSCell cell = reusableCell as PostiOSCell;

            if (cell == null)
            {
                cell = new PostiOSCell(rid);
            }
            string avatarImageUri = "https://graph.facebook.com/" + post.From.Id + "/picture";
            cell.UpdateCell(post.From.Name, post.UpdateTime, post.Message, avatarImageUri, post.FullPicture);
            return cell;
        }
    }
}