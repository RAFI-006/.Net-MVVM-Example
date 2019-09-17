using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Brainer.CustomRender;
using Brainer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: Xamarin.Forms.ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntry1))]
namespace Brainer.Droid
{
    public class BorderlessEntry1 : EntryRenderer
    {
        public BorderlessEntry1(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}