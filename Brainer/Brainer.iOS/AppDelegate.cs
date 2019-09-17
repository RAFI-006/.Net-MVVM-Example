using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Brainer.Model;
using FFImageLoading.Forms.Platform;
using Foundation;
using ObjCRuntime;
using QuickLook;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

//[assembly: ResolutionGroupName("AppEffects")]
namespace Brainer.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        String[] item= {"Add Skills", "Log Out" };
        public override UIWindow Window { get => base.Window; set => base.Window = value; }


        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            CachedImageRenderer.Init();
            Rg.Plugins.Popup.Popup.Init();
            KeyboardOverlap.Forms.Plugin.iOSUnified.KeyboardOverlapRenderer.Init();
         
            UISwitch.Appearance.ThumbTintColor= UIColor.FromRGB(0, 120, 63);
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UIApplication.SharedApplication.StatusBarHidden = true;
            GetSupportedInterfaceOrientations(app, base.Window);

            if (UIApplication.SharedApplication.KeyWindow != null)
            {
              var c= UIApplication.SharedApplication.KeyWindow.SafeAreaInsets.Top;
            }
            return base.FinishedLaunching(app, options);




        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            var mainPage = Xamarin.Forms.Application.Current.MainPage;
           
            return UIInterfaceOrientationMask.Portrait;
        }

    }


}

