using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
  public  class DocumentModel
    {
        public int id { get; set; }
        public int subDocumentId { get; set; }
        public string subDocumentName { get; set; }
        public int employeeId { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public DateTime uploadedDate { get; set; }
        public string documentBlob { get; set; }

     
    }
}
