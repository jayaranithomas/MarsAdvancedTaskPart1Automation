using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.DataModel
{
    
    public class LanguageDM
    {
        public string language { get; set; } = string.Empty;
        public string level { get; set; } = string.Empty;
        

        public void SetData(LanguageDM languageDM)
        {
            language = languageDM.language;
            level = languageDM.level;
            
        }
        public LanguageDM GetData()
        {
            LanguageDM languageDM = new LanguageDM();
            languageDM.language = language;
            languageDM.level = level;
            
            return languageDM;
        }


    }
}
