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
        GenerateReport? generateReport;
        public LanguageTest()
        {
            languageList = new List<LanguageDM>();
            languageFeaturesObj = new LanguageFeatures();
            profileNavigationTabsObj = new ProfileNavigationTabs();
        }


        [OneTimeSetUp]
        public void ReadJSON()
        {
            generateReport = new GenerateReport();
            generateReport?.GenerateExtentReport(@"Reports\LanguageExtentReport.html");
            JSONReader jsonObj = new JSONReader();
            jsonObj.SetDataPath("language");
            languageList = jsonObj.ReadLJsonData();

        }


        [SetUp]
        public void SetUp()
        {
            generateReport?.CreateTest();
            profileNavigationTabsObj?.SelectLanguageTab();
        }


        [Test, Order(1), Description("This test deletes all Language Records")]
        public void TestDeleteAllLanguageRecords()
        {

            languageFeaturesObj.DeleteAllLanguageRecords();

        }

        [Test, Order(2), Description("This test adds a new Language Record")]
        public void TestCreateNewLanguageRecord()
        {

            languageFeaturesObj.AddNewLanguage(languageList[0]);
                        
        }

        [Test, Order(3), Description("This test adds new Language Record with NULL data in both fields")]
        public void TestCreateNewLanguageRecordWithAllNullData()
        {

            languageFeaturesObj.AddNewLanguageRecordWithInsufficientData(languageList[1]);
        }

        [Test, Order(4), Description("This test adds new Language Record without selecting any level and providing valid data in language text box")]
        public void TestCreateNewLanguageRecordWithLevelNotSelected()
        {

            languageFeaturesObj.AddNewLanguageRecordWithInsufficientData(languageList[2]);

        }

        [Test, Order(5), Description("This test adds new Language Record without entering any language in text box and selecting a valid level from dropdown")]
        public void TestCreateNewLanguageRecordWithValidLevelAndEmptyTextBox()
        {


            languageFeaturesObj.AddNewLanguageRecordWithInsufficientData(languageList[3]);

        }
        [Test, Order(6), Description("This test adds an already existing Language Record")]
        public void TestCreateAlreadyExistingLanguageRecord()
        {

            languageFeaturesObj.AddAlreadyExistingLanguageRecord(languageList[0]);

        }
        [Test, Order(7), Description("This test adds a duplicate Language with different level")]
        public void TestCreateDuplicateLanguageWithDifferentLevel()
        {

            languageFeaturesObj.AddDuplicateLanguageWithDifferentLevel(languageList[4]);

        }
        [Test, Order(8), Description("This test adds a new Language Name with Special Characters and Numbers")]
        public void TestCreateLanguageRecordWithSpecialCharactersAndNumbers()
        {

            languageFeaturesObj.AddNewLanguage(languageList[5]);

        }
        [Test, Order(9), Description("This test adds a new Language Name with more than 500 characters")]
        public void TestCreateLanguageRecordWithlLongLanguageName()
        {

            languageFeaturesObj.AddNewLanguage(languageList[6]);

        }
        [Test, Order(10), Description("This test adds a new Language Name with more than 500 characters")]
        public void TestCreateLanguageRecordWithOnlySpacesInLanguageTextBox()
        {

            languageFeaturesObj.AddNewLanguage(languageList[7]);

        }
        [Test, Order(11), Description("This test tries to add fifth language record")]
        public void TestCreateFifthLanguageRecord()
        {

            languageFeaturesObj.AddFifthLanguage();

        }
        [Test, Order(12), Description("This test Cancels a Language record before adding")]
        public void TestCancelAddLanguageRecord()
        {

            languageFeaturesObj.CancelAddLanguageRecord(languageList[8]);

        }
        [Test, Order(13), Description("This test updates an existing Language Record with all fields edited")]
        public void TestUpdateLanguageRecordWithBothFieldsEdited()
        {

            languageFeaturesObj.UpdateExistingLanguageRecordWithFieldsEdited(languageList[9]);

        }
        [Test, Order(14), Description("This test updates an existing Language Record without editing any fields")]
        public void TestUpdateLanguageRecordWithNoFieldsEdited()
        {

            languageFeaturesObj.UpdateExistingLanguageRecordWithNoFieldsEdited();

        }
        [Test, Order(15), Description("This test updates existing Language Record with NULL data in both fields")]
        public void TestUpdateLanguageRecordWithAllNullData()
        {

            languageFeaturesObj.UpdateLanguageRecordWithInsufficientData(languageList[1]);
        }
        [Test, Order(16), Description("This test updates existing Language Record by deleting the language in text box and not changing the level")]
        public void TestUpdateLanguageRecordWithValidLevelAndEmptyTextBox()
        {


            languageFeaturesObj.UpdateLanguageRecordWithInsufficientData(languageList[3]);

        }
        [Test, Order(17), Description("This test updates existing Language Record without editing language in text box and selecting any level")]
        public void TestUpdateLanguageRecordWithoutSelectingLevel()
        {


            languageFeaturesObj.UpdateLanguageRecordWithInsufficientData(languageList[10]);

        }
        [Test, Order(18), Description("This test updates existing Language Record by changing only the language")]
        public void TestUpdateLanguageRecordByChangingOnlyLanguage()
        {


            languageFeaturesObj.UpdateExistingLanguageRecordWithFieldsEdited(languageList[11]);

        }
        [Test, Order(19), Description("This test updates existing Language Record by changing only level")]
        public void TestUpdateLanguageRecordByChangingOnlyLevel()
        {


            languageFeaturesObj.UpdateExistingLanguageRecordWithFieldsEdited(languageList[12]);

        }
        [Test, Order(20), Description("This test updates existing Language Record with an existing language name with different level")]
        public void TestUpdateLanguageRecordWithExistingLanguageName()
        {


            languageFeaturesObj.UpdateExistingLanguageRecordWithExistingLanguageName(languageList[13], languageList[14]);

        }
        [Test, Order(21), Description("This test updates existing Language Record with Special Characters and Numbers")]
        public void TestUpdateLanguageRecordWithSpecialCharacters()
        {


            languageFeaturesObj.UpdateExistingLanguageRecordWithFieldsEdited(languageList[15]);

        }
        [Test, Order(22), Description("This test updates existing Language Record with more than 500 characters")]
        public void TestUpdateLanguageRecordWithLongLanguageName()
        {


            languageFeaturesObj.UpdateExistingLanguageRecordWithFieldsEdited(languageList[16]);

        }
        [Test, Order(23), Description("This test updates existing Language Record with more than 500 characters")]

        public void TestUpdateLanguageRecordWithOnlySpacesInLanguageName()
        {


            languageFeaturesObj.UpdateExistingLanguageRecordWithFieldsEdited(languageList[17]);

        }
        [Test, Order(24), Description("This test Cancels a Language record before updating")]
        public void TestCancelUpdateLanguageRecord()
        {

            languageFeaturesObj.CancelUpdateLanguageRecord(languageList[18]);

        }

        [TearDown]

        public void AfterTest()
        {
            generateReport?.UpdateTest();
            Close();

        }
    }
}
