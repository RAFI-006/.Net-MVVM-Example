using Brainer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Brainer.Data
{
    public interface IRestServices
    {
        // sector Id to download data
        Task<GenericResponse<List<SectorModel>>> GetSectorId();
        // get documents By Sector Id
        Task<GenericResponse<DocumentDataModel>> GetDocumentsBySecId(int secId);
        //Signin Usera
        Task<GenericResponse<LoginResponse>> SignIn(LoginModel loginModel);
        //Main data which is downloaded according to the sector Id
        Task<GenericResponse<BaseResponseModel>> GetDownloadedData(int sectorId,bool value);
        //Adding Endorsemenents to particular skills
        Task<GenericResponse<AddRatingModel>> AddEndorsements(AddRatingModel addRatingModel);
        //Removing Endorsements to particular skills
        Task<bool> RemoveEndorsemnets(AddRatingModel addRatingModel);
        //Show Endorsemnets Lists
        Task<EndorseGenericModel> ShowEndorsementsList(int empId, int skillId);
        //Update Skills dynamically
        Task<GenericResponse<dynamic>> UpdateSkills(SkillsUpdateModel skillsUpdateModel);
        //Get All Exisitng Skills
        Task<ObservableCollection<SkillNameModel>> GetAllSkills();
        //Get Individual Endorsments Count 
        Task<List<RatingCountModel>> GetIndividualEndorsementsCount(int empId);
        //Share Document 
        Task<bool> ShareDocument(SendDocumentModel user);
        //View Document in the document section
        Task<GenericResponse<DocumentModel>> ViewPdfDocument(int id);

        //getting employee details by their Id
        Task<UniqueEmployeeModel> GetIndividualEmployeeDetailById(int empID);

    }
}
