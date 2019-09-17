using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
    public class RatingModel
    {
        public int id { get; set; }
        public int  employeeDetailsId { get; set; }
        public int skillsId { get; set; }
        public int ratingValue { get; set; }
        public int ratingByEmployeeId { get; set; }
        public string ratingEmployeeName { get; set;}

    }
}
