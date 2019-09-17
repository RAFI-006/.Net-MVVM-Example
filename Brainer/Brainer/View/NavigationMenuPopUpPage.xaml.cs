using Brainer.View;
using Brainer.ViewModel;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brainer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    // Class to Show PopUp for Adding Skills an Logout options
	public partial class NavigationMenuPopUpPage : PopupPage
	{
		public NavigationMenuPopUpPage ()
		{
			InitializeComponent ();

            BindingContext = new NaviagtionPopUpPageViewModel(Navigation);

        }
        
    }
}