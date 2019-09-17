using Brainer.ViewModel;
using CarouselView.FormsPlugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brainer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IntroScreens : ContentPage
	{

        //Class to Show Intro Slides Which appears only once for the Ist Time User Login
        public IntroScreens ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            BindingContext = new IntroScreensViewModel(Navigation);

        }



       
      
    }
}