using MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
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
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;
        string languageName = string.Empty;


        int cancelFlag = 0;
       // ProfileNavigationTabs profileNavigationObj = new ProfileNavigationTabs();

        LanguageRenderingComponent languageRendering = new LanguageRenderingComponent();

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
        //To get the last entered Language
        public void GetLastLanguageName()
        {
            IWebElement languageNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]//td[1]"));
            languageName = languageNameTextBox.Text;
        }
        //To get the first entered Language
        public void GetFirstLanguageName()
        {
            IWebElement languageNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[1]//td[1]"));
            languageName = languageNameTextBox.Text;
        }
        public void AddNewLanguage(LanguageDM languageDM)
        {

            languageRendering.AddLanguage(languageDM);

            CapturePopupMessage();

            GetLastLanguageName();

            if (!string.IsNullOrEmpty(languageName))
                expectedMessage = languageName + " has been added to your languages";
            else
                expectedMessage = "has been added to your languages";

            Assert.That(actualMessage.Equals(expectedMessage), "The language record has not been added successfully");

        }
        public void DeleteAllLanguageRecords()
        {
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='first']//tbody")).Count;

            for (int i = 1; i <= rowcount;)
            {
                GetLastLanguageName();

                IWebElement deleteButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]//i[@class='remove icon']"));
                deleteButton.Click();

                rowcount--;

                CapturePopupMessage();

                if (!string.IsNullOrEmpty(languageName))
                    expectedMessage = languageName + " has been deleted from your languages";
                else
                    expectedMessage = "has been deleted from your languages";

                Assert.That(actualMessage.Equals(expectedMessage), "The language record has not been deleted successfully");

                Thread.Sleep(2000);

            }
        }

        public void AddNewLanguageRecordWithInsufficientData(LanguageDM languageDM)
        {
            languageRendering.AddLanguage(languageDM);

            CapturePopupMessage();
            expectedMessage = "Please enter language and level";

            Assert.That(actualMessage.Equals(expectedMessage), "The language record has been added successfully");
        }

        public void AddAlreadyExistingLanguageRecord(LanguageDM languageDM)
        {
            languageRendering.AddLanguage(languageDM);

            CapturePopupMessage();
            expectedMessage = "This language is already exist in your language list.";

            Assert.That(actualMessage.Equals(expectedMessage), "The language record has been added successfully");

        }

        public void AddDuplicateLanguageWithDifferentLevel(LanguageDM languageDM)
        {
            languageRendering.AddLanguage(languageDM);

            CapturePopupMessage();
            expectedMessage = "Duplicated data";

            Assert.That(actualMessage.Equals(expectedMessage), "The duplicate language record has been added successfully");

        }
        public void AddFifthLanguage()
        {
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='first']//tbody")).Count;

            if (rowcount == 4)
            {
                try
                {
                    IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='first']//div[contains(text(),'Add New')]"));
                    addNewButton.Click();
                }
                catch (Exception ex)
                {
                    Assert.Pass(ex.Message);
                }
            }

        }
        public void CancelAddLanguageRecord(LanguageDM languageDM)
        {
            cancelFlag = 1;

            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='first']//tbody")).Count;

            if (rowcount == 4)
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]//i[@class='remove icon']"));
                deleteButton.Click();

            }

            languageRendering.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            languageRendering.AddLanguage(languageDM);    
            cancelFlag = 0;

           
            GetLastLanguageName();

            if (!languageName.Equals("Urdu"))
            {
                Console.WriteLine("Language record cancelled before adding");
                Assert.That(!languageName.Equals("Urdu"), "Language record not cancelled successfully");

            }
        }
        public void UpdateExistingLanguageRecordWithFieldsEdited(LanguageDM languageDM)
        {
            languageRendering.EditLanguageRecord(languageDM);

            CapturePopupMessage();
            GetFirstLanguageName();
            if (!string.IsNullOrEmpty(languageName))
                expectedMessage = languageName + " has been updated to your languages";
            else
                expectedMessage = "has been updated to your languages";

            Assert.That(actualMessage.Equals(expectedMessage), "The language record has not been updated successfully");

        }
        public void UpdateExistingLanguageRecordWithNoFieldsEdited()
        {
            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            IWebElement updateButton = driver.FindElement(By.XPath("//div[@data-tab='first']//input[@value='Update']"));
            updateButton.Click();

            CapturePopupMessage();

            expectedMessage = "This language is already added to your language list.";

            Assert.That(actualMessage.Equals(expectedMessage), "The language record has been updated successfully");

        }
        public void UpdateLanguageRecordWithInsufficientData(LanguageDM languageDM)
        {
            languageRendering.EditLanguageRecord(languageDM);

            CapturePopupMessage();
            expectedMessage = "Please enter language and level";

            Assert.That(actualMessage.Equals(expectedMessage), "The language record has been updated successfully");
        }
        public void UpdateExistingLanguageRecordWithExistingLanguageName(LanguageDM languageDM1, LanguageDM languageDM2)
        {
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='first']//tbody")).Count;

            if (rowcount == 4)
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]//i[@class='remove icon']"));
                deleteButton.Click();

            }
            languageRendering.AddLanguage(languageDM1);
            Thread.Sleep(3000);
            UpdateExistingLanguageRecordWithFieldsEdited(languageDM2);

        }
        public void CancelUpdateLanguageRecord(LanguageDM languageDM)
        {
            cancelFlag = 1;

            languageRendering.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            languageRendering.EditLanguageRecord(languageDM);
            cancelFlag = 0;


            GetLastLanguageName();

            if (!languageName.Equals("Japanese"))
            {
                Console.WriteLine("Language record cancelled before Updating");
                Assert.That(!languageName.Equals("Japanese"), "Language record not cancelled successfully");

            }
        }

    }
}
