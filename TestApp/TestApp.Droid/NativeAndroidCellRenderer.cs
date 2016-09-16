using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using TestApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Square.Picasso;
using Java.Util;
using Java.Text;

[assembly: ExportRenderer (typeof(PostViewCell), typeof(TestApp.Droid.NativeAndroidCellRenderer))]

namespace TestApp.Droid
{
    public class NativeAndroidCellRenderer : ViewCellRenderer
    {
        protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView,
                ViewGroup parent, Context context)
        {
            var post = (PostViewCell)item;
            var view = convertView;
            if (view == null)
            {
                view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.post_list_item, null);
            }
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd\'T\'HH:mm:ss", Locale.Default);
            Date date = sdf.Parse(post.UpdateTime);
            sdf = new SimpleDateFormat("dd MMM, HH:mm:ss", Locale.Default);
            string time = sdf.Format(date);

            view.FindViewById<TextView>(Resource.Id.user_name).Text = post.From.Name;
            view.FindViewById<TextView>(Resource.Id.update_date).Text = time;
            view.FindViewById<TextView>(Resource.Id.post_message_text).Text = post.Story+" "+post.Message;
            if (post.FullPicture != String.Empty)
            {
            Picasso.With(context)
                    .Load(post.FullPicture)
                    .CenterCrop()
                    .Into(view.FindViewById<ImageView>(Resource.Id.post_image));
            }
            Picasso.With(context)
                    .Load("https://graph.facebook.com/" + post.From.Id + "/picture")
                    .Into(view.FindViewById<ImageView>(Resource.Id.profile_picture));
            return view;
        }
    }
}