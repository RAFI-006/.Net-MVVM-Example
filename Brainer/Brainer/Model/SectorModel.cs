using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
   public class SectorModel
    {
        public int id { get; set; }
        public string sectorName {get; set;}
        public int createdBy {get; set;}
        public DateTime createdDate {get; set;}
        public int updatedBy {get; set;}
        public DateTime updatedDate {get; set;}
        public bool isDeleted { get; set; }
    }
}
