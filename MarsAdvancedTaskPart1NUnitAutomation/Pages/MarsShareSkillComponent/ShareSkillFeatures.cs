using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
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

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsShareSkillComponent
{

    public class ShareSkillFeatures : CommonDriver
    {
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;
        string errorMessageString = string.Empty;
        string actualTitle = string.Empty;
        string actualDescription = string.Empty;
        int subCategoryFlag = 0;

        IWebElement? shareSkillButton;
        IWebElement? tag;

        ShareSkillRenderingComponent shareSkillRendering = new ShareSkillRenderingComponent();
        //To navigate to ServiceListing Page
        public ShareSkillFeatures()
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

            shareSkillRendering.AddShareSkills(shareSkillDM);

            expectedMessage = "Service Listing Added successfully";
            Assert.Pass("Service Listing Added successfully");

        }
        public void AddShareSkillWithInsufficientData(ShareSkillsDM shareSkillDM)
        {

            shareSkillRendering.AddShareSkills(shareSkillDM);

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

            shareSkillRendering.AddShareSkills(shareSkillDM);

            CapturePopupMessage();
            CaptureErrorMessage();

            Assert.That(errorMessageString.Equals("Special characters are not allowed.") || errorMessageString.Equals("First character must be an alphabet character or a number."), "The service listing has been added successfully");

        }
        public void AddShareSkillWithTitleMoreThan100Characters(ShareSkillsDM shareSkillDM)
        {

            shareSkillRendering.AddShareSkills(shareSkillDM);

            actualTitle = shareSkillRendering.GetTitle();
            Console.WriteLine("The length of the Title is: " + actualTitle.Length);

            Assert.That(!shareSkillDM.title.Equals(actualTitle), "The service listing with more than 100 characters title has been added");

        }
        public void AddShareSkillWithDescriptionMoreThan600Characters(ShareSkillsDM shareSkillDM)
        {

            shareSkillRendering.AddShareSkills(shareSkillDM);

            actualDescription = shareSkillRendering.GetDescription();
            Console.WriteLine("The length of the Description is: " + actualDescription.Length);

            Assert.That(!shareSkillDM.title.Equals(actualDescription), "The service listing with more than 600 characters description has been added");

        }
        public void AddShareSkillWithMultipleTags(int index)
        {
            tag = shareSkillRendering.TagLocator(index);
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
            tag = shareSkillRendering.TagLocator(index);
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
            tag = shareSkillRendering.TagLocator(index);

            tag?.SendKeys("$^%$%^FHGFHGFG7655");
            tag?.SendKeys(Keys.Enter);

            var tagCount = driver.FindElements(By.XPath("//span[@class='ReactTags__tag']")).Count;
            Console.WriteLine("Tags with special characters can be entered and the number of tags is: " + tagCount);

            Assert.That(tagCount == 1, "The service listing with tags having special characters cannot be added");

        }
        public void AddShareSkillWithSpacesOnlyInTags(int index)
        {
            tag = shareSkillRendering.TagLocator(index);

            tag?.SendKeys("             ");
            tag?.SendKeys(Keys.Enter);

            var tagCount = driver.FindElements(By.XPath("//span[@class='ReactTags__tag']")).Count;
            Console.WriteLine("Tags with spaces alone cannot be entered and the number of tags is: " + tagCount);

            Assert.That(tagCount == 0, "The service listing with tags having spaces only can be added");

        }
        public void DeleteShareSkillListingTags(int index)
        {
            tag = shareSkillRendering.TagLocator(index);
            tag?.SendKeys("T1");
            tag?.SendKeys(Keys.Enter);
            tag = shareSkillRendering.TagRemoveLocator(index);
            tag?.Click();
            var tagCount = driver.FindElements(By.XPath("//span[@class='ReactTags__tag']")).Count;
            Console.WriteLine("Tag entered has been removed and the number of tags is: " + tagCount);

            Assert.That(tagCount == 0, "The tag was not deleted");

        }
        public void CancelShareSkillListing(ShareSkillsDM shareSkillDM)
        {
            shareSkillRendering.SetCancelFlag(1);
            shareSkillRendering.AddShareSkills(shareSkillDM);
            Assert.Pass("Service Listing cancelled");
        }
    }
}