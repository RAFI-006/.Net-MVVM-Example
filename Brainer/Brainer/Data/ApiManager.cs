using Brainer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Brainer.Data
{
    class ApiManager
    {
        IRestServices restService;
        public ApiManager(IRestServices service)
        {
            restService = service;
        }

       

        #region /login
        public Task<GenericResponse<LoginResponse>> SignIn(LoginModel loginModel)
        {
            return restService.SignIn(loginModel);

        }
        #endregion


        
        
        
        #region /get Sector Id to download data
        public Task<GenericResponse<List<SectorModel>>> GetSectorId()
        {
            return restService.GetSectorId();
        }
        #endregion


        #region /get Sector Id to download data
        public async Task<BaseResponseModel> GetDownloadedData(int sectorId,bool value)
        {
          var response = await restService.GetDownloadedData(sectorId,value);
        
            return response.data;
        }
        #endregion

        #region /get Sector Id to download data
        public async Task<GenericResponse<DocumentDataModel>> GetDocumentsBySecId(int sectorId)
        {
            var response = await restService.GetDocumentsBySecId(sectorId);

            return response;
        }
        #endregion

        #region //Add endorsements of a particular employee
        public Task<GenericResponse<AddRatingModel>> AddEndorsements(AddRatingModel addRatingModel)
        {
            return  restService.AddEndorsements(addRatingModel);
        }
        #endregion

        #region //Remove endorsments of a particular emoloyee
        public    Task<bool> RemoveEndorsemnets(AddRatingModel addRatingModel)
        {
            return  restService.RemoveEndorsemnets(addRatingModel);
        }
        #endregion

        #region // Show list of who endorsed for a particular skills of employee
        public   Task<EndorseGenericModel> ShowEndorsementsList(int empId, int skillId)
        {
            return restService.ShowEndorsementsList(empId, skillId);
        }
        #endregion

        #region Update or add Skills of a employeee
        public Task<GenericResponse<dynamic>> UpdateSkills(SkillsUpdateModel skillsUpdateModel)
        {
            return restService.UpdateSkills(skillsUpdateModel);

        }
        #endregion

        #region get All existing skills from database
        public Task<ObservableCollection<SkillNameModel>> GetAllSkills()
        {
            return restService.GetAllSkills();
        }
        #endregion


        #region // Individual Endorsments List of a employee
        public Task<List<RatingCountModel>> GetIndividualEndorsementsCount(int empId)
        {
            return restService. GetIndividualEndorsementsCount(empId);
        }
        #endregion

        
        #region //Share document or papers via emial
        public Task<bool> ShareDocument(SendDocumentModel user)
        {
            return restService.ShareDocument(user);
        }
        #endregion


        #region // View Pdf Document
        public Task<GenericResponse<DocumentModel>> ViewPdfDocument(int id)
        {
            return restService.ViewPdfDocument(id);
        }
        #endregion

        #region
    public    Task<UniqueEmployeeModel> GetIndividualEmployeeDetailById(int empID)
        {
            return restService.GetIndividualEmployeeDetailById(empID);
        }
        #endregion





    }
}
