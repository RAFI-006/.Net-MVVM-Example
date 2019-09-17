using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brainer.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(TabbedNavigationPageRenderer))]
namespace Brainer.iOS
{
    //Render Class To manage Tab Icon Size In IOs
    public class TabbedNavigationPageRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            TabBar.TintColor = UIColor.Yellow;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

         
            if (TabBar.Items != null)
            {
                var items = TabBar.Items;
                for (int i = 0; i < items.Length; i++)
                {
                    items[i].Image = items[i].Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                  
                   
                    items[i].SetTitleTextAttributes(new UITextAttributes() { TextColor = UIColor.White }, UIControlState.Normal);
                    items[i].ImageInsets = new UIEdgeInsets(5, 0, -5, 0);
    
                }
            }
        }
    }
}