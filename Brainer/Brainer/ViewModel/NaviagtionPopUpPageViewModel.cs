using Brainer.View;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
    class NaviagtionPopUpPageViewModel
    {

        INavigation Navigation;
        public  ICommand SignOutOptionClicked { get; set; }
        public  ICommand AddSkillsOptionsClicked { get; set; }
       public NaviagtionPopUpPageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            SignOutOptionClicked = new Command(SignOutOption_Clicked);
            AddSkillsOptionsClicked = new Command(AddSkillsOptions_Clicked);

        }
        #region Add Skills Option Event Handler

        private void AddSkillsOptions_Clicked(object obj)
        {
            PopupNavigation.PopAsync();

            if (CrossConnectivity.Current.IsConnected)
                Navigation.PushModalAsync(new AddSkillsView());
            else
              App.Current.MainPage.DisplayAlert("Warning", "Enable your Internet Connection", "Ok");
        }
        #endregion

        #region Sign Out Options Event Handler

        private void SignOutOption_Clicked(object obj)
        {

            PopupNavigation.PopAsync();
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(SignInActivity))
                Navigation.PushAsync(new SignInActivity());
        }
        #endregion
    }
}
