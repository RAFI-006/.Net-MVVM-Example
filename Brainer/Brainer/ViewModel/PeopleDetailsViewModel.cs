using Brainer.Model;
using Brainer.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Brainer.View;
using System.IO;
using Brainer.Data;
using System.Threading;

namespace Brainer.ViewModel
{

   public class PeopleDetailsViewModel :BaseViewModel
    {
        public ObservableCollection<EndorseGenericModel> endorsedeviceList = new ObservableCollection<EndorseGenericModel>();
        public string Name { get; private set; }
        public int ratingCount { get; set; }
        public string Designation { get; private set;}
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public int EmpId { get; set; }
        public string officeLocation { get; set; }
        public string ImageUrl { get; set; }
        public ImageSource source { get; set; }
        ApiManager apiManager;
        INavigation Navigation;
        public ICommand EndorseButtonClicked { get; set;}
        public ICommand ViewEndosersTapped { get; set;}
        public ICommand BackButtonClicked { get; set;}
        AddRatingModel model;

        public ObservableCollection<RatingCountModel> ratingList { get; set; } = new ObservableCollection<RatingCountModel>();

       
   


        public  PeopleDetailsViewModel(EmployeeDetailsModel employeeModel,INavigation navigation)
        {
            Navigation = navigation;
            apiManager = new ApiManager(new RestServices());
            model = new AddRatingModel();
            EndorseButtonClicked = new Command(EndorseButton_Clicked);
            ViewEndosersTapped = new Command(ViewEndosers_Tapped);
            BackButtonClicked = new Command(BackButton_Clicked);
            Name = employeeModel.employee.getFullName;
            Designation = employeeModel.employee.jobTitle.Split('\r')[0];
            Phone = employeeModel.employee.phone.Split('\r')[0];

            Email = employeeModel.employee.email.Split('\r')[0];
            EmpId = employeeModel.employee.id;
            officeLocation = employeeModel.employee.officeLocation;
            ImageUrl = employeeModel.employee.photoBlobId;


               GetIndividualRatingCount(EmpId);
            







        }

        #region Back Button Handled

        private async void BackButton_Clicked(object obj)
        {
            await Navigation.PopModalAsync();
        }
        #endregion



        #region Check List of People Wgo Endorsed Who Endorsed
        private async void ViewEndosers_Tapped(object sender)
        {
            model.employeeDetailsId = EmpId;
            model.ratingByEmployeeId = SignInActivity.raterId;
            var endorsements = (RatingCountModel)sender as RatingCountModel;
            var stack = Navigation.NavigationStack;
            if (stack.Count != 0)
            {
                if (stack[stack.Count - 1].GetType() != typeof(EndorsedListView))
                    await Navigation.PushModalAsync(new EndorsedListView(model.employeeDetailsId, endorsements.skillsId));
            }
            else
            {
                await Navigation.PushModalAsync(new EndorsedListView(model.employeeDetailsId, endorsements.skillsId));

            }

        }
        #endregion

        #region  Event Handler to Endorse a User

        private async void EndorseButton_Clicked(object sender)
        {

            var selectedItem = (RatingCountModel)sender as RatingCountModel;
            model.ratingValue = 3;
            model.skillsId = selectedItem.skillsId;
            model.employeeDetailsId = EmpId;
            model.ratingByEmployeeId = SignInActivity.raterId;
            bool response = false;
            if (model.employeeDetailsId != SignInActivity.raterId)
            {
                if (!selectedItem.IsLike)
                {
                    //response = await RatingApis.AddRating(model);
                    var baseresponse = await apiManager.AddEndorsements(model).ConfigureAwait(true);
                    if (baseresponse.statusCode == 200)
                    {
                      await App.Current.MainPage. DisplayAlert("Alert", "Thank you for Endorsing!!!", "ok");
                        NewThread();
                    }

                }
                else
                {
                    //  response = await RatingApis.RemoveRating(model);
                    response = await apiManager.RemoveEndorsemnets(model).ConfigureAwait(true);


                    if (response)
                    {
                    await  App.Current.MainPage.DisplayAlert("Alert", "Endorsement removed!!!", "ok");
                        NewThread();
                    }
                }

            }


        }
        #endregion

       
        #region  New thread to update the endorsecount and endorseList
        public  async  void NewThread()
        {
            try
            {

                Thread thread = new Thread(async () =>
                {
                    GetIndividualRatingCount(EmpId);

                });

                thread.Start();
            }
            catch (Exception)
            {

            }
            finally
            {


            }
        }
        #endregion


        #region  function to call endorsments update after any individual endorsements
        public async void GetIndividualRatingCount(int empID)
        {
            var response = await apiManager.GetIndividualEndorsementsCount(empID);

            if(response!=null)
            {

                ratingList.Clear();
                response.ForEach(a =>
                {
                    a.IsLike = a.ratings.Select(c => c.ratingByEmployeeId).ToList().Contains(SignInActivity.raterId);
                    ratingList.Add(a);
                    });
                NotifyPropertyChanged("ratingList");
                
            }
        }
        #endregion


        #region Observable field to change the rating Count
        public ObservableCollection<RatingCountModel> _ratingCount
        {
            get { return ratingList; }
            set
            {
                if (value != null)
                    ratingList = value;
                NotifyPropertyChanged("_ratingCount");
            }
        }
        #endregion




        


    }
}
