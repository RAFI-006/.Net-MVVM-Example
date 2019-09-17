using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
  public  class SkillsUpdateModel
    {
       public int employeeId { get; set; }
       public List<int> employeeSkillsIds { get; set;}

    }
}
