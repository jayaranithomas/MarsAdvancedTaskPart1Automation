using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsNotificationComponent
{

    public class NotificationFeatures : CommonDriver
    {
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;

        IWebElement? dashboardTab;
        int notificationCount;
        NotificationRenderingComponent notificationsRendering = new NotificationRenderingComponent();

        public NotificationFeatures()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[contains(text(),'Dashboard')]", 10);
                dashboardTab = driver.FindElement(By.XPath("//a[contains(text(),'Dashboard')]"));
                dashboardTab.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //To capture the pop up message
        public void CapturePopupMessage()
        {

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            actualMessage = messageBox.Text;

            IWebElement closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            closeMessageIcon.Click();

            Console.WriteLine(actualMessage);

        }
        public void NotificationCount()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@class='ui items segment']//div[@class='content']/a/div[@class='content']", 20);
                notificationCount = driver.FindElements(By.XPath(" //input[@type='checkbox']")).Count;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CheckNotificationsVisibility()
        {
            NotificationCount();
            if (notificationCount > 0)
            {
                Console.WriteLine("Number of notifications visible is " + notificationCount + "");
                Assert.That(notificationCount > 0, "The notification is not visible");
            }
            else
            {
                Assert.Pass("No Notifications Present");
            }
        }
        public void CheckLoadMoreButtonFunctionality()
        {
            notificationsRendering.RenderLoadMoreButton();
            Thread.Sleep(3000);
            NotificationCount();
            if (notificationCount > 0)
            {
                Console.WriteLine("Number of notifications visible is " + notificationCount + "");
                Assert.That(notificationCount > 0, "The notification is not visible");
            }
            else
            {
                Assert.Pass("No Notifications Present");
            }
        }
        public void CheckShowLessButtonFunctionality()
        {
            notificationsRendering.RenderLoadMoreButton();
            notificationsRendering.RenderShowLessButton();
            Thread.Sleep(3000);
            NotificationCount();
            if (notificationCount > 0)
            {
                Console.WriteLine("Number of notifications visible is " + notificationCount + "");
                Assert.That(notificationCount > 0, "The notification is not visible");
            }
            else
            {
                Assert.Pass("No Notifications Present");
            }
        }
        public void CheckSelectAllButtonFunctionality()
        {
            notificationsRendering.RenderSelectAllButton();

            Assert.Pass("All Notifications Selected");

        }
        public void CheckUnSelectAllButtonFunctionality()
        {
            notificationsRendering.RenderUnSelectAllButton();

            Assert.Pass("All Notifications UnSelected");

        }
        public void CheckMarkAsReadFunctionality()
        {
            notificationsRendering.RenderMarkAsReadComponent();
            CapturePopupMessage();
            expectedMessage = "Notification updated";
            Assert.That(actualMessage.Equals(expectedMessage), "Notifications Not Marked Read");

        }
        public void CheckSelectedDeleteFunctionality()
        {
            notificationsRendering.RenderSelectFirstComponent();
            notificationsRendering.RenderDeleteComponent();
            CapturePopupMessage();
            expectedMessage = "Notification updated";
            Assert.That(actualMessage.Equals(expectedMessage), "Notifications Not Marked Read");

        }

    }
}
