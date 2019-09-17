using Brainer.Data;
using Brainer.Model;
using Brainer.TabPage;
using Brainer.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
    class DocumentTabViewModel:BaseViewModel
    {
        public IList<DocumentModel> DocumentCategoriesList { get; set; }
        string isDataDownloaded = Prefs.GetCurrentState("isDataDownloaded");
        ApiManager apiManager;
        INavigation Navigation;
        public DelegateCommand DocumentTabItemSelected { get; set; }
        private DocumentModel _selectedDocumnetModel { get; set; }
        public static  List<DocumentModel> DocumnetDetails;

        public DocumentTabViewModel(INavigation navigation)
        {
            Navigation = navigation;
            apiManager = new ApiManager(new RestServices());
           


            GetDocumentDetailsFromApi();
            var documentItems = DocumnetDetails;
            DocumentTabItemSelected = new DelegateCommand(DocumentTab_ItemSelected);
            #region LinQ Queries for getting document types from list of documents

            //var documentType = (from doc in documentItems
            //                    select  ).Distinct().ToList();

            #endregion



            DocumentCategoriesList = new List<DocumentModel>();

            #region Filling doucumentCategoriesList 

            foreach (var doc in documentItems)
            {
                var data = DocumentCategoriesList.Select(x => x.subDocumentName == doc.subDocumentName).FirstOrDefault();
                if(!data)
                 DocumentCategoriesList.Add(doc);
            }
            #endregion
        }

        #region List Item Selected Event Handler
        private async void DocumentTab_ItemSelected()
        {

            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(CaseStudyView))
                await Navigation.PushAsync(new CaseStudyView(SelectedDocumentModel));


            SelectedDocumentModel = null;
           
        }
        #endregion
     
     
        #region Get Document Details From Api
      
      async void GetDocumentDetailsFromApi()
        {
            BaseResponseModel entireResponse = new BaseResponseModel();
            GenericResponse<DocumentDataModel> genericResponse = new GenericResponse<DocumentDataModel>();
            //checking data is downloaded or not
            genericResponse = await apiManager.GetDocumentsBySecId(SignInActivity.GlobalSectorID);

            if (genericResponse.statusCode == 200)

                DocumnetDetails = genericResponse.data.documents;




        }
        #endregion
     
        #region Get Selected Model From the List
        public DocumentModel SelectedDocumentModel
        {

            get
            {

                return _selectedDocumnetModel;
            }
            set
            {
                _selectedDocumnetModel = value;

                NotifyPropertyChanged("SelectedDocumentModel");
            }

        }
        #endregion
    }
}

