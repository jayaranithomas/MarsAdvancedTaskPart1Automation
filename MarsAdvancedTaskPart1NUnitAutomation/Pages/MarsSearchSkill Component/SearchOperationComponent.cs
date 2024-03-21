using AventStack.ExtentReports.Model;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsSearchSkill_Component
{
    public class SearchOperationComponent : CommonDriver
    {
        SearchSkillsRenderingComponent searchSkillsRenderingComponent = new SearchSkillsRenderingComponent();
        public void SearchSkills(SearchSkillsDM searchSkillsDM)
        {
            searchSkillsRenderingComponent.RenderSearchSkillComponents();
            if (!string.IsNullOrEmpty(searchSkillsDM.category))
            {
                searchSkillsRenderingComponent.CategoryRenderingComponent(searchSkillsDM.category);
                searchSkillsRenderingComponent.CategoryLocator()?.Click();
                if (!string.IsNullOrEmpty(searchSkillsDM.subcategory))
                {
                    searchSkillsRenderingComponent.SubcategoryRenderingComponent(searchSkillsDM.subcategory);
                    searchSkillsRenderingComponent.SubCategoryLocator()?.Click();
                }

            }
            if (!string.IsNullOrEmpty(searchSkillsDM.searchskills))
            {
                searchSkillsRenderingComponent.SearchSkillsTBLocator()?.SendKeys(searchSkillsDM.searchskills);
                searchSkillsRenderingComponent.SearchSkillsIconLocator()?.Click();
            }
            if (!string.IsNullOrEmpty(searchSkillsDM.searchuser))
            {
                searchSkillsRenderingComponent.SearchUserTBLocator()?.Click();
                IWebElement? userName = driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
                userName?.SendKeys(searchSkillsDM.searchuser);
                userName?.SendKeys(Keys.Down);
                Thread.Sleep(2000);
                var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                actions.KeyDown(Keys.Enter).KeyUp(Keys.Enter);
                actions.Perform();
                IWebElement? filterText = driver.FindElement(By.XPath("//div[contains(text(),'Filter')]"));
                filterText.Click();

            }
            if (!string.IsNullOrEmpty(searchSkillsDM.filter))
            {
                searchSkillsRenderingComponent.FilterRenderingComponent(searchSkillsDM.filter);
                searchSkillsRenderingComponent.FilterLocator()?.Click();
                Thread.Sleep(2000);
            }
            searchSkillsRenderingComponent.GetSearchResult();
        }
    }
}
