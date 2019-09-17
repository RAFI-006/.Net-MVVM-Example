
using CarouselView.FormsPlugin.iOS;

using UIKit;


namespace Brainer.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
            CarouselViewRenderer.Init();
            Rg.Plugins.Popup.Popup.Init();

         



        }
    }
}
