﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TestApp.Droid
{
	[Activity (Label = "TestApp", Icon="@drawable/Icon", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
   		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            global::Xamarin.Forms.Forms.Init (this, bundle);
            LoadApplication(new App());
        }

    }
}
