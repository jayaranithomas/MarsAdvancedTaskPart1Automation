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
    public class SkillsTest : CommonDriver
    {

        List<SkillsDM> skillList;
        SkillsFeatures skillsFeaturesObj;
        ProfileNavigationTabs profileNavigationTabsObj;
        GenerateReport? generateReport;
        public SkillsTest()
        {
            skillList = new List<SkillsDM>();
            skillsFeaturesObj = new SkillsFeatures();
            profileNavigationTabsObj = new ProfileNavigationTabs();
        }


        [OneTimeSetUp]
        public void ReadJSON()
        {
            generateReport = new GenerateReport();
            generateReport?.GenerateExtentReport(@"Reports\SkillsExtentReport.html");
            JSONReader jsonObj = new JSONReader();
            jsonObj.SetDataPath("skills");
            skillList = jsonObj.ReadSJsonData();

        }


        [SetUp]
        public void SetUp()
        {
            generateReport?.CreateTest();
            profileNavigationTabsObj?.SelectSkillsTab();
        }


        [Test, Order(1), Description("This test deletes all Skill Records")]
        public void TestDeleteAllSkillRecords()
        {

            skillsFeaturesObj.DeleteAllSkillRecords();

        }
        [Test, Order(2), Description("This test adds a new Skill Record")]
        public void TestCreateNewSkillRecord()
        {
            
            skillsFeaturesObj.AddNewSkill(skillList[0]);

        }
        [Test, Order(3), Description("This test adds new Skill Record with NULL data in both fields")]
        public void TestCreateNewSkillRecordWithAllNullData()
        {

            skillsFeaturesObj.AddNewSkillRecordWithInsufficientData(skillList[1]);
        }
        [Test, Order(4), Description("This test adds new Skill Record without selecting any level and providing valid data in skill text box")]
        public void TestCreateNewSkillRecordWithLevelNotSelected()
        {

            skillsFeaturesObj.AddNewSkillRecordWithInsufficientData(skillList[2]);

        }
        [Test, Order(5), Description("This test adds new Skill Record without entering any skill in text box and selecting a valid level from dropdown")]
        public void TestCreateNewSkillRecordWithValidLevelAndEmptyTextBox()
        {


            skillsFeaturesObj.AddNewSkillRecordWithInsufficientData(skillList[3]);

        }
        [Test, Order(6), Description("This test adds an already existing Skill Record")]
        public void TestCreateAlreadyExistingSkillRecord()
        {

            skillsFeaturesObj.AddAlreadyExistingSkillRecord(skillList[0]);

        }
        [Test, Order(7), Description("This test adds a duplicate Skill with different level")]
        public void TestCreateDuplicateSkillWithDifferentLevel()
        {

            skillsFeaturesObj.AddDuplicateSkillWithDifferentLevel(skillList[4]);

        }
        [Test, Order(8), Description("This test adds a new Skill Name with Special Characters and Numbers")]
        public void TestCreateSkillRecordWithSpecialCharactersAndNumbers()
        {

            skillsFeaturesObj.AddNewSkill(skillList[5]);

        }
        [Test, Order(9), Description("This test adds a new Skill with more than 500 characters")]
        public void TestCreateSkillRecordWithlLongName()
        {

            skillsFeaturesObj.AddNewSkill(skillList[6]);

        }
        [Test, Order(10), Description("This test adds a new Skill with Only Spaces")]
        public void TestCreateLanguageRecordWithOnlySpacesInSkillTextBox()
        {

            skillsFeaturesObj.AddNewSkill(skillList[7]);

        }
        [Test, Order(11), Description("This test Cancels a Skill record before adding")]
        public void TestCancelAddSkillRecord()
        {

            skillsFeaturesObj.CancelAddSkillRecord(skillList[8]);

        }
        [Test, Order(12), Description("This test updates an existing Skill Record with both fields edited")]
        public void TestUpdateSkillRecordWithBothFieldsEdited()
        {

            skillsFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[8]);

        }
        [Test, Order(13), Description("This test updates an existing Skill Record without editing any fields")]
        public void TestUpdateSkillRecordWithNoFieldsEdited()
        {

            skillsFeaturesObj.UpdateExistingSkillRecordWithNoFieldsEdited();

        }
        [Test, Order(14), Description("This test updates existing Skill Record with NULL data in both fields")]
        public void TestUpdateSkillRecordWithAllNullData()
        {

            skillsFeaturesObj.UpdateSkillRecordWithInsufficientData(skillList[1]);
        }
        [Test, Order(15), Description("This test updates existing Skill Record by deleting the skill in text box and not changing the level")]
        public void TestUpdateSkillRecordWithValidLevelAndEmptyTextBox()
        {


            skillsFeaturesObj.UpdateSkillRecordWithInsufficientData(skillList[9]);

        }
        [Test, Order(16), Description("This test updates existing Skill Record without editing skill in text box and not selecting any level")]
        public void TestUpdateSkillRecordWithoutSelectingLevel()
        {


            skillsFeaturesObj.UpdateSkillRecordWithInsufficientData(skillList[10]);

        }
        [Test, Order(17), Description("This test updates existing Skill Record by changing only the skill")]
        public void TestUpdateSkillRecordByChangingOnlySkill()
        {


            skillsFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[11]);

        }
        [Test, Order(18), Description("This test updates existing Skill Record by changing only level")]
        public void TestUpdateSkillRecordByChangingOnlyLevel()
        {


            skillsFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[12]);

        }
        [Test, Order(19), Description("This test updates existing Skill Record with an existing skill name with different level")]
        public void TestUpdateSkillRecordWithExistingSkillName()
        {


            skillsFeaturesObj.UpdateExistingSkillRecordWithExistingSkillName(skillList[13], skillList[14]);

        }
        [Test, Order(20), Description("This test updates existing Skill Record with Special Characters and Numbers")]
        public void TestUpdateSkillRecordWithSpecialCharacters()
        {


            skillsFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[15]);

        }
        [Test, Order(21), Description("This test updates existing Skill Record with more than 500 characters")]
        public void TestUpdateLanguageRecordWithLongLanguageName()
        {


            skillsFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[16]);

        }
        [Test, Order(22), Description("This test updates existing Skill Record with only Spaces")]

        public void TestUpdateSkillRecordWithOnlySpacesInSkill()
        {


            skillsFeaturesObj.UpdateExistingSkillRecordWithFieldsEdited(skillList[17]);

        }
        [Test, Order(23), Description("This test Cancels a Skill record before updating")]
        public void TestCancelUpdateSkillRecord()
        {

            skillsFeaturesObj.CancelUpdateSkillRecord(skillList[18]);

        }

        [TearDown]

        public void AfterTest()
        {
            generateReport?.UpdateTest();
            Close();

        }
    }
}
