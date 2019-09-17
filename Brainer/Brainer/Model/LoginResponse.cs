using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
   public class LoginResponse
    {
        public int userId { get; set; }
        public int employeeId { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string jobTitle { get; set; }
        public int subTeamId { get; set; }
        public string photoFileName { get; set; }
        public string photoBlobId { get; set; }
        public string officeLocation { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
