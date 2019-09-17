using Brainer.Data;
using Brainer.Model;
using Brainer.Utils;
using Brainer.View;
using Plugin.Connectivity;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
    class DirectoryTabViewModel : BaseViewModel
    {
     bool _isEnabled = true;
     bool _isVisible = false;
     string _downloadButtonText="Available to Download";
     Color _buttonTextColor = Color.White, _buttonBackgroundColor = Color.FromHex("#041f5A");
     public ICommand DownloadButton_Clicked { get; set; }
     public static BaseResponseModel entireResponse { get; set; }
   
     ApiManager apiManager; 
      public  DirectoryTabViewModel()
        {

            apiManager = new ApiManager(new RestServices());
            var isDataDownloaded = Prefs.GetCurrentState("isDataDownloaded");
            if (isDataDownloaded != null)
            {
                entireResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponseModel>(isDataDownloaded);

                _isEnabled = false;
                ButtonBackgroundColor = Color.White;
                ButtonTextColor = Color.Gray;
                DownloadButtonText = "ALREADY DOWNLOADED";
            }


            DownloadButton_Clicked = new Command(OnDownloadButton_Clicked);
         

        }



        #region Download Button Event Hnadler

        private async void OnDownloadButton_Clicked(object obj)
        {
            _isEnabled = true;
            var isDataDownloaded = Prefs.GetCurrentState("isDataDownloaded");




            if (isDataDownloaded != null)
            {
                entireResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponseModel>(isDataDownloaded);
                DownloadButtonText = "ALREADY DOWNLOADED";
            }
            else
            {

                IsVisibled = true;

                if (CrossConnectivity.Current.IsConnected)
                {


                    await GetDownloadData();




                }
                else
                {
                    IsVisibled = false;
                   await  App.Current.MainPage.DisplayAlert("Alert", "Check your Internet Connection", "ok");
                }

            }
            NotifyPropertyChanged();
        }
        #endregion

        #region  Binding Color to set Color of the Button

        public Color ButtonTextColor
        {
            get {return _buttonTextColor;}

            set
            {

                _buttonTextColor = value;
                NotifyPropertyChanged("ButtonTextColor");
            }
        }

        #endregion



        #region Binding to change Button Background

        public Color ButtonBackgroundColor
        {
            get { return _buttonBackgroundColor; }

            set
            {

                _buttonBackgroundColor = value;
                NotifyPropertyChanged("ButtonBackgroundColor");
            }
        }

        #endregion


        #region  Binding to set Button Download Text

        public String DownloadButtonText
        {
            get { return _downloadButtonText; }

            set
            {

                _downloadButtonText = value;
                NotifyPropertyChanged("DownloadButtonText");
            }
        }

        #endregion

        #region  Binding to set Button Enabled or disabled

        public bool IsEnabled
        {
            get { return _isEnabled; }

            set
            {

                _isEnabled = value;
                NotifyPropertyChanged("IsEnabled");
            }
        }
        #endregion

        #region Binding to Set Progress Bar Visibility

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

        #region   Getting Downloaded Data on a diffrent Thread

        async Task GetDownloadData()
        {
            Thread thread = new Thread(async () =>
            {
                try
                {
                    entireResponse = await apiManager.GetDownloadedData(SignInActivity.GlobalSectorID,false);
                }
                catch (Exception)
                {

                }


                Prefs.SaveCurrentState(Newtonsoft.Json.JsonConvert.SerializeObject(entireResponse), "isDataDownloaded");

                Device.BeginInvokeOnMainThread(() =>
                {
                        IsEnabled = false;
                        ButtonBackgroundColor = Color.White;
                        ButtonTextColor = Color.Gray;
                        DownloadButtonText = "ALREADY DOWNLOADED";


                     App.Current.MainPage.DisplayAlert("Alert", "Data Downloaded Successfully", "ok");
                     IsVisibled = false;

                });
            });

            thread.Start();


        }
        #endregion

    }
}
