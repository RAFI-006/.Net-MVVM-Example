using Brainer.Model;
using Brainer.TabPage;
using Brainer.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
    class CaseStudyViewModel:BaseViewModel
    {
        public IList<DocumentModel> caseStudyDocumentList { get; private set; }
        public DelegateCommand CaseStudyItemSelected { get; set;}
        private DocumentModel _caseStudySelectedModel { get; set;}
        INavigation Navigation;
        public CaseStudyViewModel(DocumentModel dataModel,INavigation navigation)
        {
            Navigation = navigation;
            List<DocumentModel> addList = new List<DocumentModel>();
            CaseStudyItemSelected = new DelegateCommand(CaseStudyItem_Selected);
            var documentsList = DocumentTabViewModel.DocumnetDetails;

            caseStudyDocumentList = documentsList.Where(p => p.subDocumentId == dataModel.subDocumentId).ToList();


            
           
        }

        #region 
        //List Item Selected Event Handler
        private async void CaseStudyItem_Selected()
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(DocumentDetail))
                await Navigation.PushAsync(new DocumentDetail(CaseStudySelectedModel));


            CaseStudySelectedModel = null;
        }
        #endregion

        #region
        //Observable Property to get the selected Model from the list on ItemSelected
        public DocumentModel CaseStudySelectedModel
        {
            get { return _caseStudySelectedModel; }

            set
            {
                _caseStudySelectedModel = value;

                NotifyPropertyChanged("CaseStudySelectedModel");
            }
        }
        #endregion
    }
}

