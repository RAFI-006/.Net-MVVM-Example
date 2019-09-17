using Brainer.Model;
using Brainer.Repository;
using Brainer.ViewModel;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brainer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //Class For USer SignIN Implemention
    public partial class SignInActivity : ContentPage
    {
        public static int GlobalSectorID;
        public static int raterId { get; set; }
        public static string Email { get; set; }
      
      
        public SignInActivity()
        {
            InitializeComponent();

            // checking Internet connection
            if (CrossConnectivity.Current.IsConnected)
            {

               
                BindingContext = new SignInViewModel(Navigation);
                GlobalSectorID = SignInViewModel.getSectorID;
         

            }
            else
            {
                DisplayAlert("Alert", "Check Your Internet Connection", "ok");
            }


        }

       
    }
}