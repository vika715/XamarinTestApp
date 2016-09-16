using Xamarin.Forms;
using TestApp.JsonModels;
using System.Collections.Generic;

namespace TestApp.Views
{
    public class HomePage : ContentPage
    {
        public HomePage(List<Post>posts)
        {
            this.Title = "FaceBook";
            this.BackgroundColor = Color.FromHex("#fffafa");
            var toolbarItem = new ToolbarItem() {
                Text = "Logout",
                Order = ToolbarItemOrder.Secondary
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new LoginPage());
                Navigation.RemovePage(this);
                 
            };
            this.ToolbarItems.Add(toolbarItem);
            
            ListView listView = new ListView();
            listView.ItemsSource = posts;
            listView.ItemTemplate = (new DataTemplate(() =>
            {
                var postViewCell = new PostViewCell();
                postViewCell.SetBinding(PostViewCell.FromProperty, "From");
                postViewCell.SetBinding(PostViewCell.MessageProperty, "Message");
                postViewCell.SetBinding(PostViewCell.TimeProperty, "UpdateTime");
                postViewCell.SetBinding(PostViewCell.FullPictureProperty, "FullPicture");
                postViewCell.SetBinding(PostViewCell.StoryProperty, "Story");
                
                return postViewCell;
            }));
            listView.ItemSelected += async (sender, e) => {
                await Navigation.PushAsync(new PostPage((Post)e.SelectedItem));
            };
            Content = listView;
        }
       /* public class CustomViewCell : ViewCell
        {
            public CustomViewCell()
            {
                Image postImage = new Image();
                StackLayout verticalLayout = new StackLayout();
                Label name = new Label();
                Label message = new Label();

                name.Text = "gfhgfh";
               /* message.Text =
                postImage.;
                

                verticalLayout.BackgroundColor = Color.FromHex("#ffffff");
                verticalLayout.Orientation = StackOrientation.Vertical;
                name.TextColor = Color.FromHex("#212121");
             //   message.TextColor = Color.FromHex("212121");

                verticalLayout.Children.Add(name);
              //  verticalLayout.Children.Add(image);
               // verticalLayout.Children.Add(message);
                View = verticalLayout;
            }
        }*/
    }
}
