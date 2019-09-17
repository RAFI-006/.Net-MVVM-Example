using Brainer.Data;
using Brainer.Model;
using Brainer.Repository;
using Brainer.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Brainer.ViewModel
{
    public class AddSkillsViewModel : BaseViewModel
    {
        public ObservableCollection<SkillNameModel> getAllSkillsList { get; set; } = new ObservableCollection<SkillNameModel>();
        public bool IsChecked { get; set; }
        public EmployeeDetailsModel employeeDetailsWithSkills;
        ApiManager apiManager;
       // Action Navigation;
        public  ICommand BackButtonClicked{get;set;}
        public  ICommand SubmitButtonClicked{get; set;}
        public  ICommand SwitchToggledForAddingSkills{ get; set; }
        public ICommand SwitchToggledForRemovingSkills { get; set; }

        INavigation Navigation;
        

        List<int> addSkills;
        private SkillNameModel _selectedSkillsModel { get; set; }
        public ObservableCollection<SkillNameModel> updateSkills { get; set; } = new ObservableCollection<SkillNameModel>();  
      
        // View Model Constructor
            public AddSkillsViewModel(INavigation navigation)
    		{
            Navigation = navigation;
            addSkills = new List<int>();
            BackButtonClicked = new Command(BackButton_Tapped);
            SubmitButtonClicked = new Command(SubmitButton_Tapped);
            SwitchToggledForAddingSkills = new Command(SwitchToggledFor_AddingSkills);
            SwitchToggledForRemovingSkills = new Command(SwitchToggledFor_RemovingSkills);
            apiManager = new ApiManager(new RestServices());
               
            employeeDetailsWithSkills = new EmployeeDetailsModel();
        
            GetAllSkillsList();
            }
        #region
        //Switch Toggled for Removing Skills
        private void SwitchToggledFor_RemovingSkills(object obj)
        {
            var model = (SkillNameModel)obj as SkillNameModel;
            if (model!=null)
            {
                updateSkills.Remove(model);

                getAllSkillsList.Add(model);
            }

        }
        #endregion

        #region
        //Switch Toggled for Adding Skills
        private void SwitchToggledFor_AddingSkills(object obj)
        {
            var model = (SkillNameModel)obj as SkillNameModel;
            if (model!=null)
            {
                updateSkills.Add(model);

                getAllSkillsList.Remove(model);
            }
        }
        #endregion
        #region
        //Submit Button Event Handled
        private async void SubmitButton_Tapped(object obj)
        {
            foreach (var updatedSkills in updateSkills)
            {
                addSkills.Add(updatedSkills.id);
            }

            if (addSkills.Count >= 5)
            {
                var skillsUpdateModel = new SkillsUpdateModel();
                skillsUpdateModel.employeeId = SignInActivity.raterId;
                skillsUpdateModel.employeeSkillsIds = addSkills;

                var postUpdatingSkillsresponse = await apiManager.UpdateSkills(skillsUpdateModel);


                if (postUpdatingSkillsresponse != null)
                {



                    var stack = Navigation.NavigationStack;
                    if (stack.Count != 0)
                    {
                       await Navigation.PopModalAsync();
                        if (stack[stack.Count - 1].GetType() != typeof(PeopleDetail))
                            await Navigation.PushModalAsync(new PeopleDetail(employeeDetailsWithSkills));

                    }
                    else
                    {
                       await Navigation.PopModalAsync();

                        await Navigation.PushModalAsync(new PeopleDetail(employeeDetailsWithSkills));

                    }



                }



            }
            else
            {

          await   Application.Current.MainPage.DisplayAlert("Message", "Minimum Five Skills Needed", "Ok");
            }
        }
        #endregion

        #region
        //Back Button Event Handled
        private async void BackButton_Tapped(object obj)
        {
            await Navigation.PopModalAsync();
        }
        #endregion

        #region
        //Get All Skills List from the Api to Add Skills on the Existing Skills List
        public async void  GetAllSkillsList()
        {
            var empId = SignInActivity.raterId;        
            var responseList = await apiManager.GetAllSkills();

            var employeeModel = new EmloyeeModel();
            var employeedetails = await apiManager.GetIndividualEmployeeDetailById(SignInActivity.raterId);
            

            if (employeedetails != null)
            {
                employeeModel.firstname = employeedetails.firstname;
                employeeModel.lastname = employeedetails.lastname;
                employeeModel.id = employeedetails.id;
                employeeModel.jobTitle = employeedetails.jobTitle;
                employeeModel.officeLocation = employeedetails.officeLocation;
                employeeModel.subTeamId = employeedetails.subTeamId;
                employeeModel.phone = employeedetails.phone;
                employeeModel.photoBlobId = employeedetails.photoBlobId;
                employeeModel.email = employeedetails.email;
            }

            employeeDetailsWithSkills.employee = employeeModel;
       
       


            var existingSkillsList = await apiManager.GetIndividualEndorsementsCount(empId);


           
            if (existingSkillsList!=null) 
            {
                foreach(var existingSkills in existingSkillsList)
                {
                    var model = new SkillNameModel();
                    model.id = existingSkills.skillsId;
                    model.skillName = existingSkills.skillName;
                    updateSkills.Add(model);
                }

                HashSet<int> existingSkillsIds = new HashSet<int>(existingSkillsList.Select(s => s.skillsId));

                var nonExistingSkillList = responseList.Where(p => !existingSkillsIds.Contains(p.id)).ToList();

                foreach (var nonExistingSkills in nonExistingSkillList)
                {
                    getAllSkillsList.Add(nonExistingSkills);
                }

              
            }
            else
            {
                getAllSkillsList = responseList;
            }

        }
        #endregion

        #region
        //Update Skills Observable List get set
        public ObservableCollection<SkillNameModel> _updateSkills
        {
            get { return updateSkills; }
            set
            {
                if (value != null)
                    updateSkills = value;
                NotifyPropertyChanged("_updateSkills");
            }
        }
        #endregion

        #region
        //To change All skills List Data by setting Observable Get set
        public ObservableCollection<SkillNameModel> _getAllSkillsList
        {
            get { return getAllSkillsList; }
            set
            {
                if (value != null)
                    getAllSkillsList = value;
                NotifyPropertyChanged("_getAllSkillsList");
            }
        }
        #endregion

      


     
    }



}