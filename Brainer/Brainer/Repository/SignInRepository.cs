using Brainer.Data;
using Brainer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brainer.Repository
{
    class SignInRepository
    {
        ApiManager apiManager;
      public  SignInRepository()
        {
            apiManager = new ApiManager(new RestServices());
        }

        #region /getSector Id for download data
        public Task<GenericResponse<List<SectorModel>>> GetSectorId()
        {
            return apiManager.GetSectorId();
        }
        #endregion



        #region /login implementation
        public Task<GenericResponse<LoginResponse>> SignIn(LoginModel loginModel)
        {
            return apiManager.SignIn(loginModel);
        }
        #endregion
    }
}
