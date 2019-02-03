using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace MyLocation.Droid
{
    [Activity(Label = "MyLocation.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public static Context mContxt;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            mContxt = this;
            LoadApplication(new App(new MyLocationService()));
        }
    }
}
