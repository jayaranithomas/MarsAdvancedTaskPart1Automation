using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V120.DOM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsSearchSkill_Component
{
    public class SearchSkillsRenderingComponent : CommonDriver
    {
        IWebElement? category;
        IWebElement? subcategory;
        IWebElement? searchSkillsTB;
        IWebElement? searchSkillsIcon;
        IWebElement? searchUserTB;
        IWebElement? filter;
        IWebElement? toSearchRecord;
        IWebElement? searchResult;
        public void RenderSearchSkillComponents()
        {
            try
            {

                Wait.WaitToBeVisible("XPath", "//input[@placeholder='Search skills']", 10);
                searchSkillsTB = driver.FindElement(By.XPath("//input[@placeholder='Search skills']"));

                searchSkillsIcon = driver.FindElement(By.XPath("//i[@class='search link icon']"));

                Wait.WaitToBeVisible("XPath", "//div[@class='ui search']", 10);
                //searchUserTB = driver.FindElement(By.XPath("//input[@placeholder='Search user']"));

                searchUserTB = driver.FindElement(By.XPath("//div[@class='ui search']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void CategoryRenderingComponent(string categoryName) 
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[@class='item category'][contains(text(),'" + categoryName + "')]", 10);
                category = driver.FindElement(By.XPath("//a[@class='item category'][contains(text(),'" + categoryName + "')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void SubcategoryRenderingComponent(string subCategoryName)
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[@class='item subcategory'][contains(text(),'" + subCategoryName + "')]", 10);
                subcategory = driver.FindElement(By.XPath("//a[@class='item subcategory'][contains(text(),'" + subCategoryName + "')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void FilterRenderingComponent(string filterOption)
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//button[@class='ui button'][contains(text(),'" + filterOption + "')]", 10);
                filter = driver.FindElement(By.XPath("//button[@class='ui button'][contains(text(),'" + filterOption + "')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        public void GetSearchResult()
        {
            Wait.WaitToBeVisible("XPath", "//p[@class='row-padded']", 10);
            toSearchRecord = driver.FindElement(By.XPath("//p[@class='row-padded']"));
            toSearchRecord?.Click();
            
        }
        public void SearchSkills(SearchSkillsDM searchSkillsDM)
        {
            RenderSearchSkillComponents();
            if(!string.IsNullOrEmpty(searchSkillsDM.category))
            {
                CategoryRenderingComponent(searchSkillsDM.category);
                category?.Click();
                if (!string.IsNullOrEmpty(searchSkillsDM.subcategory))
                {
                    SubcategoryRenderingComponent(searchSkillsDM.subcategory);
                    subcategory?.Click();

                }

            }
            if (!string.IsNullOrEmpty(searchSkillsDM.searchskills))
            {
                searchSkillsTB?.SendKeys(searchSkillsDM.searchskills);
                searchSkillsIcon?.Click();
            }
            if (!string.IsNullOrEmpty(searchSkillsDM.searchuser))
            {
                searchUserTB?.Click();
                IWebElement? userName = driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
                userName?.SendKeys(searchSkillsDM.searchuser);
                userName?.SendKeys(Keys.Down);
                Thread.Sleep(2000);
                userName?.SendKeys(Keys.Enter);
                
            }
            if (!string.IsNullOrEmpty(searchSkillsDM.filter))
            {
                FilterRenderingComponent(searchSkillsDM.filter);
                filter?.Click();
            }
            GetSearchResult();            
        }

    }
}
