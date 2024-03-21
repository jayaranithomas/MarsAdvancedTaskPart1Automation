using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsShareSkillComponent;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Steps
{

    public class ShareSkillSteps : CommonDriver
    {
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;
        string errorMessageString = string.Empty;
        string actualTitle = string.Empty;
        string actualDescription = string.Empty;
        int subCategoryFlag = 0;

        IWebElement? shareSkillButton;
        IWebElement? tag;

        ShareSkillsAddComponent shareSkillsAddComponent = new ShareSkillsAddComponent();
        ShareSkillRenderingComponent shareSkillRenderingComponent = new ShareSkillRenderingComponent();
        //To navigate to ServiceListing Page
        public ShareSkillSteps()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[@href='/Home/ServiceListing']", 3);
                shareSkillButton = driver.FindElement(By.XPath("//a[@href='/Home/ServiceListing']"));
                shareSkillButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //To capture the pop up message
        public void CapturePopupMessage()
        {

            Thread.Sleep(1000);
            try
            {
                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                actualMessage = messageBox.Text;

                IWebElement closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
                closeMessageIcon.Click();

                Console.WriteLine(actualMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void CaptureErrorMessage()
        {
            Thread.Sleep(1000);
            try
            {
                IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ui basic red prompt label transition visible']"));
                errorMessageString = errorMessage.Text;
                Console.WriteLine(errorMessageString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void CaptureSubcategoryErrorMessage()
        {
            Thread.Sleep(1000);
            try
            {
                IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ui red basic label']"));
                errorMessageString = errorMessage.Text;
                Console.WriteLine(errorMessageString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void SetSubCategoryFlag()
        {
            subCategoryFlag = 1;
        }

        public void AddNewShareSkill(ShareSkillsDM shareSkillDM)
        {

            shareSkillsAddComponent.AddShareSkills(shareSkillDM);

            expectedMessage = "Service Listing Added successfully";
            Assert.Pass("Service Listing Added successfully");

        }
        public void AddShareSkillWithInsufficientData(ShareSkillsDM shareSkillDM)
        {

            shareSkillsAddComponent.AddShareSkills(shareSkillDM);

            CapturePopupMessage();

            if (subCategoryFlag == 0)
                CaptureErrorMessage();
            else
            {
                CaptureSubcategoryErrorMessage();
                subCategoryFlag = 0;
            }

            expectedMessage = "Please complete the form correctly.";

            Assert.That(actualMessage.Equals(expectedMessage), "The service listing has been added successfully");

        }
        public void AddShareSkillWithSpecialCharacters(ShareSkillsDM shareSkillDM)
        {

            shareSkillsAddComponent.AddShareSkills(shareSkillDM);

            CapturePopupMessage();
            CaptureErrorMessage();

            Assert.That(errorMessageString.Equals("Special characters are not allowed.") || errorMessageString.Equals("First character must be an alphabet character or a number."), "The service listing has been added successfully");

        }
        public void AddShareSkillWithTitleMoreThan100Characters(ShareSkillsDM shareSkillDM)
        {

            shareSkillsAddComponent.AddShareSkills(shareSkillDM);

            actualTitle = shareSkillsAddComponent.GetTitle();
            Console.WriteLine("The length of the Title is: " + actualTitle.Length);

            Assert.That(!shareSkillDM.title.Equals(actualTitle), "The service listing with more than 100 characters title has been added");

        }
        public void AddShareSkillWithDescriptionMoreThan600Characters(ShareSkillsDM shareSkillDM)
        {

            shareSkillsAddComponent.AddShareSkills(shareSkillDM);

            actualDescription = shareSkillsAddComponent.GetDescription();
            Console.WriteLine("The length of the Description is: " + actualDescription.Length);

            Assert.That(!shareSkillDM.title.Equals(actualDescription), "The service listing with more than 600 characters description has been added");

        }
        public void AddShareSkillWithMultipleTags(int index)
        {
            tag = shareSkillRenderingComponent.TagLocator(index);
            for (int i = 1; i <= 10; i++)
            {
                tag?.SendKeys("tag" + i.ToString() + "");
                tag?.SendKeys(Keys.Enter);
            }
            var tagCount = driver.FindElements(By.XPath("//span[@class='ReactTags__tag']")).Count;
            Console.WriteLine("Multiple tags can be entered and the number of tags entered is: " + tagCount);

            Assert.That(tagCount == 10, "The service listing with multiple tags cannot be added");

        }
        public void AddShareSkillWithDuplicateTags(int index)
        {
            tag = shareSkillRenderingComponent.TagLocator(index);
            for (int i = 1; i <= 2; i++)
            {
                tag?.SendKeys("tag");
                tag?.SendKeys(Keys.Enter);
            }
            var tagCount = driver.FindElements(By.XPath("//span[@class='ReactTags__tag']")).Count;
            Console.WriteLine("Duplicate tags cannot be entered and the number of tags entered is: " + tagCount);

            Assert.That(tagCount == 1, "The service listing with duplicate tags can be added");

        }
        public void AddShareSkillWithSpecialCharactersInTags(int index)
        {
            tag = shareSkillRenderingComponent.TagLocator(index);

            tag?.SendKeys("$^%$%^FHGFHGFG7655");
            tag?.SendKeys(Keys.Enter);

            var tagCount = driver.FindElements(By.XPath("//span[@class='ReactTags__tag']")).Count;
            Console.WriteLine("Tags with special characters can be entered and the number of tags is: " + tagCount);

            Assert.That(tagCount == 1, "The service listing with tags having special characters cannot be added");

        }
        public void AddShareSkillWithSpacesOnlyInTags(int index)
        {
            tag = shareSkillRenderingComponent.TagLocator(index);

            tag?.SendKeys("             ");
            tag?.SendKeys(Keys.Enter);

            var tagCount = driver.FindElements(By.XPath("//span[@class='ReactTags__tag']")).Count;
            Console.WriteLine("Tags with spaces alone cannot be entered and the number of tags is: " + tagCount);

            Assert.That(tagCount == 0, "The service listing with tags having spaces only can be added");

        }
        public void DeleteShareSkillListingTags(int index)
        {
            tag = shareSkillRenderingComponent.TagLocator(index);
            tag?.SendKeys("T1");
            tag?.SendKeys(Keys.Enter);
            tag = shareSkillRenderingComponent.TagRemoveLocator(index);
            tag?.Click();
            var tagCount = driver.FindElements(By.XPath("//span[@class='ReactTags__tag']")).Count;
            Console.WriteLine("Tag entered has been removed and the number of tags is: " + tagCount);

            Assert.That(tagCount == 0, "The tag was not deleted");

        }
        public void CancelShareSkillListing(ShareSkillsDM shareSkillDM)
        {
            shareSkillsAddComponent.SetCancelFlag(1);
            shareSkillsAddComponent.AddShareSkills(shareSkillDM);
            Assert.Pass("Service Listing cancelled");
        }
    }
}