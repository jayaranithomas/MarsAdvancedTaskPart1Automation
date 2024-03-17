using MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Steps
{

    public class SkillSteps : CommonDriver
    {
        string actualMessage = string.Empty;
        string expectedMessage = string.Empty;
        string skillName = string.Empty;


        int cancelFlag = 0;

        SkillsAddAndUpdateComponent skillsAddAndUpdateComponent = new SkillsAddAndUpdateComponent();

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
        public void GetLastSkillName()
        {
            IWebElement skillNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[last()]//td[1]"));
            skillName = skillNameTextBox.Text;
        }
        //To get the first entered Language
        public void GetFirstSkillName()
        {
            IWebElement skillNameTextBox = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[1]//td[1]"));
            skillName = skillNameTextBox.Text;
        }

        public void DeleteAllSkillRecords()
        {
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='second']//tbody")).Count;

            for (int i = 1; i <= rowcount;)
            {
                GetLastSkillName();

                IWebElement deleteButton = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[last()]//i[@class='remove icon']"));
                deleteButton.Click();

                rowcount--;

                CapturePopupMessage();

                if (!string.IsNullOrEmpty(skillName))
                    expectedMessage = skillName + " has been deleted";
                else
                    expectedMessage = "has been deleted";

                Assert.That(actualMessage.Equals(expectedMessage), "The skill record has not been deleted successfully");

                Thread.Sleep(2000);

            }

        }
        public void AddNewSkill(SkillsDM skillsDM)
        {

            skillsAddAndUpdateComponent.AddSkill(skillsDM);

            CapturePopupMessage();
            GetLastSkillName();

            if (!string.IsNullOrEmpty(skillName))
                expectedMessage = skillName + " has been added to your skills";
            else
                expectedMessage = "has been added to your skills";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has not been added successfully");

        }
        public void AddNewSkillRecordWithInsufficientData(SkillsDM skillsDM)
        {
            skillsAddAndUpdateComponent.AddSkill(skillsDM);

            CapturePopupMessage();
            expectedMessage = "Please enter skill and experience level";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has been added successfully");
        }
        public void AddAlreadyExistingSkillRecord(SkillsDM skillsDM)
        {
            skillsAddAndUpdateComponent.AddSkill(skillsDM);

            CapturePopupMessage();
            expectedMessage = "This skill is already exist in your skill list.";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has been added successfully");

        }
        public void AddDuplicateSkillWithDifferentLevel(SkillsDM skillsDM)
        {
            skillsAddAndUpdateComponent.AddSkill(skillsDM);

            CapturePopupMessage();
            expectedMessage = "Duplicated data";

            Assert.That(actualMessage.Equals(expectedMessage), "The duplicate skill record has been added successfully");

        }
        public void CancelAddSkillRecord(SkillsDM skillsDM)
        {
            cancelFlag = 1;

            skillsAddAndUpdateComponent.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            skillsAddAndUpdateComponent.AddSkill(skillsDM);
            cancelFlag = 0;


            GetLastSkillName();

            if (!skillName.Equals("Testing"))
            {
                Console.WriteLine("Skill record cancelled before adding");
                Assert.That(!skillName.Equals("Testing"), "Skill record not cancelled successfully");

            }
        }
        public void UpdateExistingSkillRecordWithFieldsEdited(SkillsDM skillsDM)
        {
            skillsAddAndUpdateComponent.EditSkillRecord(skillsDM);

            CapturePopupMessage();
            GetFirstSkillName();
            if (!string.IsNullOrEmpty(skillName))
                expectedMessage = skillName + " has been updated to your skills";
            else
                expectedMessage = "has been updated to your skills";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has not been updated successfully");

        }
        public void UpdateExistingSkillRecordWithNoFieldsEdited()
        {
            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            IWebElement updateButton = driver.FindElement(By.XPath("//div[@data-tab='second']//input[@value='Update']"));
            updateButton.Click();

            CapturePopupMessage();

            expectedMessage = "This skill is already added to your skill list.";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has been updated successfully");

        }
        public void UpdateSkillRecordWithInsufficientData(SkillsDM skillsDM)
        {
            skillsAddAndUpdateComponent.EditSkillRecord(skillsDM);

            CapturePopupMessage();
            expectedMessage = "Please enter skill and experience level";

            Assert.That(actualMessage.Equals(expectedMessage), "The skill record has been updated successfully");
        }
        public void UpdateExistingSkillRecordWithExistingSkillName(SkillsDM skillsDM1, SkillsDM skillsDM2)
        {

            skillsAddAndUpdateComponent.AddSkill(skillsDM1);
            Thread.Sleep(3000);
            UpdateExistingSkillRecordWithFieldsEdited(skillsDM2);

        }
        public void CancelUpdateSkillRecord(SkillsDM skillsDM)
        {
            cancelFlag = 1;

            skillsAddAndUpdateComponent.SetCancelFlag(cancelFlag);
            Thread.Sleep(2000);

            skillsAddAndUpdateComponent.EditSkillRecord(skillsDM);
            cancelFlag = 0;


            GetLastSkillName();

            if (!skillName.Equals("Painting"))
            {
                Console.WriteLine("Skill record cancelled before Updating");
                Assert.That(!skillName.Equals("Painting"), "Skill record not cancelled successfully");

            }
        }
    }
}
