using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
   public class SendDocumentModel
    {
        public string email { get; set; }
        public string subject { get; set; }
        public int documentDetailId { get; set; }
    }
}
