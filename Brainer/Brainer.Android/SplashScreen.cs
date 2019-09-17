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

namespace Brainer.Droid
{
    [Activity(Label = "Brainer", MainLauncher=true , Theme= "@style/Theme.Splash" , NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
             System.Threading.Thread.Sleep(300);

            StartActivity(new Intent(this, typeof(MainActivity)));

            
        }
    }
}