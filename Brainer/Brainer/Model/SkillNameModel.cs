using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Brainer.Model
{
	public class SkillNameModel
	{
        public int id { get; set; }
        public String skillName { get; set; }

        [JsonIgnore]
        public bool isChecked { get; set; }
        

    }
}