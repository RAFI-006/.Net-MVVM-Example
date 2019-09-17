using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
   public class BaseResponseModel
    {
            public List<EmployeeDetailsModel> employees { get; set; }
            public List<DocumentModel> documents { get; set; }
        
    }
}
