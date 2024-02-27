using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.DataModel
{
    
    public class SkillsDM
    {
        public string skill { get; set; } = string.Empty;
        public string level { get; set; } = string.Empty;


        public void SetData(SkillsDM skillsDM)
        {
            skill = skillsDM.skill;
            level = skillsDM.level;

        }
        public SkillsDM GetData()
        {
            SkillsDM skillsDM = new SkillsDM();
            skillsDM.skill = skill;
            skillsDM.level = level;

            return skillsDM;
        }


    }
}
