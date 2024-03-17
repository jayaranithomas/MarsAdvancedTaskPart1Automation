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
        IWebElement? skilltradeT;
        IWebElement? skilltradeF;
        IWebElement? credit;
        IWebElement? worksamples;
        IWebElement? activeT;
        IWebElement? activeF;
        IWebElement? saveButton;
        IWebElement? cancelButton;

        public void RenderShareSkillComponents()
        {
            try
            {
                Wait.WaitToBeVisible("Name", "title", 15);
                title = driver.FindElement(By.Name("title"));
                description = driver.FindElement(By.Name("description"));
                category = driver.FindElement(By.Name("categoryId"));
                tagList = driver.FindElements(By.XPath("//input[@placeholder='Add new tag']"));
                servicetype0 = driver.FindElement(By.XPath("//input[@name='serviceType'][@value='0']"));
                servicetype1 = driver.FindElement(By.XPath("//input[@name='serviceType'][@value='1']"));
                locationtype = driver.FindElement(By.Name("locationType"));
                startdate = driver.FindElement(By.Name("startDate"));
                enddate = driver.FindElement(By.Name("endDate"));
                skilltradeT = driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='true']"));
                skilltradeF = driver.FindElement(By.XPath("//input[@name='skillTrades'][@value='false']"));
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
        public void RenderCreditComponent()
        {
            try
            {
                credit = driver.FindElement(By.Name("charge"));

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
            return tagList![index];
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
            return tagRemoveList![index];
        }
        public IWebElement CreditLocator()
        {

            return credit!;
        }
        public IWebElement DescriptionLocator()
        {

            return description!;
        }
        public IWebElement TitleLocator()
        {

            return title!;
        }
        public IWebElement CategoryLocator()
        {

            return category!;
        }
        public IWebElement SubCategoryLocator()
        {

            return subcategory!;
        }
        public IWebElement ServiceType0Locator()
        {

            return servicetype0!;
        }
        public IWebElement ServiceType1Locator()
        {

            return servicetype1!;
        }
        public IWebElement LocationTypeLocator()
        {

            return locationtype!;
        }
        public IWebElement StartDateLocator()
        {

            return startdate!;
        }
        public IWebElement EndDateLocator()
        {

            return enddate!;
        }
        public IWebElement SkillTradeTLocator()
        {

            return skilltradeT!;
        }
        public IWebElement SkillTradeFLocator()
        {

            return skilltradeF!;
        }
        public IWebElement WorkSamplesLocator()
        {

            return worksamples!;
        }
        public IWebElement ActiveTLocator()
        {

            return activeT!;
        }
        public IWebElement ActiveFLocator()
        {

            return activeF!;
        }
        public IWebElement SaveButtonLocator()
        {

            return saveButton!;
        }
        public IWebElement CancelButtonLocator()
        {

            return cancelButton!;
        }

    }
}
