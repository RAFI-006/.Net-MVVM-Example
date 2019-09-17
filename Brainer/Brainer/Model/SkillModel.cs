using System;
using System.Collections.Generic;
using System.Text;

namespace Brainer.Model
{
    public class SkillModel
    {
        public string skillName { get; set;}
        public string average { get; set;}
        public int    skillId { get; set; }
        public List<RatingModel> ratings { get; set; }
    }
}
