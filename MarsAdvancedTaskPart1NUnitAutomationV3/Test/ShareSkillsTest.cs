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
using OpenQA.Selenium;
using MarsAdvancedTaskPart1NUnitAutomation.Steps;

namespace MarsAdvancedTaskPart1NUnitAutomation.Test
{

    [TestFixture]
    public class ShareSkillsTest : CommonDriver
    {
        List<ShareSkillsDM> shareSkillList;
        ShareSkillSteps? shareSkillStepsObj = new ShareSkillSteps();

        public ShareSkillsTest()
        {
            shareSkillList = new List<ShareSkillsDM>();
        }
        public void ReadJSON()
        {
            jsonObj.SetDataPath("shareskills");
            shareSkillList = jsonObj.ReadShareJsonData();
        }


        [Test, Order(1), Description("This test adds a Share skill Listing")]
        public void TestAddShareSkillListing()
        {
            ReadJSON();
            shareSkillStepsObj?.ShareSkillRenderStep();
            shareSkillStepsObj?.AddNewShareSkill(shareSkillList[0]);

        }
        [Test, Order(2), Description("This test adds a Share skill Listing with NO value in title field")]
        public void TestAddShareSkillListingWithoutTitle()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithInsufficientData(shareSkillList[1]);

        }
        [Test, Order(3), Description("This test adds a Share skill Listing with special characters in title field (except first character)")]
        public void TestAddShareSkillListingWithSpecialCharactersInTitleExceptFirstCharacter()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithSpecialCharacters(shareSkillList[2]);

        }
        [Test, Order(4), Description("This test adds a Share skill Listing with first character as a special characters in title field")]
        public void TestAddShareSkillListingWithFirstCharacterAsSpecialCharactersInTitle()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithSpecialCharacters(shareSkillList[3]);

        }
        [Test, Order(5), Description("This test adds a Share skill Listing with more than 100 characters")]
        public void TestAddShareSkillListingWithTitleMoreThan100Characters()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithTitleMoreThan100Characters(shareSkillList[4]);

        }
        [Test, Order(6), Description("This test adds a Share skill Listing with NO value in description field")]
        public void TestAddShareSkillListingWithoutDescription()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithInsufficientData(shareSkillList[5]);

        }
        [Test, Order(7), Description("This test adds a Share skill Listing with special characters in description field (except first character)")]
        public void TestAddShareSkillListingWithSpecialCharactersInDescriptionExceptFirstCharacter()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithSpecialCharacters(shareSkillList[6]);

        }
        [Test, Order(8), Description("This test adds a Share skill Listing with first character as a special characters in description field")]
        public void TestAddShareSkillListingWithFirstCharacterAsSpecialCharactersInDescription()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithSpecialCharacters(shareSkillList[7]);

        }
        [Test, Order(9), Description("This test adds a Share skill Listing with more than 600 characters in description field")]
        public void TestAddShareSkillListingWithDescriptionMoreThan600Characters()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithDescriptionMoreThan600Characters(shareSkillList[8]);

        }
        [Test, Order(10), Description("This test adds a Share skill Listing without selecting a category")]
        public void TestAddShareSkillListingWithoutCategory()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithInsufficientData(shareSkillList[9]);

        }
        [Test, Order(11), Description("This test adds a Share skill Listing without selecting a Subcategory")]
        public void TestAddShareSkillListingWithoutSubcategory()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.SetSubCategoryFlag();
            shareSkillStepsObj?.AddShareSkillWithInsufficientData(shareSkillList[10]);

        }
        [Test, Order(12), Description("This test adds a Share skill Listing without entering any tag value")]
        public void TestAddShareSkillListingWithoutAnyTag()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithInsufficientData(shareSkillList[11]);

        }
        [Test, Order(13), Description("This test adds a Share skill Listing with multiple tag entries")]
        public void TestAddShareSkillListingWithMultipleTags()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithMultipleTags(0);

        }
        [Test, Order(14), Description("This test adds a Share skill Listing with duplicate tag entries")]
        public void TestAddShareSkillListingWithDuplicateTags()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithDuplicateTags(0);

        }
        [Test, Order(15), Description("This test adds a Share skill Listing with special characters in tag field")]
        public void TestAddShareSkillListingWithSpecialCharactersInTags()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithSpecialCharactersInTags(0);

        }
        [Test, Order(16), Description("This test adds a Share skill Listing with spaces only in tag field")]
        public void TestAddShareSkillListingWithSpacesOnlyInTags()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithSpacesOnlyInTags(0);

        }
        [Test, Order(17), Description("This test deletes tags from Share skill Listing")]
        public void TestDeleteShareSkillListingTags()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.DeleteShareSkillListingTags(0);

        }
        [Test, Order(18), Description("This test assigns a start date older than the current date in Share skill Listing")]
        public void TestAddShareSkillListingWithStartDateOlderThanCurrentDate()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithInsufficientData(shareSkillList[12]);

        }
        [Test, Order(19), Description("This test assigns an end date older than the start date in Share skill Listing")]
        public void TestAddShareSkillListingWithEndDateOlderThanStartDate()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithInsufficientData(shareSkillList[13]);

        }
        [Test, Order(20), Description("This test adds a Share skill Listing without entering any Skill-exchange tags")]
        public void TestAddShareSkillListingWithoutAnySkillExchangeTags()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddShareSkillWithInsufficientData(shareSkillList[14]);

        }
        [Test, Order(21), Description("This test adds a Share skill Listing without uploading any work samples")]
        public void TestAddShareSkillListingWithoutUploadingWorkSample()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddNewShareSkill(shareSkillList[0]);

        }
        [Test, Order(22), Description("This test adds a Share skill Listing by selecting Credit for Skill-Trade")]
        public void TestAddShareSkillListingBySelectingCredit()
        {
            shareSkillStepsObj?.ShareSkillRenderStep();

            shareSkillStepsObj?.AddNewShareSkill(shareSkillList[15]);

        }
        [Test, Order(23), Description("This test cancels a Share skill Listing before adding")]
        public void TestCancelShareSkillListing()
        {
            //skipTearDown = true;
            //shareSkillStepsObj?.CancelShareSkillListing(shareSkillList[15]);
        }

    }
}
