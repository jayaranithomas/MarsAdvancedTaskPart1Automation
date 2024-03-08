using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents;
using MarsAdvancedTaskPart1NUnitAutomation.ReportClass;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsShareSkillComponent;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1NUnitAutomation.Test
{

    [TestFixture]
    public class ShareSkillsTest : CommonDriver
    {
        bool skipTearDown = false;
        List<ShareSkillsDM> shareSkillList;
        ShareSkillFeatures? shareSkillFeaturesObj;
        GenerateReport? generateReport;

        public ShareSkillsTest()
        {
            shareSkillList = new List<ShareSkillsDM>();
        }


        [OneTimeSetUp]
        public void ReadJSON()
        {
            generateReport = new GenerateReport();
            generateReport?.GenerateExtentReport(@"Reports\ShareSkillsExtentReport.html");
            JSONReader jsonObj = new JSONReader();
            jsonObj.SetDataPath("shareskills");
            shareSkillList = jsonObj.ReadShareJsonData();

        }


        [SetUp]
        public void SetUp()
        {
            generateReport?.CreateTest();
            shareSkillFeaturesObj = new ShareSkillFeatures();
            skipTearDown = false;
        }


        [Test, Order(1), Description("This test adds a Share skill Listing")]
        public void TestAddShareSkillListing()
        {

            shareSkillFeaturesObj?.AddNewShareSkill(shareSkillList[0]);

        }
        [Test, Order(2), Description("This test adds a Share skill Listing with NO value in title field")]
        public void TestAddShareSkillListingWithoutTitle()
        {

            shareSkillFeaturesObj?.AddShareSkillWithInsufficientData(shareSkillList[1]);

        }
        [Test, Order(3), Description("This test adds a Share skill Listing with special characters in title field (except first character)")]
        public void TestAddShareSkillListingWithSpecialCharactersInTitleExceptFirstCharacter()
        {

            shareSkillFeaturesObj?.AddShareSkillWithSpecialCharacters(shareSkillList[2]);

        }
        [Test, Order(4), Description("This test adds a Share skill Listing with first character as a special characters in title field")]
        public void TestAddShareSkillListingWithFirstCharacterAsSpecialCharactersInTitle()
        {

            shareSkillFeaturesObj?.AddShareSkillWithSpecialCharacters(shareSkillList[3]);

        }
        [Test, Order(5), Description("This test adds a Share skill Listing with more than 100 characters")]
        public void TestAddShareSkillListingWithTitleMoreThan100Characters()
        {

            shareSkillFeaturesObj?.AddShareSkillWithTitleMoreThan100Characters(shareSkillList[4]);

        }
        [Test, Order(6), Description("This test adds a Share skill Listing with NO value in description field")]
        public void TestAddShareSkillListingWithoutDescription()
        {

            shareSkillFeaturesObj?.AddShareSkillWithInsufficientData(shareSkillList[5]);

        }
        [Test, Order(7), Description("This test adds a Share skill Listing with special characters in description field (except first character)")]
        public void TestAddShareSkillListingWithSpecialCharactersInDescriptionExceptFirstCharacter()
        {

            shareSkillFeaturesObj?.AddShareSkillWithSpecialCharacters(shareSkillList[6]);

        }
        [Test, Order(8), Description("This test adds a Share skill Listing with first character as a special characters in description field")]
        public void TestAddShareSkillListingWithFirstCharacterAsSpecialCharactersInDescription()
        {

            shareSkillFeaturesObj?.AddShareSkillWithSpecialCharacters(shareSkillList[7]);

        }
        [Test, Order(9), Description("This test adds a Share skill Listing with more than 600 characters in description field")]
        public void TestAddShareSkillListingWithDescriptionMoreThan600Characters()
        {

            shareSkillFeaturesObj?.AddShareSkillWithDescriptionMoreThan600Characters(shareSkillList[8]);

        }
        [Test, Order(10), Description("This test adds a Share skill Listing without selecting a category")]
        public void TestAddShareSkillListingWithoutCategory()
        {

            shareSkillFeaturesObj?.AddShareSkillWithInsufficientData(shareSkillList[9]);

        }
        [Test, Order(11), Description("This test adds a Share skill Listing without selecting a Subcategory")]
        public void TestAddShareSkillListingWithoutSubcategory()
        {
            shareSkillFeaturesObj?.SetSubCategoryFlag();
            shareSkillFeaturesObj?.AddShareSkillWithInsufficientData(shareSkillList[10]);

        }
        [Test, Order(12), Description("This test adds a Share skill Listing without entering any tag value")]
        public void TestAddShareSkillListingWithoutAnyTag()
        {
            shareSkillFeaturesObj?.AddShareSkillWithInsufficientData(shareSkillList[11]);

        }
        [Test, Order(13), Description("This test adds a Share skill Listing with multiple tag entries")]
        public void TestAddShareSkillListingWithMultipleTags()
        {
            shareSkillFeaturesObj?.AddShareSkillWithMultipleTags(0);

        }
        [Test, Order(14), Description("This test adds a Share skill Listing with duplicate tag entries")]
        public void TestAddShareSkillListingWithDuplicateTags()
        {
            shareSkillFeaturesObj?.AddShareSkillWithDuplicateTags(0);

        }
        [Test, Order(15), Description("This test adds a Share skill Listing with special characters in tag field")]
        public void TestAddShareSkillListingWithSpecialCharactersInTags()
        {
            shareSkillFeaturesObj?.AddShareSkillWithSpecialCharactersInTags(0);

        }
        [Test, Order(16), Description("This test adds a Share skill Listing with spaces only in tag field")]
        public void TestAddShareSkillListingWithSpacesOnlyInTags()
        {
            shareSkillFeaturesObj?.AddShareSkillWithSpacesOnlyInTags(0);

        }
        [Test, Order(17), Description("This test deletes tags from Share skill Listing")]
        public void TestDeleteShareSkillListingTags()
        {
            shareSkillFeaturesObj?.DeleteShareSkillListingTags(0);

        }
        [Test, Order(18), Description("This test assigns a start date older than the current date in Share skill Listing")]
        public void TestAddShareSkillListingWithStartDateOlderThanCurrentDate()
        {
            shareSkillFeaturesObj?.AddShareSkillWithInsufficientData(shareSkillList[12]);

        }
        [Test, Order(19), Description("This test assigns an end date older than the start date in Share skill Listing")]
        public void TestAddShareSkillListingWithEndDateOlderThanStartDate()
        {
            shareSkillFeaturesObj?.AddShareSkillWithInsufficientData(shareSkillList[13]);

        }
        [Test, Order(20), Description("This test adds a Share skill Listing without entering any Skill-exchange tags")]
        public void TestAddShareSkillListingWithoutAnySkillExchangeTags()
        {
            shareSkillFeaturesObj?.AddShareSkillWithInsufficientData(shareSkillList[14]);

        }
        [Test, Order(21), Description("This test adds a Share skill Listing without uploading any work samples")]
        public void TestAddShareSkillListingWithoutUploadingWorkSample()
        {
            shareSkillFeaturesObj?.AddNewShareSkill(shareSkillList[0]);

        }
        [Test, Order(22), Description("This test adds a Share skill Listing by selecting Credit for Skill-Trade")]
        public void TestAddShareSkillListingBySelectingCredit()
        {
            shareSkillFeaturesObj?.AddNewShareSkill(shareSkillList[15]);

        }
        [Test, Order(23), Description("This test cancels a Share skill Listing before adding")]
        public void TestCancelShareSkillListing()
        {
            skipTearDown = true;
            shareSkillFeaturesObj?.CancelShareSkillListing(shareSkillList[15]);
        }

        [TearDown]

        public void AfterTest()
        {
            if (!skipTearDown)
                generateReport?.UpdateTest();
            Close();
        }
    }
}
