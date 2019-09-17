using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Repository
{
    class ApiPath
    {
        public static string BASEURL= "https://braineruatapi.azurewebsites.net";
        public static string GETSECTOR = "/api/sectors";
        public static string POSTADDSKILLS = "/api/SkillDetails/BulkUpdate";
        public static string GETALLSKILLS = "/api/Skills";
        public static string GETDOWNLOADDATA = "/download/";
        public static string POSTLOGIN = "/api/Login";
        public static string POSTSENDDOCUMENT = "/api/senddocument";
        public static string GETDOCUMENTDETAILS = "/api/DocumentDetails/";
        public static string POSTRATINGS = "/api/Ratings";
        public static string POSTREMOVEENDORSEMENTS = "/api/removeendorsement/{0}?skillsId={1}&loggedUserId={2}";
        public static string GETENDORSEMENTSLISTS = "/api/endorsements/";
        public static string GETINDIVIDIUALSKILLSENDORSEMENTCOUNT = "/api/endorsements/";
        public static string GETINDIVIDUALEMPLOYEEDETAILBYID = "/api/EmployeeDetails/";
        public static string GETDOCUMNETSBYSECID = "/api/sectordocuments/";


        public static string GetDocumentsBySecId(int secId)
        {

            return BASEURL + GETDOCUMNETSBYSECID + secId;
        }

        public static string GetIndividualEmployeeDetailById(int empID)
        {
            return BASEURL + GETINDIVIDUALEMPLOYEEDETAILBYID + empID; 
        }

        public static string GetAllSkills()
        {
            return BASEURL + GETALLSKILLS;
        }

        public static string PostAddSKills()
        {
            return BASEURL + POSTADDSKILLS;
        }

        public static string GetSector()
        {
            return BASEURL + GETSECTOR;
        }

        public static string GetDownloadData(int ID,bool value)
        {
            return BASEURL + GETDOWNLOADDATA + ID+"?documents ="+ value;
        }

        public static string PostLogin()
        {
            return BASEURL + POSTLOGIN;
        }


        public static string PostSendDocument()
        {
            return BASEURL + POSTSENDDOCUMENT;
        }

        public static string GetDocumentDetails(int ID)
        {
            return BASEURL + GETDOCUMENTDETAILS + ID;
        }

        public static string PostRating()
        {
            return BASEURL + POSTRATINGS;
        }

        public static string PostRemoveEndorsements()
        {
            return BASEURL + POSTREMOVEENDORSEMENTS;
        }

        public static string GetEndorsementsList(int skillID,int empID)
        {
            return BASEURL + GETENDORSEMENTSLISTS + skillID + "/" + empID;
        }

        public static string GetIndividualSkillsEndorsementsCount(int empID)
        {
            return BASEURL + GETINDIVIDIUALSKILLSENDORSEMENTCOUNT + empID;
        }
    }
}
