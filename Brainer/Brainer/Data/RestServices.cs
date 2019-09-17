using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Brainer.Model;
using Brainer.Repository;
using Brainer.Utils;
using Newtonsoft.Json;

namespace Brainer.Data
{
    class RestServices : IRestServices
    {
        #region adding endorsments for particular skills of employee
        public async Task<GenericResponse<AddRatingModel>> AddEndorsements(AddRatingModel addRatingModel)
        {
            GenericResponse<AddRatingModel> savedUserResponse = new GenericResponse<AddRatingModel>();
            HttpResponseMessage response = null;
            var uri = new Uri(string.Format(ApiPath.PostRating(), string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(addRatingModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient _client = new HttpClient();
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var respContent = await response.Content.ReadAsStringAsync();
                    savedUserResponse = JsonConvert.DeserializeObject<GenericResponse<AddRatingModel>>(respContent);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return savedUserResponse;
        }
        #endregion

        # region
        public async Task<ObservableCollection<SkillNameModel>> GetAllSkills()
        {
            var allSkilsList = new ObservableCollection<SkillNameModel>();
            Uri uri = new Uri(string.Format(ApiPath.GetAllSkills(), string.Empty));

            GenericResponse<ObservableCollection<SkillNameModel>> rootObjectModel = await HttpUtils.GetMyRequest<GenericResponse<ObservableCollection<SkillNameModel>>>(uri);

            foreach (var skills in rootObjectModel.data)
            {

                allSkilsList.Add(skills);

            }

            return allSkilsList;
        }

        #endregion

        #region get all data after download button cklicked
        public async Task<GenericResponse<BaseResponseModel>> GetDownloadedData(int sectorId,bool value)
        {
            var uri = new Uri(string.Format(ApiPath.GetDownloadData(sectorId,value), string.Empty));
            GenericResponse<BaseResponseModel> rootObjectModel = await HttpUtils.GetMyRequest<GenericResponse<BaseResponseModel>>(uri);

            //List<DocumentModel> documnetsList = rootObjectModel.data.documents;
            return rootObjectModel;

        }
        #endregion
        #region / Get Individual Employee Detail By Id
        public async Task<UniqueEmployeeModel> GetIndividualEmployeeDetailById(int empID)
        {

            var uri = new Uri(string.Format(ApiPath.GetIndividualEmployeeDetailById(empID), string.Empty));
            GenericResponse<UniqueEmployeeModel> rootObjectModel = await HttpUtils.GetMyRequest<GenericResponse<UniqueEmployeeModel>>(uri);

            return rootObjectModel.data;



        }
        #endregion

        #region 
        public async Task<List<RatingCountModel>> GetIndividualEndorsementsCount(int empId)
        {
            var uri = new Uri(string.Format(ApiPath.GetIndividualSkillsEndorsementsCount(empId), string.Empty));
            GenericResponse<List<RatingCountModel>> rootObjectModel = await HttpUtils.GetMyRequest<GenericResponse<List<RatingCountModel>>>(uri);
            return rootObjectModel.data;

        }
        #endregion


        #region /getting SetorId 
        public async Task<GenericResponse<List<SectorModel>>> GetSectorId()
        {
            var uri = new Uri(string.Format(ApiPath.GetSector(), string.Empty));
            GenericResponse<List<SectorModel>> rootObjectModel = await HttpUtils.GetMyRequest<GenericResponse<List<SectorModel>>>(uri);

            return rootObjectModel;




        }
        #endregion

        #region Remove Endorsments of a particular Skills 
        public async Task<bool> RemoveEndorsemnets(AddRatingModel addRatingModel)
        {

            GenericResponse<bool> savedUserResponse = new GenericResponse<bool>();
            HttpResponseMessage response = null; var uri = new Uri(string.Format(ApiPath.PostRemoveEndorsements(), addRatingModel.employeeDetailsId, addRatingModel.skillsId, addRatingModel.ratingByEmployeeId));
            try
            {
                HttpClient _client = new HttpClient();
                response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var respContent = await response.Content.ReadAsStringAsync();
                    savedUserResponse = JsonConvert.DeserializeObject<GenericResponse<bool>>(respContent);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return savedUserResponse.data;



        }
        #endregion

        #region Share Document Url via Email
        public async Task<bool> ShareDocument(SendDocumentModel user)
        {


            GenericResponse<bool> savedUserResponse = new GenericResponse<bool>();
            HttpResponseMessage response = null;
            var uri = new Uri(string.Format(ApiPath.PostSendDocument(), string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient _client = new HttpClient();
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var respContent = await response.Content.ReadAsStringAsync();
                    savedUserResponse = JsonConvert.DeserializeObject<GenericResponse<bool>>(respContent);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return savedUserResponse.data;




        }
        #endregion

        #region  Show Who Endorse of a particular skills in a List
        public async Task<EndorseGenericModel> ShowEndorsementsList(int empId, int skillId)
        {
            Uri uri = new Uri(string.Format(ApiPath.GetEndorsementsList(skillId, empId), string.Empty));
            GenericResponse<EndorseGenericModel> rootObjectModel = await HttpUtils.GetMyRequest<GenericResponse<EndorseGenericModel>>(uri);

            return rootObjectModel.data;

        }
        #endregion



        #region /Login 
        public async Task<GenericResponse<LoginResponse>> SignIn(LoginModel loginModel)
        {

            var savedUserResponse = new GenericResponse<LoginResponse>();
            var uri = new Uri(string.Format(ApiPath.PostLogin(), string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(loginModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                HttpClient _client = new HttpClient();

                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var respContent = await response.Content.ReadAsStringAsync();
                    savedUserResponse = JsonConvert.DeserializeObject<GenericResponse<LoginResponse>>(respContent);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return savedUserResponse;






        }
        #endregion

        #region // Update or Add User Skills from the App
        public async Task<GenericResponse<dynamic>> UpdateSkills(SkillsUpdateModel skillsUpdateModel)
        {
            var savedUserResponse = new GenericResponse<dynamic>();
            var uri = new Uri(string.Format(ApiPath.PostAddSKills(), string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(skillsUpdateModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                HttpClient _client = new HttpClient();

                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var respContent = await response.Content.ReadAsStringAsync();
                    savedUserResponse = JsonConvert.DeserializeObject<GenericResponse<dynamic>>(respContent);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return savedUserResponse;

        }
        #endregion
       
        
        #region // View Pdf Services
        public async Task<GenericResponse<DocumentModel>> ViewPdfDocument(int id)
        {
            var uri = new Uri(String.Format(ApiPath.GetDocumentDetails(id), string.Empty));
            GenericResponse<DocumentModel> rootObjectModel = await HttpUtils.GetMyRequest<GenericResponse<DocumentModel>>(uri);

            return rootObjectModel;

        }

        public  async Task<GenericResponse<DocumentDataModel>> GetDocumentsBySecId(int secId)
        {
            var uri = new Uri(string.Format(ApiPath.GetDocumentsBySecId(secId), string.Empty));
            GenericResponse<DocumentDataModel> rootObjectModel = await HttpUtils.GetMyRequest<GenericResponse<DocumentDataModel>>(uri);
            return rootObjectModel;

        }
        #endregion


    }
}