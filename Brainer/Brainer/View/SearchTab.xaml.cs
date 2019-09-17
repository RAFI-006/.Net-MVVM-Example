using Brainer.Model;
using Brainer.TabPage;
using Brainer.ViewModel;
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
    //This Class Implements Search Feature
    public partial class SearchTab : ContentPage
    {

        
        public SearchTab()
        {
            InitializeComponent();
            BindingContext = new SearchTabViewModel(Navigation);
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.PopAsync();
        }
    }
}