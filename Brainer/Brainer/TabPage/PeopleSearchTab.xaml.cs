using Brainer.Model;
using Brainer.View;
using Brainer.ViewModel;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Brainer.TabPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    //Tab Conatains Info of All the Employees and their Details
	public partial class PeopleSearchTab : ContentPage
	{
       
        public PeopleSearchTab ()
		{

           InitializeComponent ();
            MessagingCenter.Subscribe<object>(this, "peopleSearch_tab", obj => {

             
                if (CrossConnectivity.Current.IsConnected)
                {

                   BindingContext = new PeopleSearchViewModel(Navigation);
                }
                else
                    DisplayAlert("Warning!!", "Pls Enable your Internet connection", "Done");


               

            });

          
        }
}
}