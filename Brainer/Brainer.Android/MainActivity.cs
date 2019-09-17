using System;

using Android.App;
using Android.Content.PM;

using Android.Views;
using Android.OS;
using CarouselView.FormsPlugin.Android;

using Android.Support.V4.Content;
using Android.Content;
using Android.Widget;
using Xamarin.Forms;
using Brainer.Model;
using System.IO;
using Xamarin.Forms.PlatformConfiguration;
using Android.Net;
using Android;
using Android.Runtime;
using Android.Support.V4.App;
using FFImageLoading.Forms.Platform;

namespace Brainer.Droid
{
    [Activity(Label = "Brainer", Icon = "@drawable/ic_blackbrainer", Theme = "@style/MainTheme", MainLauncher = false, ScreenOrientation =ScreenOrientation.Portrait ,ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CarouselViewRenderer.Init();
            CachedImageRenderer.Init(true);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            LoadApplication(new App());
            
            RequestedOrientation = ScreenOrientation.Portrait;


            // to directly get out from the tab page
            MessagingCenter.Subscribe<object>(this, "backButtonPressed", (sender) =>
          {


              var activity = (Activity)this;
              activity.FinishAffinity();

          });







        }
    }
}
       


        
    
