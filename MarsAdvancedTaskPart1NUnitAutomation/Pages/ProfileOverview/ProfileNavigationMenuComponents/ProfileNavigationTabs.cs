using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents
{
    public class ProfileNavigationTabs : CommonDriver
    {
        public void SelectEducationTab()
        {

            Wait.WaitToBeVisible("XPath", "//a[@data-tab='third']", 2);

            IWebElement educationTab = driver.FindElement(By.XPath("//a[@data-tab='third']"));
            educationTab.Click();

        }

        public void SelectCertificationsTab()
        {

            Wait.WaitToBeVisible("XPath", "//a[@data-tab='fourth']", 3);
            Thread.Sleep(4000);

            IWebElement certificationsTab = driver.FindElement(By.XPath("//a[@data-tab='fourth']"));
            certificationsTab.Click();

        }

        public void SelectLanguageTab()
        {

            Wait.WaitToBeVisible("XPath", "//a[@data-tab='first']", 2);

            IWebElement languageTab = driver.FindElement(By.XPath("//a[@data-tab='first']"));
            languageTab.Click();

            Thread.Sleep(2000);

        }

        public void SelectSkillsTab()
        {

            Wait.WaitToBeVisible("XPath", "//a[@data-tab='second']", 3);
            Thread.Sleep(4000);

            IWebElement skillsTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillsTab.Click();

        }
    }
}
