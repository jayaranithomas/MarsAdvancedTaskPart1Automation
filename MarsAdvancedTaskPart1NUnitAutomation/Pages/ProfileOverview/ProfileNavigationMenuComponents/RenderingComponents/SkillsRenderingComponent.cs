using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents
{
    
    public class SkillsRenderingComponent : CommonDriver
    {
        IWebElement? skillTextBox;
        IWebElement? chooseLevelDD;

        IWebElement? addButton;
        IWebElement? updateButton;
        IWebElement? cancelButton;
        int cancelFlag = 0;
        public void RenderAddComponents()
        {
            try
            {
                skillTextBox = driver.FindElement(By.Name("name"));
                chooseLevelDD = driver.FindElement(By.Name("level"));

                addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void RenderUpdateComponents()
        {
            try
            {
                skillTextBox = driver.FindElement(By.Name("name"));
                chooseLevelDD = driver.FindElement(By.Name("level"));

                updateButton = driver.FindElement(By.XPath("//div[@data-tab='second']//input[@value='Update']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void SetCancelFlag(int flag)
        {
            cancelFlag = flag;
        }


        public void AddSkill(SkillsDM skillDM)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[contains(text(),'Add New')]"));
            addNewButton.Click();

            RenderAddComponents();

            if (!string.IsNullOrEmpty(skillDM.skill))
            {
                skillTextBox?.Click();
                skillTextBox?.SendKeys(skillDM.skill);
            }
            if (!string.IsNullOrEmpty(skillDM.level))
            {
                chooseLevelDD?.Click();
                chooseLevelDD?.SendKeys(skillDM.level);
            }

            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                addButton?.Click();
            }
            else
            { cancelFlag = 0; cancelButton?.Click(); }
        }

        public void EditSkillRecord(SkillsDM skillDM)
        {
            Wait.WaitToBeClickable("XPath", "//div[@data-tab='second']//tbody[1]//i[@class='outline write icon']", 3);

            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            RenderUpdateComponents();
            if (!skillDM.skill.Equals("No Change"))
            {
                if (string.IsNullOrEmpty(skillDM.skill))
                {
                    var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                    actions.Click(skillTextBox);
                    actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                    actions.Perform();
                }
                else
                {
                    skillTextBox?.Clear();
                    skillTextBox?.SendKeys(skillDM.skill);
                }
            }
            if (!skillDM.level.Equals("No Change"))
            {
                chooseLevelDD?.Click();
                if (!string.IsNullOrEmpty(skillDM.level))
                    chooseLevelDD?.SendKeys(skillDM.level);

                else
                    chooseLevelDD?.SendKeys("Skill Level");
                chooseLevelDD?.Click();
            }


            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {

                updateButton?.Click();
            }
            else
            { cancelFlag = 0; cancelButton?.Click(); }

        }
    }
}
