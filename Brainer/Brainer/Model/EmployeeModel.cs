
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Brainer.Model
{
    public class EmloyeeModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string jobTitle { get; set; }
        public int subTeamId { get; set; }
        public string photoBlobId { get; set; }
        public string officeLocation { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

       //[JsonIgnore] 
       // public ImageSource source
       // {
       //     get
       //     {
       //         var uri = new Uri(this.photoBlobId);


       //         if (string.IsNullOrEmpty(this.photoBlobId))
       //             return ImageSource.FromFile("ic_default_profile.png");


       //         else
       //             //  return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(this.photoBlobId)));
       //             return ImageSource.FromUri(uri);      


       //                 }

       // }
       public string getFullName
        {
            get
            {
                return $"{this.firstname} {this.lastname}".ToUpper();
            }
        }
    }

    public class UniqueEmployeeModel
    {

        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string jobTitle { get; set; }
        public int subTeamId { get; set; }
        public string photoFileName { get; set; }
        public string photoBlobId { get; set; }
        public string officeLocation { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
        public bool isDeleted { get; set; }

    }
    

}
