using Brainer.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brainer
{
    public partial class App : Application
    {
        public App()
        {
           MainPage = new NavigationPage( new SignInActivity());
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios=a6bfd58d-4e49-425e-9201-725150435426;android=5320d39b-57c8-4884-9ef9-6983283c7ae6", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
