using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using TestApp.Views;
using TestApp.JsonModels;
using Xamarin.Forms.Platform.Android;
using Square.Picasso;
using Java.Text;
using Java.Util;

[assembly: ExportRenderer(typeof(PostPage), typeof(TestApp.Droid.PostPageAndroidRenderer))]

namespace TestApp.Droid
{
    public class PostPageAndroidRenderer : PageRenderer
    {
        global::Android.Views.View view;
        private Post _post;     

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
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
                AddView(view);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR: ", ex.Message);
            }
        }

        private void SetupUserInterface()
        {
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd\'T\'HH:mm:ss", Locale.Default);
            Date date = sdf.Parse(_post.UpdateTime);
            sdf = new SimpleDateFormat("dd MMM, HH:mm:ss", Locale.Default);
            string time = sdf.Format(date);

            Activity activity = this.Context as Activity;

            view = activity.LayoutInflater.Inflate(Resource.Layout.post_page, this, false);
            view.FindViewById<TextView>(Resource.Id.user_name).Text = _post.From.Name;
            view.FindViewById<TextView>(Resource.Id.update_date).Text = time;
            view.FindViewById<TextView>(Resource.Id.post_message_text).Text = _post.Story+" "+_post.Message;
            if (_post.FullPicture != String.Empty)
            {
                Picasso.With(this.Context)
                     .Load(_post.FullPicture)
                     
                     .Into(view.FindViewById<ImageView>(Resource.Id.post_image));
            }
            Picasso.With(this.Context)
                  .Load("https://graph.facebook.com/" + _post.From.Id + "/picture")
                  .Into(view.FindViewById<ImageView>(Resource.Id.profile_picture));
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }
    }
}