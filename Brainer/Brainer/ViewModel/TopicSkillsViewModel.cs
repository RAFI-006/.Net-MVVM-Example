using Brainer.Data;
using Brainer.Model;
using Brainer.TabPage;
using Brainer.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
    class TopicSkillsViewModel : BaseViewModel
    {
        public IEnumerable<IGrouping<string, EmployeeDetailsModel>> GroupedListWithSkills { get; set; }
     
        ApiManager apiManager;
        List<EmployeeDetailsModel> EmployeeDetailsList;
        public ICommand SearchBar_Tapped { get; set; }

        INavigation Navigation;
        public DelegateCommand TopicSkillsItemSelected { get; set; }
        private EmployeeDetailsModel _selectedEmployeeDetailsModel { get; set; }
        public TopicSkillsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            SearchBar_Tapped = new Command(OnSearchBar_Tapped);
            TopicSkillsItemSelected = new DelegateCommand(TopicSkills_ItemSelected);
            apiManager = new ApiManager(new RestServices());
          
            
            GetEmployeeDetailsFromApi();

            var employees = EmployeeDetailsList;

            //linQ queries to get list according to their Group
            GroupedListWithSkills = (from employeeDetail in employees
                                     from skill in employeeDetail.Skills
                                     group employeeDetail by skill.skillName);






        }
        #region   List View Item Select Handler

        private async void TopicSkills_ItemSelected()
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(PeopleDetail))
                await Navigation.PushModalAsync(new PeopleDetail(SelectedTopicEmployeeDetailsModel));

            SelectedTopicEmployeeDetailsModel = null;
        }
        #endregion


        #region  Search Bar event Handler
        private async void OnSearchBar_Tapped(object obj)
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(SearchTab))
                await Navigation.PushAsync(new SearchTab());
        }
        #endregion

       

        #region  Getting Employee Details from Api
        async void GetEmployeeDetailsFromApi()
        {
           

            var entireResponse = await apiManager.GetDownloadedData(SignInActivity.GlobalSectorID, true);


            EmployeeDetailsList = entireResponse.employees;

        }
        #endregion

        #region To get The Selected Employee Model
        public EmployeeDetailsModel SelectedTopicEmployeeDetailsModel
            {
            get
            {
                return _selectedEmployeeDetailsModel;
            }

            set
            {
                _selectedEmployeeDetailsModel = value;
                NotifyPropertyChanged("SelectedTopicEmployeeDetailsModel");

            }
            }
        #endregion
    }
}
