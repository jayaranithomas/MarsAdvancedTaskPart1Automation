using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents;
using MarsAdvancedTaskPart1NUnitAutomation.ReportClass;
using MarsAdvancedTaskPart1NUnitAutomation.Steps;
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
    public class ProfileAboutMeTest : CommonDriver
    {

        AboutMeSteps aboutMeStepsObj;
        GenerateReport? generateReport;
        public ProfileAboutMeTest()
        {
            aboutMeStepsObj = new AboutMeSteps();
        }


        [OneTimeSetUp]
        public void ReportMethod()
        {
            generateReport = new GenerateReport();
            generateReport?.GenerateExtentReport(@"Reports\AboutMeExtentReport.html");

        }


        [SetUp]
        public void SetUp()
        {
            generateReport?.CreateTest();
        }


        [Test, Order(1), Description("This test selects an availability option from the dropdown")]
        public void TestSelectAvailabilityOption()
        {

            aboutMeStepsObj.SelectAvailabilityOption("Part Time", 0);

        }
        [Test, Order(2), Description("This test changes the availability option already selected")]
        public void TestChangeSelectedAvailabilityOption()
        {

            aboutMeStepsObj.SelectAvailabilityOption("Full Time", 0);

        }
        [Test, Order(3), Description("This test cancels the availability selection")]
        public void TestCancelSelectedAvailabilityOption()
        {

            aboutMeStepsObj.SelectAvailabilityOption("", 1);

        }
        [Test, Order(4), Description("This test selects an hours option from the dropdown")]
        public void TestSelectHoursOption()
        {

            aboutMeStepsObj.SelectHoursOption("Less than 30hours a week", 0);

        }
        [Test, Order(5), Description("This test changes the hours option already selected")]
        public void TestChangeSelectedHoursOption()
        {

            aboutMeStepsObj.SelectHoursOption("As needed", 0);

        }
        [Test, Order(6), Description("This test cancels the hours selection")]
        public void TestCancelSelectedHoursOption()
        {

            aboutMeStepsObj.SelectHoursOption("", 1);

        }
        [Test, Order(7), Description("This test selects a target option from the dropdown")]
        public void TestSelectTargetOption()
        {

            aboutMeStepsObj.SelectTargetOption("Between $500 and $1000 per month", 0);

        }
        [Test, Order(8), Description("This test changes the target option already selected")]
        public void TestChangeTargetHoursOption()
        {

            aboutMeStepsObj.SelectTargetOption("More than $1000 per month", 0);

        }
        [Test, Order(9), Description("This test cancels the target selection")]
        public void TestCancelSelectedTargetOption()
        {

            aboutMeStepsObj.SelectTargetOption("", 1);

        }

        [TearDown]

        public void AfterTest()
        {
            generateReport?.UpdateTest();
            Close();

        }
    }
}
