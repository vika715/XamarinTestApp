using TestApp.JsonModels;
using Xamarin.Forms;

namespace TestApp.Views
{
	public partial class PostPage : ContentPage
	{
        public Post post;

        public PostPage (Post post)
		{
			InitializeComponent ();
            this.post = post;
        }

    }
}
