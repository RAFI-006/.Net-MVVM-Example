using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Brainer.TabPage;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(Brainer.View.UnselectedTabColorEffect), nameof(Brainer.iOS.UnselectedTabColorEffect))]
namespace Brainer.iOS
{
    //Render Class To Change the Color of the Tab Icons 
    public class UnselectedTabColorEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var tabBar = Container.Subviews.OfType<UITabBar>().FirstOrDefault();
            if (tabBar == null)
            {
                return;
            }

            tabBar.UnselectedItemTintColor = UIColor.White;
        }

        protected override void OnDetached()
        {
        }
    }
}