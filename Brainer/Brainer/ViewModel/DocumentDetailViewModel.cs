using Brainer.Data;
using Brainer.Model;
using Brainer.TabPage;
using Brainer.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
    class DocumentDetailViewModel
    {
        ApiManager apiManager;
        public string Name { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public int DocumentID { get; set; }
        public string PhotoUrl { get; set; }
        public ImageSource source { get; set; }
        private UniqueEmployeeModel empModel { get; set; } 
        public ICommand ViewPdf {get; set;}
        public ICommand SharePdf { get; set;}
        DocumentModel mModel;

        public DocumentDetailViewModel(DocumentModel model)
        {
            mModel = model;
            apiManager = new ApiManager(new RestServices());
            ViewPdf = new Command(ViewPdf_Tapped);
            SharePdf = new Command(SharePdf_Tapped);
            GetIndivdualEmpDetail(model.employeeId);
            Name = model.author;
            Title = model.title;
            var date = model.uploadedDate;
            Date= "Upload Date-"+date.ToString("yyyy-MM-dd");
            DocumentID = model.id;

            #region Getting Individual Employee from the employeeId 

           



                PhotoUrl = empModel.photoBlobId;
            
                #endregion



            

        }

        #region
        //Getting Individual Emloyee Detail From Api
        async void GetIndivdualEmpDetail(int userId)
        {

            empModel = await apiManager.GetIndividualEmployeeDetailById(userId);
        }
        #endregion

        #region
        //To Sahre Pdf Via Email
        private async void SharePdf_Tapped(object obj)
        {
            SendDocumentModel model = new SendDocumentModel();
            model.documentDetailId = mModel.id;
            model.subject = "Brainer Document";
            model.email = SignInActivity.Email;

            var response = await apiManager.ShareDocument(model);
            if (response)
                await App.Current.MainPage.DisplayAlert("Message", "Document Mailed Successfully", "Ok");

        }
        #endregion



        // To View Pdf Event Handler
        #region
        private void ViewPdf_Tapped(object obj)
        {
            if (mModel.documentBlob!=null)
            {
                var documentBlob = mModel.documentBlob;
                System.Uri fileUri = new System.Uri(documentBlob);
                try
                {
                    Device.OpenUri(fileUri);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Message", "No Document available", "Ok");
            }


        }
        #endregion
    }
}
