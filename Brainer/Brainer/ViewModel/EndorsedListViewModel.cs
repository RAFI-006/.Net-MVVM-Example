using Brainer.Data;
using Brainer.Model;
using Brainer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
    class EndorsedListViewModel
    {
        public IList<EndorseModel> EndorsedList { get; private set; }
        INavigation Navigation;
        ApiManager apiManager;
        public ICommand BackButtonClicked { get; set; }

        public EndorsedListViewModel(int empId,int skillsID,INavigation navigation)
        {
            Navigation = navigation;
            BackButtonClicked = new Command(BackButtonClicked_Tapped);
            apiManager = new ApiManager(new RestServices());
            GetEndorseListResponse(empId,skillsID);
        }

   
        #region Back Buttton Implementation
        private async  void BackButtonClicked_Tapped(object obj)
        {
            await Navigation.PopModalAsync();
        }
        #endregion

        #region Getting Endorsers List from Api

        async void GetEndorseListResponse(int empId,int skillsId)
        {
            var response = await apiManager.ShowEndorsementsList(empId, skillsId);

            var list = response.endorsements;
            EndorsedList = list;
        }
        #endregion
    }
}
