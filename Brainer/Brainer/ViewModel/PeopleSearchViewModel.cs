using Brainer.Data;
using Brainer.Model;
using Brainer.Repository;
using Brainer.TabPage;
using Brainer.Utils;
using Brainer.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
    class PeopleSearchViewModel:BaseViewModel
    {
        public IList<EmployeeDetailsModel> EmployeeDetailsList{ get; private set; }
        public int ItemCount { get; private set; }
        public string EmployeeName { get; private set; }
        public List<ObservableCollectionGroup<string, EmployeeDetailsModel>> GroupingEmployeeDetailList{ get; set; }
        public ICommand SearchBar_Tapped { get; set; }
        ApiManager apiManager;
        private INavigation Navigation;
        public DelegateCommand PeopleSearchItemSelected { get; set; }
        private EmployeeDetailsModel _selectedEmployeeModel { get; set; }
        public PeopleSearchViewModel(INavigation navigation)
        {
            Navigation = navigation;
            apiManager = new ApiManager(new RestServices());
            GetEmployeeDetailsFromApi();
            GroupingEmployeeDetailList = EmployeeDetailsList.OrderBy(p => p.employee.firstname).GroupBy(p => p.employee.firstname[0].ToString().ToUpper())
                          .Select(p => new ObservableCollectionGroup<string, EmployeeDetailsModel>(p)).ToList();

            SearchBar_Tapped = new Command(OnSearchBar_Tapped);
            PeopleSearchItemSelected = new DelegateCommand(PeopleSearch_ItemSelected);



        }

        #region ItemSelected List Event Handler
        
        private async void PeopleSearch_ItemSelected()
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(PeopleDetail))
                await Navigation.PushModalAsync(new PeopleDetail(SelectedEmployeeModel));

            SelectedEmployeeModel = null;

        }
        #endregion

        #region Search Button Event Handler
        private async void OnSearchBar_Tapped(object obj)
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(SearchTab))
                await Navigation.PushAsync(new SearchTab());

        }
        #endregion

      


        #region Getting Emloyee Details From Api
       async void GetEmployeeDetailsFromApi()
        {
            //Getting Data directly from Api
         
                var entireResponse = await apiManager.GetDownloadedData(SignInActivity.GlobalSectorID, true);
                EmployeeDetailsList = entireResponse.employees;
         
        }
        #endregion

        #region Observable to get the Selected Employee Model
        public EmployeeDetailsModel SelectedEmployeeModel
        {
            get
            {

                return _selectedEmployeeModel;

            }

            set
            {
                _selectedEmployeeModel = value;

                NotifyPropertyChanged("SelectedEmployeeModel");
            }
        
        }
        #endregion

    }
}
