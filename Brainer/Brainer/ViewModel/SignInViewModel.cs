using Brainer.Model;
using Brainer.Repository;
using Brainer.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
   
public  class SignInViewModel :BaseViewModel
    {
        string _username;
        string _password;
        private bool _isVisible=false;
        public   int raterId;
        public  string email;

        public static int getSectorID { get; set; }
        public Action DisplayInvalidLoginPrompt;
        public Action DisplayEmptyFieldPrompt;
        INavigation Navigation;
        SignInRepository repo;
     public  ICommand SignInButton_Clikced { get; set; }
     public  SignInViewModel(INavigation navigation)
        {
            Navigation = navigation;
            repo = new SignInRepository();

            SignInButton_Clikced = new Command(OnSignInButton_Clikced);
             GetSectorID();

        }

        #region SignIN Button Event Handler
        private async void OnSignInButton_Clikced(object obj)
        {

            IsVisibled =true;

            if (_username != null && _password != null)
            {
          
                var loginModel = new LoginModel();
                loginModel.username = _username;
                loginModel.password = _password;
                var response = await repo.SignIn(loginModel);
                if (!response.hasError)
                {
                    var res = response.data;
                    SignInActivity.raterId = res.employeeId;
                    SignInActivity.Email = res.email;

                    NavigatingToPeopleSearcTab();
                    IsVisibled = false;
                }
                else
                {
                    IsVisibled = false;
                 await   App.Current.MainPage.DisplayAlert("Alert", "Username or Password is Incorrect", "Ok");
                }

            }
            else
            {
                await  App.Current.MainPage.DisplayAlert("Alert", "Username or Password cannot be Empty", "Ok");

                IsVisibled = false;
            }
           // NotifyPropertyChanged();
        }
        #endregion


        #region  get Sector ID
        async void GetSectorID()
        {
            var sectorList = new List<SectorModel>();
            var response = await repo.GetSectorId();
            if(!response.hasError)
            {
                sectorList = response.data;
                getSectorID = sectorList[0].id;
            }

                  }
        #endregion

        #region Navigation Method to navigate to People Search Tab
        private void NavigatingToPeopleSearcTab()
        {
            var isIntroScreenLaunched = Prefs.GetIntroBool("isIntroScreenLaunched");

            if (!isIntroScreenLaunched)
            {
                var intro = new IntroScreens();
                Navigation.PushAsync(intro);
                Prefs.SetIntroBool(true, "isIntroScreenLaunched");
            }

            else
            {
                var TabPages = new TabPages();

                Navigation.PushAsync(TabPages);

            }


        }
        #endregion

        #region get set for username
        public string Username
        {
            get { return _username; }
            set
            {

             

                _username = value;
                NotifyPropertyChanged("Username");
            }

       }
        #endregion



        #region get set for password
        public string Password
        {
            get { return _password; }
            set
            {

                   _password = value;
                NotifyPropertyChanged("Password");
            }

        }
        #endregion

        #region Observable for progressbar 
        public bool IsVisibled
        {
            get { return _isVisible; }

            set
            {
                _isVisible = value;

                NotifyPropertyChanged("IsVisibled");
                

            }

        }
        #endregion




    }
}
