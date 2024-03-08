using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileAboutMeComponent
{
    
    public class AboutMeFeatures : CommonDriver
    {
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;
        string languageName = string.Empty;
        AboutMeRenderingComponent aboutMeRendering = new AboutMeRenderingComponent();


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
        public void SelectAvailabilityOption(string option, int flag)
        {
            aboutMeRendering.EditAvailabilityProfile(option,flag);
            if (flag == 0)
            {
                CapturePopupMessage();
                expectedMessage = "Availability updated";
                Assert.That(actualMessage.Equals(expectedMessage), "The Availability Option is not updated successfully");
            }
            else
            {
                Console.WriteLine("Selection Cancelled");
                Assert.Pass("Selection Cancelled");
            }

        }
        public void SelectHoursOption(string option, int flag)
        {
            aboutMeRendering.EditHoursProfile(option, flag);
            if (flag == 0)
            {
                CapturePopupMessage();
                expectedMessage = "Availability updated";
                Assert.That(actualMessage.Equals(expectedMessage), "The Hours Option is not updated successfully");
            }
            else
            {
                Assert.Pass("Selection Cancelled");
            }

        }
        public void SelectTargetOption(string option, int flag)
        {
            aboutMeRendering.EditTargetProfile(option, flag);
            if (flag == 0)
            {
                CapturePopupMessage();
                expectedMessage = "Availability updated";
                Assert.That(actualMessage.Equals(expectedMessage), "The Target Option is not updated successfully");
            }
            else
            {
                Assert.Pass("Selection Cancelled");
            }

        }
    }
}
