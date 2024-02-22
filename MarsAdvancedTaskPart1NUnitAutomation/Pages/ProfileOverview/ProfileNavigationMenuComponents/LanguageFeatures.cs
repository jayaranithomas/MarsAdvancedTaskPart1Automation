using MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents
{
    
    public class LanguageFeatures : CommonDriver
    {
        string actualMessage = "";
        string expectedMessage = "";
        LanguageDM languageDM = new LanguageDM();


        int cancelFlag = 0;
        ProfileNavigationTabs profileNavigationObj = new ProfileNavigationTabs();

        LanguageAssertHelper languageAssertHelper = new LanguageAssertHelper();
        LanguageRenderingComponent languageRendering = new LanguageRenderingComponent();


        public void CapturePopupMessage()
        {

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            actualMessage = messageBox.Text;

            IWebElement closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            closeMessageIcon.Click();

            Console.WriteLine(actualMessage);

        }
        public void AddNewLanguage(LanguageDM languageDM)
        {
            this.languageDM = languageDM;

            languageRendering.AddLanguage(languageDM);

            CapturePopupMessage();

            expectedMessage = "English has been added to your languages";

            languageAssertHelper.assertAddNewLanguage(expectedMessage, actualMessage);
        }
        public void DeleteAllLanguageRecords()
        {
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='first']//tbody")).Count;

            for (int i = 1; i <= rowcount;)
            {
                IWebElement languageNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[1]//td[1]"));
                string languageName = languageNameTextBox.Text;

                IWebElement deleteButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[1]//i[@class='remove icon']"));
                deleteButton.Click();
                
                rowcount--;

                CapturePopupMessage();

                if (!string.IsNullOrEmpty(languageName))
                    expectedMessage = languageName + " has been deleted from your languages";
                else
                    expectedMessage = "has been deleted from your languages";

                languageAssertHelper.assertDeleteAllLanguageRecords(expectedMessage, actualMessage);

                Thread.Sleep(2000);

            }
        }

        public void AddNewLanguageRecordWithAllNullData(LanguageDM languageDM)
        {
            this.languageDM = languageDM;
            languageRendering.AddLanguage(languageDM);

            CapturePopupMessage();

            expectedMessage = "Please enter language and level";

            languageAssertHelper.assertAddNewLanguageRecordWithAllNullData(expectedMessage, actualMessage);

        }

        public void AddNewLanguageRecordWithLevelNotSelected(LanguageDM languageDM)
        {
            this.languageDM = languageDM;
            languageRendering.AddLanguage(languageDM);
            CapturePopupMessage();
            expectedMessage = "Please enter language and level";

            languageAssertHelper.assertAddNewLanguageRecordWithLevelNotSelected(expectedMessage, actualMessage);

        }

        public void AddNewLanguageRecordWithValidLevelAndEmptyTextBox(LanguageDM languageDM)
        {
            this.languageDM = languageDM;
            languageRendering.AddLanguage(languageDM);

            CapturePopupMessage();
            expectedMessage = "Please enter language and level";

            languageAssertHelper.assertAddNewLanguageRecordWithValidLevelAndEmptyTextBox(expectedMessage, actualMessage);

        }

        public void AddAlreadyExistingLanguageRecord(LanguageDM languageDM)
        {
            this.languageDM = languageDM;
            languageRendering.AddLanguage(languageDM);

            CapturePopupMessage();
            expectedMessage = "This language is already exist in your language list.";

            languageAssertHelper.assertAddAlreadyExistingLanguageRecord(expectedMessage, actualMessage);

        }
    }
}
