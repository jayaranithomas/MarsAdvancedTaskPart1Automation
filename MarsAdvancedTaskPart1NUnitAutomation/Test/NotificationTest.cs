using MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsNotificationComponent;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileAboutMeComponent;
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
    public class NotificationTest : CommonDriver
    {

        NotificationFeatures? notificationFeaturesObj;
        GenerateReport? generateReport;


        [OneTimeSetUp]
        public void ReportMethod()
        {
            generateReport = new GenerateReport();
            generateReport?.GenerateExtentReport(@"Reports\NotificationsExtentReport.html");

        }

        [SetUp]
        public void SetUp()
        {
            generateReport?.CreateTest();
            notificationFeaturesObj = new NotificationFeatures();

        }

        [Test, Order(1), Description("This test checks if notifications can be viewed or not")]
        public void TestCheckNotificationVisibility()
        {

            notificationFeaturesObj?.CheckNotificationsVisibility();

        }
        [Test, Order(2), Description("This test checks the Load More button functionality")]
        public void TestCheckLoadMoreButtonFunctionality()
        {

            notificationFeaturesObj?.CheckLoadMoreButtonFunctionality();

        }
        [Test, Order(3), Description("This test checks the Show Less button functionality")]
        public void TestCheckShowLessButtonFunctionality()
        {

            notificationFeaturesObj?.CheckShowLessButtonFunctionality();

        }
        [Test, Order(4), Description("This test checks the Select All functionality")]
        public void TestCheckSelectAllFunctionality()
        {

            notificationFeaturesObj?.CheckSelectAllButtonFunctionality();

        }
        [Test, Order(5), Description("This test checks the UnSelect All functionality")]
        public void TestCheckUnSelectAllFunctionality()
        {

            notificationFeaturesObj?.CheckUnSelectAllButtonFunctionality();

        }
        [Test, Order(6), Description("This test checks if the notifications can be marked as read")]
        public void TestCheckMarkAsReadFunctionality()
        {

            notificationFeaturesObj?.CheckMarkAsReadFunctionality();

        }
        [Test, Order(7), Description("This test checks if selected notifications can be deleted")]
        public void TestCheckSelectedDeleteFunctionality()
        {

            notificationFeaturesObj?.CheckSelectedDeleteFunctionality();

        }

        [TearDown]

        public void AfterTest()
        {
            generateReport?.UpdateTest();
            Close();

        }
    }
}
