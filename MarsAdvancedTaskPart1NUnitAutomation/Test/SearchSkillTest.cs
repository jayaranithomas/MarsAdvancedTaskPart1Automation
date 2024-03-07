using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileAboutMeComponent;
using MarsAdvancedTaskPart1NUnitAutomation.ReportClass;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsSearchSkill_Component;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;

namespace MarsAdvancedTaskPart1NUnitAutomation.Test
{
   
    [TestFixture]
    public class SearchSkill : CommonDriver
    {
        List<SearchSkillsDM> searchSkillsList;
        SearchSkillFeatures? searchSkillFeaturesObj;
        GenerateReport? generateReport;

        public SearchSkill()
        {
            searchSkillsList = new List<SearchSkillsDM>();
        }

        [OneTimeSetUp]
        public void ReportAndJSONDataMethod()
        {
            generateReport = new GenerateReport();
            generateReport?.GenerateExtentReport(@"Reports\SearchSkillExtentReport.html");
            JSONReader jsonObj = new JSONReader();
            jsonObj.SetDataPath("searchskills");
            searchSkillsList = jsonObj.ReadSearchSkillsJsonData();
        }


        [SetUp]
        public void SetUp()
        {
            generateReport?.CreateTest();
            searchSkillFeaturesObj = new SearchSkillFeatures();
        }


        [Test, Order(1), Description("This test searches for a specific skill")]
        public void TestSearchSkillWithSkillName()
        {

            searchSkillFeaturesObj?.SearchSkillWithSkillName(searchSkillsList?[0]);

        }
       [Test, Order(2), Description("This test searches for a skill under a specific category")]
        public void TestSearchSkillWithCategory()
        {

            searchSkillFeaturesObj?.SearchSkillWithCategory(searchSkillsList?[1]);

        }
        [Test, Order(3), Description("This test searches for a skill under a specific category and subcategory")]
        public void TestSearchSkillWithCategoryAndSubcategory()
        {

            searchSkillFeaturesObj?.SearchSkillWithCategoryAndSubcategory(searchSkillsList?[2]);

        }
        [Test, Order(4), Description("This test searches for a skill under a specific category and subcategory and skill name")]
        public void TestSearchSkillWithCategoryAndSubcategoryAndSkillName()
        {

            searchSkillFeaturesObj?.SearchSkillWithCategoryAndSubcategoryAndSkillName(searchSkillsList?[3]);

        }
        [Test, Order(5), Description("This test searches for a skill under a specific category, subcategory,skill name and user name")]

        public void TestSearchSkillWithCategoryAndSubcategoryAndSkillAndUserName()
        {

            searchSkillFeaturesObj?.SearchSkillWithCategoryAndSubcategoryAndSkillAndUserName(searchSkillsList?[4]);

        }

        [TearDown]

        public void AfterTest()
        {
            generateReport?.UpdateTest();
            Close();

        }
    }
}
