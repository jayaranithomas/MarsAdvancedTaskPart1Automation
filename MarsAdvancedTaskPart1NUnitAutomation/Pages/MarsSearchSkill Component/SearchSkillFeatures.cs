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

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsSearchSkill_Component
{

    public class SearchSkillFeatures : CommonDriver
    {
        string resultString = string.Empty;
        IList<IWebElement>? searchResult;
        IWebElement? searchSkillsIcon;
        IWebElement? userName;

        SearchSkillsRenderingComponent searchSkillsRenderingComponentObj = new SearchSkillsRenderingComponent();

        public SearchSkillFeatures()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//i[@class='search link icon']", 10);
                searchSkillsIcon = driver.FindElement(By.XPath("//i[@class='search link icon']"));
                searchSkillsIcon.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetSearchResult()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//*[@class='description']", 10);
                searchResult = driver.FindElements(By.XPath("//*[@class='description']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetSearchedUserName()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@class='user-info']//h3", 10);
                userName = driver.FindElement(By.XPath("//div[@class='user-info']//h3"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SearchSkillWithSkillName(SearchSkillsDM searchSkillsDM)
        {
            searchSkillsRenderingComponentObj.SearchSkills(searchSkillsDM);
            GetSearchResult();

            Console.WriteLine("Searched Skill Name is in "+ searchResult[0]?.Text + "");
            Assert.That(searchResult[0].Text.Contains("Testing"), "Search result not Successful");
        }
         public void SearchSkillWithCategory(SearchSkillsDM searchSkillsDM)
         {
            searchSkillsRenderingComponentObj.SearchSkills(searchSkillsDM);
            GetSearchResult();

            Console.WriteLine("Searched Category is "+ searchResult[1]?.Text + "");
            Assert.That(searchResult[1].Text.Contains("Programming"), "Search result not Successful");
        }
        public void SearchSkillWithCategoryAndSubcategory(SearchSkillsDM searchSkillsDM)
        {
            searchSkillsRenderingComponentObj.SearchSkills(searchSkillsDM);
            GetSearchResult();

            Console.WriteLine("Category is "+ searchResult[1].Text + "");
            Console.WriteLine("Subcategory is " + searchResult[2].Text + "");

            Assert.That(searchResult[1].Text.Contains("Programming") && searchResult[2].Text.Contains("QA") , "Search result not Successful");
        }
        public void SearchSkillWithCategoryAndSubcategoryAndSkillName(SearchSkillsDM searchSkillsDM)
        {
            searchSkillsRenderingComponentObj.SearchSkills(searchSkillsDM);
            GetSearchResult();

            Console.WriteLine("Category is " + searchResult[1].Text + "");
            Console.WriteLine("Subcategory is " + searchResult[2].Text + "");
            Console.WriteLine("Searched Skill Name is in " + searchResult[0].Text + "");

            Assert.That(searchResult[0].Text.Contains("Testing") && searchResult[1].Text.Contains("Programming") && searchResult[2].Text.Contains("QA"), "Search result not Successful");
        }
        public void SearchSkillWithCategoryAndSubcategoryAndSkillAndUserName(SearchSkillsDM searchSkillsDM)
        {
            searchSkillsRenderingComponentObj.SearchSkills(searchSkillsDM);
            GetSearchResult();
            GetSearchedUserName();
            Console.WriteLine("Category is " + searchResult[1].Text + "");
            Console.WriteLine("Subcategory is " + searchResult[2].Text + "");
            Console.WriteLine("Searched Skill Name is in" + searchResult[0].Text + "");
            Console.WriteLine("Searched User is " + userName.Text + "");

            Assert.That(userName.Text.Contains("Rachel") && searchResult[0].Text.Contains("Testing") && searchResult[1].Text.Contains("Programming") && searchResult[2].Text.Contains("QA"), "Search result not Successful");
        }
    }
}
