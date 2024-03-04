using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsShareSkillComponent
{

    public class ShareSkillRenderingComponent : CommonDriver
    {
        IWebElement? title;
        IWebElement? description;
        IWebElement? category;
        IWebElement? subcategory;
        IList<IWebElement>? tagList;
        IList<IWebElement>? tagRemoveList;
        IWebElement? servicetype0;
        IWebElement? servicetype1;
        IWebElement? locationtype;
        IWebElement? startdate;
        IWebElement? enddate;
        IWebElement? skilltrade;
        IWebElement? credit;
        IWebElement? worksamples;
        IWebElement? activeT;
        IWebElement? activeF;
        IWebElement? saveButton;
        IWebElement? cancelButton;
        string titleText = string.Empty;
        string descriptionText = string.Empty;

        public void RenderShareSkillComponents()
        {
            try
            {
                Wait.WaitToBeVisible("Name", "title", 30);
                title = driver.FindElement(By.Name("title"));
                description = driver.FindElement(By.Name("description"));
                category = driver.FindElement(By.Name("categoryId"));
                tagList = driver.FindElements(By.XPath("//input[@placeholder='Add new tag']"));
                servicetype0 = driver.FindElement(By.XPath("//input[@name='serviceType'][@value='0']"));
                servicetype1 = driver.FindElement(By.XPath("//input[@name='serviceType'][@value='1']"));
                locationtype = driver.FindElement(By.Name("locationType"));
                startdate = driver.FindElement(By.Name("startDate"));
                enddate = driver.FindElement(By.Name("endDate"));
                skilltrade = driver.FindElement(By.Name("skillTrades"));
                worksamples = driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
                activeT = driver.FindElement(By.XPath("//input[@name='isActive'][@value='true']"));
                activeF = driver.FindElement(By.XPath("//input[@name='isActive'][@value='false']"));
                saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
                cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void RenderSubcategoryComponent()
        {
            try
            {
                subcategory = driver.FindElement(By.Name("subcategoryId"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public IWebElement TagLocator(int index)
        {
            try
            {
                tagList = driver.FindElements(By.XPath("//input[@placeholder='Add new tag']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return tagList[index];
        }
        public IWebElement TagRemoveLocator(int index)
        {
            try
            {
                tagRemoveList = driver.FindElements(By.XPath("//a[@class='ReactTags__remove']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return tagRemoveList[index];
        }
        public string GetTitle()
        {
            return titleText;
        }
        public string GetDescription()
        {
            return descriptionText;
        }


        public void AddShareSkills(ShareSkillsDM shareSkillsDM)
        {
            RenderShareSkillComponents();

            if (!string.IsNullOrEmpty(shareSkillsDM.title))
                title?.SendKeys(shareSkillsDM.title);

            if (!string.IsNullOrEmpty(shareSkillsDM.description))
                description?.SendKeys(shareSkillsDM.description);

            if (!string.IsNullOrEmpty(shareSkillsDM.category))
            {
                category?.SendKeys(shareSkillsDM.category);
                RenderSubcategoryComponent();
                if (!string.IsNullOrEmpty(shareSkillsDM.subcategory))
                    subcategory?.SendKeys(shareSkillsDM.subcategory);
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.tag))
            {
                tagList?[0].SendKeys(shareSkillsDM.tag);
                tagList?[0].SendKeys(Keys.Enter);
            }

            if (shareSkillsDM.servicetype.Equals("1"))
            {
                servicetype1?.Click();
                //Thread.Sleep(3000);
            }
            else if (shareSkillsDM.servicetype.Equals("0"))
            {
                servicetype0?.Click();
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.locationtype))
            {
                locationtype?.SendKeys(shareSkillsDM.locationtype);
                locationtype?.Click();
                //Thread.Sleep(3000);
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.startdate))
            {
                startdate?.SendKeys(shareSkillsDM.startdate);
                //Thread.Sleep(3000);
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.enddate))
                enddate?.SendKeys(shareSkillsDM.enddate);

            if (!string.IsNullOrEmpty(shareSkillsDM.skilltrade))
            {
                skilltrade?.SendKeys(shareSkillsDM.skilltrade);
                skilltrade?.Click();
                if (shareSkillsDM.skilltrade.Equals("true"))
                {
                    tagList?[1].SendKeys(shareSkillsDM.skillexchange);
                    tagList?[1].SendKeys(Keys.Enter);
                }
                else
                {
                    credit?.SendKeys(shareSkillsDM.credit);
                }
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.worksamples))
            {
                //string filePath = @"F:\Jaya_IC\sample1.txt";
                //worksamples?.Click();
                // Thread.Sleep(2000);
                //worksamples?.SendKeys(filePath);
                // Thread.Sleep(2000);
            }

            if (shareSkillsDM.active.Equals("true"))
            {
                activeT?.Click();
                //Thread.Sleep(3000);
            }
            else if (shareSkillsDM.active.Equals("false"))
            {
                activeF?.Click();
            }

            if (!string.IsNullOrEmpty(title?.GetAttribute("value")))
                titleText = title.GetAttribute("value");

            if (!string.IsNullOrEmpty(description?.Text))
                descriptionText = description.Text;

            saveButton?.Click();
        }
    }
}
