using System;
using Xamarin.Forms;
using TestApp.JsonModels;

namespace TestApp.Views
{
    public class PostViewCell : ViewCell
    {
        public static readonly BindableProperty FromProperty =
        BindableProperty.Create("From", typeof(From), typeof(PostViewCell), null);

        public static readonly BindableProperty MessageProperty =
        BindableProperty.Create("Message", typeof(String), typeof(PostViewCell), String.Empty);

        public static readonly BindableProperty TimeProperty =
        BindableProperty.Create("UpdateTime", typeof(String), typeof(PostViewCell), String.Empty);

        public static readonly BindableProperty StoryProperty =
        BindableProperty.Create("Story", typeof(String), typeof(PostViewCell), String.Empty);

        public static readonly BindableProperty FullPictureProperty =
        BindableProperty.Create("FullPicture", typeof(String), typeof(PostViewCell), String.Empty);
        
        public From From
        {
            get { return (From)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public String Message
        {
            get { return (String)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        public String UpdateTime
        {
            get { return (String)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public String Story
        {
            get { return (String)GetValue(StoryProperty); }
            set { SetValue(StoryProperty, value); }
        }
        public String FullPicture
        {
            get { return (String)GetValue(FullPictureProperty); }
            set { SetValue(FullPictureProperty, value); }
        }

    }
}
