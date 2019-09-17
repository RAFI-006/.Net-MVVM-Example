using Brainer.Data;
using Brainer.Model;
using Brainer.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
    class SearchTabViewModel :BaseViewModel
    {
        
        public ObservableCollection<EmployeeDetailsModel> FilterEmployeeList { get; set; }
        private ObservableCollection<EmployeeDetailsModel> _ObemployeeList { get; set; } = new ObservableCollection<EmployeeDetailsModel>();

        ApiManager apiManager;
        INavigation Navigation;
        private string _searchText;
        private EmployeeDetailsModel _selectedEmployeeModel { get; set; }
        private IList<EmployeeDetailsModel> _employeeList { get; set; }
        public ICommand TextChangeController { get; set;}
        public DelegateCommand SearchListItemSelected { get; set;}

        public SearchTabViewModel(INavigation navigation)
        {
            Navigation = navigation;
            apiManager = new ApiManager(new RestServices());
            GetEmployeeDetailsFromApi();
            TextChangeController = new Command(TextChange_Controller);
            SearchListItemSelected = new Prism.Commands.DelegateCommand(SearchListItem_Selected);
        }
        #region Selected Items Event Handler

        private async void SearchListItem_Selected()
        {
            var stack = Navigation.NavigationStack;
                if (stack[stack.Count - 1].GetType() != typeof(PeopleDetail))
                    await Navigation.PushModalAsync(new PeopleDetail(_selectedEmployeeModel));
        }
        #endregion



        #region  Search Implementation

        private void TextChange_Controller(object sender)
        {
            if (string.IsNullOrWhiteSpace(this._searchText))
                EmployeeList = FilterEmployeeList;

            else
            {
                
                var filteredList = _employeeList.Where(x => x.employee.getFullName.ToLower().Contains(this._searchText.ToLower())).ToList();
                ObservableCollection<EmployeeDetailsModel> temp = new ObservableCollection<EmployeeDetailsModel>();

                foreach (var emp in filteredList )
                {

                    temp.Add(emp);
                }

                EmployeeList = temp;
            }


        }
        #endregion

        #region    Get Employee Details From Api

        public async void GetEmployeeDetailsFromApi()
        {

            var entireResponse = await apiManager.GetDownloadedData(SignInActivity.GlobalSectorID, true);
            _employeeList = entireResponse.employees;
            ObservableCollection<EmployeeDetailsModel> temp = new ObservableCollection<EmployeeDetailsModel>();

            foreach (var emp in entireResponse.employees)
            {

                temp.Add(emp);

            }
            EmployeeList = temp;
            FilterEmployeeList = temp;



        }
        #endregion


        #region    To get the Selected EmployeeModel details from the list

        public EmployeeDetailsModel SelectedEmployeeModel
        {
            get { return _selectedEmployeeModel; }
            set
            {

                _selectedEmployeeModel = value;
                NotifyPropertyChanged("SelectedEmployeeModel");
            }
        }
        #endregion


        #region get set for Search text Changed

        public string SearchText
        {
            get { return _searchText; }
            set
            {

                _searchText = value;
                NotifyPropertyChanged("SearchText");
            }

        }
        #endregion

        #region  To get the employee list after Search queries

        public ObservableCollection<EmployeeDetailsModel> EmployeeList
        {
            get { return _ObemployeeList; }
            set
            {
                if (value != null)
                    _ObemployeeList = value;
                NotifyPropertyChanged("EmployeeList");
            }
        }
        #endregion
    }
}
