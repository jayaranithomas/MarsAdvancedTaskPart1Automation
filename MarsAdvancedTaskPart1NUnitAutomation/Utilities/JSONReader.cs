using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Utilities
{
    public class JSONReader
    {
        public string jsonFilePath = string.Empty;


        public List<LanguageDM> ReadLJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            List<LanguageDM> language = JsonConvert.DeserializeObject<List<LanguageDM>>(json)!;
            return language;
        }
        public List<SkillsDM> ReadSJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            List<SkillsDM> skillsList = JsonConvert.DeserializeObject<List<SkillsDM>>(json)!;
            return skillsList;
        }
        public LoginDM ReadLoginJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            LoginDM loginInfo = JsonConvert.DeserializeObject<LoginDM>(json)!;
            return loginInfo;
        }
        public void SetDataPath(string typeDM)
        {
            string path = Assembly.GetCallingAssembly().Location;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            if (typeDM.Equals("language"))
                jsonFilePath = projectPath + @"TestData\LanguageData.json";
            else if (typeDM.Equals("skills"))
                jsonFilePath = projectPath + @"TestData\SkillsData.json";
            else if (typeDM.Equals("shareskills"))
                jsonFilePath = projectPath + @"TestData\ShareSkillsData.json";            
            else if (typeDM.Equals("login"))
                jsonFilePath = projectPath + @"TestData\LoginData.json";
        }
    }
}
