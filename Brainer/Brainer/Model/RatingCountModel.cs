using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
 public   class RatingCountModel
    {
        public string skillName { get; set; }
        public int skillsId { get; set; }
        public int count { get; set; }
        public List<RatingModel> ratings { get; set; }
        public bool IsLike { get; set; } = false;
    }
}
