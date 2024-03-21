using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileAboutMeComponent;
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
    public class NotificationTest : CommonDriver
    {


        NotificationSteps? notificationStepsObj;

        [SetUp]
        public void Setup()
        {
            notificationStepsObj = new NotificationSteps();
        }
        [Test, Order(1), Description("This test checks if notifications can be viewed or not")]
        public void TestCheckNotificationVisibility()
        {

            notificationStepsObj?.CheckNotificationsVisibility();

        }
        [Test, Order(2), Description("This test checks the Load More button functionality")]
        public void TestCheckLoadMoreButtonFunctionality()
        {

            notificationStepsObj?.CheckLoadMoreButtonFunctionality();

        }
        [Test, Order(3), Description("This test checks the Show Less button functionality")]
        public void TestCheckShowLessButtonFunctionality()
        {

            notificationStepsObj?.CheckShowLessButtonFunctionality();

        }
        [Test, Order(4), Description("This test checks the Select All functionality")]
        public void TestCheckSelectAllFunctionality()
        {

            notificationStepsObj?.CheckSelectAllButtonFunctionality();

        }
        [Test, Order(5), Description("This test checks the UnSelect All functionality")]
        public void TestCheckUnSelectAllFunctionality()
        {

            notificationStepsObj?.CheckUnSelectAllButtonFunctionality();

        }
        [Test, Order(6), Description("This test checks if the notifications can be marked as read")]
        public void TestCheckMarkAsReadFunctionality()
        {

            notificationStepsObj?.CheckMarkAsReadFunctionality();

        }
        [Test, Order(7), Description("This test checks if selected notifications can be deleted")]
        public void TestCheckSelectedDeleteFunctionality()
        {

            notificationStepsObj?.CheckSelectedDeleteFunctionality();

        }

    }
}
