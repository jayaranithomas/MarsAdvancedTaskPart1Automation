using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents;
using MarsAdvancedTaskPart1NUnitAutomation.ReportClass;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Test
{
    
    [TestFixture]
    public class LanguageTest : CommonDriver
    {

        List<LanguageDM> languageList;
        LanguageFeatures languageFeaturesObj;
        ProfileNavigationTabs profileNavigationTabsObj;
        LanguageDM languageDM;
        GenerateReport generateReport;
        public LanguageTest()
        {
            languageList = new List<LanguageDM>();
            languageFeaturesObj = new LanguageFeatures();
            profileNavigationTabsObj = new ProfileNavigationTabs();
            languageDM = new LanguageDM();
        }


        [OneTimeSetUp]
        public void ReadJSON()
        {
            generateReport = new GenerateReport();
            generateReport.GenerateExtentReport(@"Reports\LanguageExtentReport.html");
            JSONReader jsonObj = new JSONReader();
            jsonObj.SetDataPath("language");
            languageList = jsonObj.ReadLJsonData();

        }


        [SetUp]
        public void SetUp()
        {
            generateReport.CreateTest();
            profileNavigationTabsObj.SelectLanguageTab();
        }


        [Test, Order(1), Description("This test deletes all Language Records")]
        public void TestDeleteAllLanguageRecords()
        {

            languageFeaturesObj.DeleteAllLanguageRecords();

        }

        [Test, Order(2), Description("This test adds a new Language Record")]
        public void TestCreateNewLanguageRecord()
        {



            languageDM.SetData(languageList[0]);
            languageDM = languageDM.GetData();

            languageFeaturesObj.AddNewLanguage(languageDM);

            

        }

        [Test, Order(3), Description("This test adds new Language Record with NULL data in both fields")]
        public void TestCreateNewLanguageRecordWithAllNullData()
        {


            languageDM.SetData(languageList[1]);
            languageDM = languageDM.GetData();


            languageFeaturesObj.AddNewLanguageRecordWithAllNullData(languageDM);
        }

        [Test, Order(4), Description("This test adds new Language Record without selecting any level and providing valid data in language text box")]
        public void TestCreateNewLanguageRecordWithLevelNotSelected()
        {


            languageDM.SetData(languageList[2]);
            languageDM = languageDM.GetData();

            languageFeaturesObj.AddNewLanguageRecordWithLevelNotSelected(languageDM);

        }

        [Test, Order(5), Description("This test adds new Language Record without entering any language in text box and selecting a valid level from dropdown")]
        public void TestCreateNewLanguageRecordWithValidLevelAndEmptyTextBox()
        {

            languageDM.SetData(languageList[3]);
            languageDM = languageDM.GetData();

            languageFeaturesObj.AddNewLanguageRecordWithValidLevelAndEmptyTextBox(languageDM);

        }
        [Test, Order(6), Description("This test adds an already existing Language Record")]
        public void TestCreateAlreadyExistingLanguageRecord()
        {
            languageDM.SetData(languageList[4]);
            languageDM = languageDM.GetData();

            languageFeaturesObj.AddAlreadyExistingLanguageRecord(languageDM);

        }

        [TearDown]

        public void AfterTest()
        {
            generateReport.UpdateTest();
            Close();

        }
    }
}
